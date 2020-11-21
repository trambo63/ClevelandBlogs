using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        //[ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        //public virtual Post Post { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
