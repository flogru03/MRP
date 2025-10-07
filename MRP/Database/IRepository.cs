using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Database
{
    internal interface IRepository<T> where T : class
    {
        // TODO: add comments
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void DeleteById(int id);

    }
}
