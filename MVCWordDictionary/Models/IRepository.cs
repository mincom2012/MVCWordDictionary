using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T GetDetail(Guid id);

        T GetDetail(int id);

        void Update(T model);

        void Insert(T model);

        void Delete(Guid id);

        void Delete(int id);

        void Save();

        void Reject();
    }
}