﻿using System.ComponentModel.DataAnnotations;

namespace Bai_ThucHanh.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }


    }
}
