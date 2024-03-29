﻿//////////////////////////////////////////////////////////////////////////////////////////////////////
//  
//  C# Singleton class and thread-safe class for calculating Sunrise and Sunset times.
//
// The algorithm was adapted from the JavaScript sample provided here:
//      http://home.att.net/~srschmitt/script_sun_rise_set.html
//
//  NOTICE: this code is provided "as-is", without any warrenty, obligations or liability for it.
//          You may use this code freely for any use.
// 
//  Zacky Pickholz (zacky.pickholz@gmail.com)
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using static System.Math;

namespace SunsetChart
{
    internal sealed class SunTimes
    {
        #region Private Data Members

        private readonly object m_lock = new object();

        private const double mDR = PI / 180;
        private const double mK1 = 15 * mDR * 1.0027379;

        private readonly int[] m_riseTimeArr = new int[3] { 0, 0, 0 };
        private readonly int[] m_setTimeArr = new int[3] { 0, 0, 0 };
        private double m_rizeAzimuth;
        private double m_setAzimuth;

        private double[] mSunPositionInSkyArr = { 0.0, 0.0 };
        private double[] mRightAscentionArr = { 0.0, 0.0, 0.0 };
        private double[] mDecensionArr = { 0.0, 0.0, 0.0 };
        private double[] mVHzArr = { 0.0, 0.0, 0.0 };

        private bool m_IsSunrise;
        private bool m_IsSunset;

        private string m_timeZone;

        public string SelectedTimeZone { set { m_timeZone = value; } }

        #endregion

        #region Singleton

        private static readonly SunTimes m_Instance = new SunTimes();    // The singleton instance

        private SunTimes() { }

        public static SunTimes Instance
        {
            get { return m_Instance; }
        }

        #endregion

        internal abstract class Coords
        {
            internal protected int mDegrees;
            internal protected int mMinutes;
            internal protected int mSeconds;

            public double ToDouble()
            {
                return Sign() * (mDegrees + ((double)mMinutes / 60) + ((double)mSeconds / 3600));
            }

            internal protected abstract int Sign();
        }

        public class LatitudeCoords : Coords
        {
            public enum Direction
            {
                North,
                South
            }
            internal protected Direction mDirection = Direction.North;

            public LatitudeCoords(int degrees, int minutes, int seconds, Direction direction)
            {
                mDegrees = degrees;
                mMinutes = minutes;
                mSeconds = seconds;
                mDirection = direction;
            }

            protected internal override int Sign()
            {
                return (mDirection == Direction.North ? 1 : -1);
            }
        }

        public class LongitudeCoords : Coords
        {
            public enum Direction
            {
                East,
                West
            }

            internal protected Direction mDirection = Direction.East;

            public LongitudeCoords(int degrees, int minutes, int seconds, Direction direction)
            {
                mDegrees = degrees;
                mMinutes = minutes;
                mSeconds = seconds;
                mDirection = direction;
            }

            protected internal override int Sign()
            {
                return (mDirection == Direction.East ? 1 : -1);
            }
        }

        /// <summary>
        /// Calculate sunrise and sunset times. Returns false if time zone and longitude are incompatible.
        /// </summary>
        /// <param name="lat">Latitude coordinates.</param>
        /// <param name="lon">Longitude coordinates.</param>
        /// <param name="date">Date for which to calculate.</param>
        /// <param name="riseTime">Sunrise time (output)</param>
        /// <param name="setTime">Sunset time (output)</param>
        /// <param name="isSunrise">Whether or not the sun rises at that day</param>
        /// <param name="isSunset">Whether or not the sun sets at that day</param>
        /// <param name="convertSummerTime"></param>
        public bool CalculateSunRiseSetTimes(LatitudeCoords lat, LongitudeCoords lon, DateTime date,
                                                ref DateTime riseTime, ref DateTime setTime,
                                                ref bool isSunrise, ref bool isSunset, bool convertSummerTime=false)
        {
            return CalculateSunRiseSetTimes(lat.ToDouble(), lon.ToDouble(), date, ref riseTime, ref setTime, ref isSunrise, ref isSunset,convertSummerTime);
        }

