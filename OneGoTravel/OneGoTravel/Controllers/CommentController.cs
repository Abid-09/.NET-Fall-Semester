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
    public class CommentController : ApiController
    {
        [HttpGet]
        [Route("api/comment/all")]
        public HttpResponseMessage Comments()
        {
            try
            {
                var data = CommentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
        [HttpGet]
        [Route("api/comment/{id}")]
        public HttpResponseMessage Comments(int Id)
        {
            try
            {
                var data = CommentService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/comment/create")]
        public HttpResponseMessage Create(CommentDTO data)
        {
            try
            {
                var data1 = CommentService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, data1);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/comment/update")]
        public HttpResponseMessage Update(CommentDTO data)
        {
            var exm = CommentService.Get(data.Id);
            if (exm != null)
            {
                try
                {
                    var data1 = CommentService.Update(data);
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
        [Route("api/comment/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exm = CommentService.Get(Id);
            if (exm != null)
            {
                try
                {
                    var data = CommentService.Delete(Id);
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
