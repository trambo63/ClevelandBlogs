using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Title { get; set; }
    }
}
