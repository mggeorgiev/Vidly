using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MoviesDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreTypeDTO GentryTypeDTO { get; set; }

        [Required]
        public int GenreTypeId { get; set; }


        public DateTime? ReleaseDate { get; set; }


        public DateTime? DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }
    }
}