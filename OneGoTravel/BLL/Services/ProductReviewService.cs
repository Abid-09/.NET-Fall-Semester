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
    public class ProductReviewService
    {
        public static List<ProductReviewDTO> Get()
        {
            var data = DataAccessFactory.ProductReviewData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductReview, ProductReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductReviewDTO>>(data);
            return mapped;
        }
        public static ProductReviewDTO Get(int id)
        {
            var data = DataAccessFactory.ProductReviewData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductReview, ProductReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductReviewDTO>(data);
            return mapped;
        }
        public static ProductReviewDTO Create(ProductReviewDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductReview, ProductReviewDTO>();
                c.CreateMap<ProductReviewDTO, ProductReview>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ProductReview>(obj);

            var result = DataAccessFactory.ProductReviewData().Create(data);
            var redata = mapper.Map<ProductReviewDTO>(result);
            return redata;
        }
        public static ProductReviewDTO Delete(int Id)
        {
            var data = DataAccessFactory.ProductReviewData().Delete(Id);
            if (data == null || !(data is ProductReview))
            {
                return null;

            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductReview, ProductReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductReviewDTO>(data);
            return mapped;

        }
        public static ProductReviewDTO Update(ProductReviewDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductReview, ProductReviewDTO>();
                c.CreateMap<ProductReviewDTO, ProductReview>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<ProductReview>(obj);
            var result = DataAccessFactory.ProductReviewData().Update(data);
            var redata = mapper.Map<ProductReviewDTO>(result);
            return redata;

        }
    }
}
