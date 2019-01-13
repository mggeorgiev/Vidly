using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GenreType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        //public string Genre { get; set; }
        public string Name { get; set; }
    }
}