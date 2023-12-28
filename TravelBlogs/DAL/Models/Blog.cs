using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [ForeignKey("User")]
        public string Blogby { get; set; }
        public DateTime Date {  get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Blogs { get; set; }
        public Blog()
        {
            Blogs = new List<Comment>();
        } 

    }
}