        /// <summary>
        /// Calculate sunrise and sunset times. Returns false if time zone and longitude are incompatible.
        /// </summary>
        /// <param name="lat">Latitude in decimal notation.</param>
        /// <param name="lon">Longitude in decimal notation.</param>
        /// <param name="date">Date for which to calculate.</param>
        /// <param name="riseTime">Sunrise time (output)</param>
        /// <param name="setTime">Sunset time (output)</param>
        /// <param name="isSunrise">Whether or not the sun rises at that day</param>
        /// <param name="isSunset">Whether or not the sun sets at that day</param>
        /// <param name="convertSummerTime"></param>
        public bool CalculateSunRiseSetTimes(double lat, double lon, DateTime date,
                                                ref DateTime riseTime, ref DateTime setTime,
                                                ref bool isSunrise, ref bool isSunset,bool convertSummerTime=false)
        {
            lock (m_lock)    // lock for thread safety
            {

                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                if (!string.IsNullOrEmpty(m_timeZone))
                {
                    var test = TimeZoneInfo.GetSystemTimeZones();
                    timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(m_timeZone);    
                }
                
                
                double zone = -(int)Round(timeZoneInfo.GetUtcOffset(new DateTime(date.Year,1,1)).TotalSeconds / 3600);
                if (convertSummerTime && timeZoneInfo.SupportsDaylightSavingTime)
                {
                    zone = -(int)Round(timeZoneInfo.GetUtcOffset(date).TotalSeconds / 3600);    
                }
                
                double jd = GetJulianDay(date) - 2451545;  // Julian day relative to Jan 1.5, 2000
                
                if ((Sign(zone) == Sign(lon)) && (Abs(zone) > double.Epsilon))
                {
                    Debug.Print("WARNING: time zone and longitude are incompatible!");
                    return false;
                }

                lon = lon / 360;
                double tz = zone / 24;
                double ct = jd / 36525 + 1;                                 // centuries since 1900.0
                double t0 = LocalSiderealTimeForTimeZone(lon, jd, tz);      // local sidereal time

                // get sun position at start of day
                jd += tz;
                CalculateSunPosition(jd, ct);
                double ra0 = mSunPositionInSkyArr[0];
                double dec0 = mSunPositionInSkyArr[1];

                // get sun position at end of day
                jd += 1;
                CalculateSunPosition(jd, ct);
                double ra1 = mSunPositionInSkyArr[0];
                double dec1 = mSunPositionInSkyArr[1];

                // make continuous 
                if (ra1 < ra0)
                    ra1 += 2 * PI;

                // initialize
                m_IsSunrise = false;
                m_IsSunset = false;

                mRightAscentionArr[0] = ra0;
                mDecensionArr[0] = dec0;

                // check each hour of this day
                for (int k = 0; k < 24; k++)
                {
                    mRightAscentionArr[2] = ra0 + (k + 1) * (ra1 - ra0) / 24;
                    mDecensionArr[2] = dec0 + (k + 1) * (dec1 - dec0) / 24;
                    mVHzArr[2] = TestHour(k, zone, t0, lat);

                    // advance to next hour
                    mRightAscentionArr[0] = mRightAscentionArr[2];
                    mDecensionArr[0] = mDecensionArr[2];
                    mVHzArr[0] = mVHzArr[2];
                }

                riseTime = new DateTime(date.Year, date.Month, date.Day, m_riseTimeArr[0], m_riseTimeArr[1], m_riseTimeArr[2]);
                setTime = new DateTime(date.Year, date.Month, date.Day, m_setTimeArr[0], m_setTimeArr[1], m_setTimeArr[2]);

                isSunset = true;
                isSunrise = true;

                // neither sunrise nor sunset
                if ((!m_IsSunrise) && (!m_IsSunset))
                {
                    if (mVHzArr[2] < 0)
                        isSunrise = false; // Sun down all day
                    else
                        isSunset = false; // Sun up all day
                }
                // sunrise or sunset
                else
                {
                    if (!m_IsSunrise)
                        // No sunrise this date
                        isSunrise = false;
                    else if (!m_IsSunset)
                        // No sunset this date
                        isSunset = false;
                }

                return true;
            }
        }

        #region Private Methods

      

        // Local Sidereal Time for zone
        private double LocalSiderealTimeForTimeZone(double lon, double jd, double z)
        {
            double s = 24110.5 + 8640184.812999999 * jd / 36525 + 86636.6 * z + 86400 * lon;
            s = s / 86400;
            s = s - Floor(s);
            return s * 360 * mDR;
        }

        // determine Julian day from calendar date
        // (Jean Meeus, "Astronomical Algorithms", Willmann-Bell, 1991)
        private double GetJulianDay(DateTime date)
        {
            int month = date.Month;
            int day = date.Day;
            int year = date.Year;

            bool gregorian = (year < 1583) ? false : true;

            if ((month == 1) || (month == 2))
            {
                year = year - 1;
                month = month + 12;
            }

            double a = Floor((double)year / 100);
            double b;

            if (gregorian)
                b = 2 - a + Floor(a / 4);
            else
                b = 0.0;

            double jd = Floor(365.25 * (year + 4716))
                       + Floor(30.6001 * (month + 1))
                       + day + b - 1524.5;

            return jd;
        }

