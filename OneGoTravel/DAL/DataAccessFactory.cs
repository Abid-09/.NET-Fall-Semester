using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Blog, int, Blog> BlogData()
        {
            return new BlogRepo();
        }
        public static IRepo<Comment, int, Comment> CommentData()
        {
            return new CommentRepo();
        }
        public static IRepo<ProductReview, int, ProductReview> ProductReviewData()
        {
            return new ProductReviewRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token,string,Token> TokenData ()
        {
            return new TokenRepo();
        }
    }
}
