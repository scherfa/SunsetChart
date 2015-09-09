using System;
using System.IO;
using System.Web.Script.Serialization;

namespace SunsetChart
{
    public class ApplicationSettings<T> where T : new()
    {
        private const string DefaultFilename = "SunChartSettings.jsn";

        private static string FullSettingsFilename
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DefaultFilename);                
            }
        }


        public void Save()
        {
            File.WriteAllText(FullSettingsFilename, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings)
        {
            File.WriteAllText(FullSettingsFilename, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load()
        {
            T t = new T();
            if (File.Exists(FullSettingsFilename))
            {
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(FullSettingsFilename));
            }
                
            return t;
        }
    }
}