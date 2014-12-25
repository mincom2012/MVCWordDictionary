using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    public class CategoryRepository : IRepository<Category>
    {
        private WordManagerEntities _db = new WordManagerEntities();

        public IQueryable<Category> GetAll()
        {
            return _db.Category;
        }

        public Category GetDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category GetDetail(int id)
        {
            return _db.Category.Where(x => x.CategoryID == id).FirstOrDefault();
        }

        public void Update(Category model)
        {
            _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(Category model)
        {
            _db.Category.Add(model);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Reject()
        {
            _db.Dispose();
        }

        public void Delete(int id)
        {
            Category category = GetDetail(id);
            _db.Category.Remove(category);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}