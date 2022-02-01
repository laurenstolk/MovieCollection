using System;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
