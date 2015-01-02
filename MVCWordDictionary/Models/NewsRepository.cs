using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    public class NewsRepository : IRepository<News>
    {
        WordManagerEntities entities = new WordManagerEntities();

        public IQueryable<News> GetAll()
        {
            return entities.News;
        }

        public News GetDetail(Guid id)
        {
            return entities.News.Where(x => x.NewID == id).FirstOrDefault();
        }

        public News GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(News model)
        {
            entities.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(News model)
        {
            entities.News.Add(model);
        }

        public void Delete(Guid id)
        {
            var news = entities.News.Where(x => x.NewID == id).FirstOrDefault();
            if (news != null)
            {
                entities.News.Remove(news);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            entities.SaveChanges();
        }

        public void Reject()
        {
            entities.Dispose();
        }
    }
}