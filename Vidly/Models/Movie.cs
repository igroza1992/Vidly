using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert customer's name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Numbre in Stock")]
        public int Cuntity { get; set; }

        public  Genres Genres { get; set; }

        [Display(Name ="Genre")]
        public byte GenresId { get; set; }

    }
}