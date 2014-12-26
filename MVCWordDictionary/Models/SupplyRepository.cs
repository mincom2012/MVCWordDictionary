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
            _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(Suppliers model)
        {
            _db.Suppliers.Add(model);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var supply = _db.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            if (supply !=null)
            {
                _db.Suppliers.Remove(supply);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Reject()
        {
            _db.Dispose();
        }
    }
}