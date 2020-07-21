using Newtonsoft.Json;
using System.IO;

namespace API.DBContexts
{
    /// <summary> The DBContext class - Using JSON to persiste data </summary>
    public static class DBContext
    {
        private static string JsonFile => Directory.GetCurrentDirectory() + "\\MyBankFiles\\{0}.json";

        /// <summary> Write the Json file </summary>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        public static void Write(string filename, object obj)
        {
            var writer = JsonConvert.SerializeObject(obj, Formatting.Indented);

            CreateDirectory();

            var path = GetFullPath(filename);

            File.WriteAllText(path, writer);
        }

        /// <summary> Get the Json file </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string Get(string filename)
        {
            var path = string.Format(JsonFile, filename);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return null;
        }

        /// <summary> Get the full path of the file </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetFullPath(string name)
        {
            var filename = string.Format(JsonFile, name);
            return filename;
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
