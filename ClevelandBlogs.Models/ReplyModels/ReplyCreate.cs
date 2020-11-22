using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Models.ReplyModels
{
    public class ReplyCreate
    {
        public int CommentId { get; set; }
        [MaxLength(8000, ErrorMessage = "Out of Characters!")]
        public string Content { get; set; }
    }
}
