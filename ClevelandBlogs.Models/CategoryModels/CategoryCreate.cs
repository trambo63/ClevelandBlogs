﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Models
{
    public class CategoryCreate
    {
        [Required]
        public string Title { get; set; }
    }
}
