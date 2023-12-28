using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BlogRepo: Repo, IRepo<Blog,int,Blog>
    {
        public Blog Create(Blog obj)
        {
            db.Blogs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Blogs.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Blog> Read()
        {
            return db.Blogs.ToList();
        }

        public Blog Read(int id)
        {
            return db.Blogs.Find(id);
        }

        public Blog Update(Blog obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

    }
}
