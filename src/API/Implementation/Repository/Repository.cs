using API.DBContexts;
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

            var data = GetData();
            data.Add(obj);
            DBContext<T>.Write(data);
            return true;
        }

        /// <summary> Add data </summary>
        /// <param name="obj">GetList of data to be saved </param>
        protected bool Update(IList<T> data)
        {
            DBContext<T>.Write(data);
            return true;
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
