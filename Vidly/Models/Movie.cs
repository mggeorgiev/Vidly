using System;
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

        [Required]
        [Display(Name="Genre")]
        public int GenreTypeId { get; set; }


        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name="Added in the DB on")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
    }
}