using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TravelBlogs.Controllers
{
    public class ProductReviewController : ApiController
    {
        [HttpGet]
        [Route("api/productreview/all")]
        public HttpResponseMessage ProductReviews()
        {
            try
            {
                var data = ProductReviewService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
        [HttpGet]
        [Route("api/productreview/{id}")]
        public HttpResponseMessage ProductReview (int Id)
        {
            try
            {
                var data = ProductReviewService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/productreview/create")]
        public HttpResponseMessage Create(ProductReviewDTO data)
        {
            try
            {
                var data1 = ProductReviewService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, data1);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/productreview/update")]
        public HttpResponseMessage Update(ProductReviewDTO data)
        {
            var exm = ProductReviewService.Get(data.Id);
            if (exm != null)
            {
                try
                {
                    var data1 = ProductReviewService.Update(data);
                    return Request.CreateResponse(HttpStatusCode.OK, data1);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Not Found");
            }
        }

        [HttpDelete]
        [Route("api/productreview/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exm = ProductReviewService.Get(Id);
            if (exm != null)
            {
                try
                {
                    var data = ProductReviewService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Not Found");
            }
        }
    }
}
