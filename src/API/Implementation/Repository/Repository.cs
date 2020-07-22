using API.DBContexts;
using System;
using System.Collections.Generic;

namespace API.Implementation
{
    /// <summary> The Repository abstract class </summary>
    public abstract class Repository<T>
    {
        /// <summary> Add a new line </summary>
        /// <param name="obj">GetList of data to be saved </param>
        protected bool Add(T obj)
        {
            try
            {
                var data= GetData();
                data.Add(obj);
                DBContext<T>.Write(data);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary> Add data </summary>
        /// <param name="obj">GetList of data to be saved </param>
        protected bool Update(IList<T> data)
        {
            try
            {
                DBContext<T>.Write(data);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary> Get all data from file </summary>
        /// <returns></returns>
        protected IList<T> GetData()
        {
            var list = DBContext<T>.GetData();
            return list ?? new List<T>();
        }
    }
}
