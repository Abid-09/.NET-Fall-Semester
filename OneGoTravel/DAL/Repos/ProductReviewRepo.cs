using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductReviewRepo : Repo, IRepo<ProductReview, int, ProductReview>
    {
        public ProductReview Create(ProductReview obj)
        {
            db.ProductReviews.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.ProductReviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ProductReview> Read()
        {
            return db.ProductReviews.ToList();
        }

        public ProductReview Read(int id)
        {
            return db.ProductReviews.Find(id);
        }

        public ProductReview Update(ProductReview obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }

}
