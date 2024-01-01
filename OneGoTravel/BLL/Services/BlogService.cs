using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BlogService
    {
        public static List<BlogDTO> Get()
        {
            var data = DataAccessFactory.BlogData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BlogDTO>>(data);
            return mapped;
        }
        public static BlogDTO Get(int id)
        {
            var data = DataAccessFactory.BlogData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BlogDTO>(data);
            return mapped;
        }
        public static BlogDTO Create(BlogDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
                c.CreateMap<BlogDTO, Blog>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Blog>(obj);

            var result = DataAccessFactory.BlogData().Create(data);
            var redata = mapper.Map<BlogDTO>(result);
            return redata;
        }
        public static BlogDTO Delete(int Id)
        {
            var data = DataAccessFactory.BlogData().Delete(Id);
            if(data == null||!(data is Blog))
            {
                return null;

            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BlogDTO>(data);
            return mapped;

        }
        public static BlogDTO Update(BlogDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
                c.CreateMap<BlogDTO, Blog>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Blog>(obj);
            var result = DataAccessFactory.BlogData().Update(data);
            var redata = mapper.Map<BlogDTO>(result);
            return redata;

        }
        public static BlogCommentDTO GetwithCommnets(int id)
        {
            var data = DataAccessFactory.BlogData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogCommentDTO>();
                c.CreateMap<Comment, CommentDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BlogCommentDTO>(data);
            return mapped;
        }
    }
}
