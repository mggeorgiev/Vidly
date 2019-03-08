using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class GenreTypeDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        //public string Genre { get; set; }
        public string Name { get; set; }
    }
}