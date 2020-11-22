using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Models.ReplyModels
{
    public class ReplyEdit
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
    }
}
