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
    public class CommentService
    {
        public static List<CommentDTO> Get()
        {
            var data = DataAccessFactory.CommentData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CommentDTO>>(data);
            return mapped;
        }
        public static CommentDTO Get(int id)
        {
            var data = DataAccessFactory.CommentData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CommentDTO>(data);
            return mapped;
        }
        public static CommentDTO Create(CommentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
                c.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Comment>(obj);

            var result = DataAccessFactory.CommentData().Create(data);
            var redata = mapper.Map<CommentDTO>(result);
            return redata;
        }
        public static CommentDTO Delete(int Id)
        {
            var data = DataAccessFactory.CommentData().Delete(Id);
            if (data == null || !(data is Comment))
            {
                return null;

            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CommentDTO>(data);
            return mapped;

        }
        public static CommentDTO Update(CommentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
                c.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Comment>(obj);
            var result = DataAccessFactory.CommentData().Update(data);
            var redata = mapper.Map<CommentDTO>(result);
            return redata;

        }
    }
}
