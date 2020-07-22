using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace API.DBContexts
{
    /// <summary> The DBContext class - Using JSON to persiste data </summary>
    public static class DBContext<T>
    {
        private static string JsonFile => Directory.GetCurrentDirectory() + "\\MyBankFiles\\{0}.json";

        /// <summary> Full path of Json file (drive + folders + file + extension) </summary>
        private static string fullPath
        {
            get
            {
                string filename = typeof(T).Name;
                return string.Format(JsonFile, filename);
            }
        }

        /// <summary> Write the Json file </summary>
        /// <param name="obj"></param>
        public static void Write(object obj)
        {
            var writer = JsonConvert.SerializeObject(obj, Formatting.Indented);

            CreateDirectory();

            File.WriteAllText(fullPath, writer);
        }

        /// <summary> Get data from Json file </summary>
        /// <returns></returns>
        public static List<T> GetData()
        {
            var json = File.Exists(fullPath) ? File.ReadAllText(fullPath) : null;
            return json != null ? JsonConvert.DeserializeObject<List<T>>(json) : new List<T>();
        }

        /// <summary> Create the directory if it doesn't exists </summary>
        private static void CreateDirectory()
        {
            var jsonDirectory = Directory.GetParent(JsonFile).FullName;
            if (!Directory.Exists(jsonDirectory))
            {
                Directory.CreateDirectory(jsonDirectory);
            }
        }
    }
}
