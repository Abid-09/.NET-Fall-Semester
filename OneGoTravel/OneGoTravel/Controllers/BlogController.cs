using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneGoTravel.Controllers
{
    public class BlogController : ApiController
    {
        [HttpGet]
        [Route("api/blogs")]
        public HttpResponseMessage Blogs()
        {
            try
            {
                var data = BlogService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
        [HttpGet]
        [Route("api/blog/{id}")]
        public HttpResponseMessage Blogs(int Id)
        {
            try
            {
                var data = BlogService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/blogs/create")]
        public HttpResponseMessage Create(BlogDTO data)
        {
            try
            {
                var data1 = BlogService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, data1);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/blogs/update")]
        public HttpResponseMessage Update(BlogDTO data)
        {
            var exm = BlogService.Get(data.Id);
            if (exm != null)
            {
                try
                {
                    var data1 = BlogService.Update(data);
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
        [Route("api/blogs/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exm = BlogService.Get(Id);
            if (exm != null)
            {
                try
                {
                    var data = BlogService.Delete(Id);
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

        [HttpGet]
        [Route("api/blog/{id}/comments")]
        public HttpResponseMessage PostComment(int id)
        {
            try
            {
                var data = BlogService.GetwithCommnets(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
