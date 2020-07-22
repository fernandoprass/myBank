using System;
using API.DBContexts;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Implementation
{
    /// <summary> The Repository abstract class </summary>
    public abstract class Repository
    {
        protected readonly string Filename;

        /// <summary> The Repository class constructor </summary>
        /// <param name="filename"></param>
        protected Repository(string filename)
        {
            Filename = filename;
        }

        /// <summary> Save data </summary>
        /// <param name="obj">GetList of data to be saved </param>
        protected bool Save(object obj)
        {
            try
            {
                var data = GetData();
                data.Add(obj);
                DBContext.Write(Filename, data);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary> Get the data file </summary>
        /// <returns></returns>
        private List<Object> GetData()
        {
            var json = DBContext.Get(Filename);
            return json != null ? JsonConvert.DeserializeObject<List<object>>(json) : new List<object>();
        }
    }
}
