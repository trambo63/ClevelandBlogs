using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Models.CategoryModels
{
    public class CommentListItemByPostId
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