        // sun's position using fundamental arguments 
        // (Van Flandern & Pulkkinen, 1979)
        private void CalculateSunPosition(double jd, double ct)
        {
            double g, lo, s, u, v, w;

            lo = 0.779072 + 0.00273790931 * jd;
            lo = lo - Floor(lo);
            lo = lo * 2 * PI;

            g = 0.993126 + 0.0027377785 * jd;
            g = g - Floor(g);
            g = g * 2 * PI;

            v = 0.39785 * Sin(lo);
            v = v - 0.01 * Sin(lo - g);
            v = v + 0.00333 * Sin(lo + g);
            v = v - 0.00021 * ct * Sin(lo);

            u = 1 - 0.03349 * Cos(g);
            u = u - 0.00014 * Cos(2 * lo);
            u = u + 0.00008 * Cos(lo);

            w = -0.0001 - 0.04129 * Sin(2 * lo);
            w = w + 0.03211 * Sin(g);
            w = w + 0.00104 * Sin(2 * lo - g);
            w = w - 0.00035 * Sin(2 * lo + g);
            w = w - 0.00008 * ct * Sin(g);

            // compute sun's right ascension
            s = w / Sqrt(u - v * v);
            mSunPositionInSkyArr[0] = lo + Atan(s / Sqrt(1 - s * s));

            // ...and declination 
            s = v / Sqrt(u);
            mSunPositionInSkyArr[1] = Atan(s / Sqrt(1 - s * s));
        }

        // test an hour for an event
        private double TestHour(int k, double zone, double t0, double lat)
        {
            double[] ha = new double[3];
            double a, b, c, d, e, s, z;
            double time;
            int hr, min,sec;
            double az, dz, hz, nz;

            ha[0] = t0 - mRightAscentionArr[0] + k * mK1;
            ha[2] = t0 - mRightAscentionArr[2] + k * mK1 + mK1;

            ha[1] = (ha[2] + ha[0]) / 2;    // hour angle at half hour
            mDecensionArr[1] = (mDecensionArr[2] + mDecensionArr[0]) / 2;  // declination at half hour

            s = Sin(lat * mDR);
            c = Cos(lat * mDR);
            z = Cos(90.833 * mDR);    // refraction + sun semidiameter at horizon

            if (k <= 0)
                mVHzArr[0] = s * Sin(mDecensionArr[0]) + c * Cos(mDecensionArr[0]) * Cos(ha[0]) - z;

            mVHzArr[2] = s * Sin(mDecensionArr[2]) + c * Cos(mDecensionArr[2]) * Cos(ha[2]) - z;

            if (Sign(mVHzArr[0]) == Sign(mVHzArr[2]))
                return mVHzArr[2];  // no event this hour

            mVHzArr[1] = s * Sin(mDecensionArr[1]) + c * Cos(mDecensionArr[1]) * Cos(ha[1]) - z;

            a = 2 * mVHzArr[0] - 4 * mVHzArr[1] + 2 * mVHzArr[2];
            b = -3 * mVHzArr[0] + 4 * mVHzArr[1] - mVHzArr[2];
            d = b * b - 4 * a * mVHzArr[0];

            if (d < 0)
                return mVHzArr[2];  // no event this hour

            d = Sqrt(d);
            e = (-b + d) / (2 * a);

            if ((e > 1) || (e < 0))
                e = (-b - d) / (2 * a);

            time = k + e + 1 / (double)120; // time of an event

            TimeSpan timeSpan = TimeSpan.FromHours(time);
            hr = timeSpan.Hours;
            min = timeSpan.Minutes;
            sec = timeSpan.Seconds;

            hz = ha[0] + e * (ha[2] - ha[0]);                 // azimuth of the sun at the event
            nz = -Cos(mDecensionArr[1]) * Sin(hz);
            dz = c * Sin(mDecensionArr[1]) - s * Cos(mDecensionArr[1]) * Cos(hz);
            az = Atan2(nz, dz) / mDR;
            if (az < 0) az = az + 360;

            if ((mVHzArr[0] < 0) && (mVHzArr[2] > 0))
            {
                m_riseTimeArr[0] = hr;
                m_riseTimeArr[1] = min;
                m_riseTimeArr[2] = sec;

                m_rizeAzimuth = az;
                m_IsSunrise = true;
            }

            if ((mVHzArr[0] > 0) && (mVHzArr[2] < 0))
            {
                m_setTimeArr[0] = hr;
                m_setTimeArr[1] = min;
                m_setTimeArr[2] = sec;
                m_setAzimuth = az;
                m_IsSunset = true;
            }

            return mVHzArr[2];
        }

        #endregion  // Private Methods
    }
}
