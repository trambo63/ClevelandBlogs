using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Models.CommentModels
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
