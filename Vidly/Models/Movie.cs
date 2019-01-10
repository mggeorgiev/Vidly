using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name="Genre")]
        public int GenreTypeId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
    }
}