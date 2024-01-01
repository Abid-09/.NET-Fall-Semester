using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BlogCommentDTO: BlogDTO
    {
        public List<CommentDTO> Comments { get; set; }
        public BlogCommentDTO() 
        {
            Comments = new List<CommentDTO>();
        }
    }
}
