using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, int, Comment>
    {
        public Comment Create(Comment obj)
        {
            db.Comments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Comments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Comment> Read()
        {
            return db.Comments.ToList();
        }

        public Comment Read(int id)
        {
            return db.Comments.Find(id);
        }

        public Comment Update(Comment obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }
    }

}
