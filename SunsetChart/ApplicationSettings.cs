using System;
using System.IO;
using System.Web.Script.Serialization;

namespace SunsetChart
{
    public class ApplicationSettings<T> where T : new()
    {
        private static T m_instance;
        private const string DefaultFilename = "SunChartSettings.jsn";

        private static string FullSettingsFilename => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DefaultFilename);

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
            T t = Instance;
            if (File.Exists(FullSettingsFilename))
            {
                var serializer = new JavaScriptSerializer();                              
                t = serializer.Deserialize<T>(File.ReadAllText(FullSettingsFilename));
            }
                
            return t;
        }        

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new T();
                }
                return m_instance;
            }
        }
    }
}