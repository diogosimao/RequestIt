using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseClass<T>
    {
        public virtual bool Save(bool Insert, T obj)
        {
            return false;
        }
        public virtual bool Delete(T obj)
        {
            return false;
        }
        public virtual T Search(int id)
        {
            return default(T);
        }
        public virtual List<T> SearchAll()
        {
            return new List<T>();
        }
        public virtual List<T> Search(string description)
        {
            return new List<T>();
        }
    }
}