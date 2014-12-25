using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    public class SupplyRepository : IRepository<Suppliers>
    {
        private WordManagerEntities _db = new WordManagerEntities();

        public IQueryable<Suppliers> GetAll()
        {
            return _db.Suppliers;
        }

        public Suppliers GetDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Suppliers GetDetail(int id)
        {
            return _db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
        }

        public void Update(Suppliers model)
        {
            throw new NotImplementedException();
        }

        public void Insert(Suppliers model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Reject()
        {
            throw new NotImplementedException();
        }
    }
}