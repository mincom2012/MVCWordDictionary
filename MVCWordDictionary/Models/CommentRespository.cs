using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    public class CommentRespository : IRepository<Comment>
    {

        WordManagerEntities _db = new WordManagerEntities();

        public IQueryable<Comment> GetAll()
        {
            return _db.Comment;
        }

        public Comment GetDetail( Guid id )
        {
            return _db.Comment.Where(x => x.CommentID == id).FirstOrDefault();
        }

        public Comment GetDetail( int id )
        {
            throw new NotImplementedException();
        }

        public void Update( Comment model )
        {
            throw new NotImplementedException();
        }

        public void Insert( Comment model )
        {
             _db.Comment.Add(model);
        }

        public void Delete( Guid id )
        {
            var comment = _db.Comment.Where(x => x.CommentID == id).FirstOrDefault();
            _db.Comment.Remove(comment);
        }

        public void Delete( int id )
        {
            throw new NotImplementedException();
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