using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Repositories
{
    public interface IBaseRepository<T>
    {
        public void InsertRecord(T record);

        public List<T> GetAll();

        public T GetById(Guid Id);

        public void DeleteById(Guid Id);

        public void DeleteAll();
    }
}
