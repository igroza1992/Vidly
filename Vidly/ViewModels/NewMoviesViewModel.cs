using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMoviesViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert name")]

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Please insert release date")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Numbre in Stock")]
        [Range(1,20)]
        [Required]
        public int? Cuntity { get; set; }
        

        [Display(Name = "Genre")]
        [Required]
        public byte? GenresId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public NewMoviesViewModel()
        {
            Id = 0;
        }
        public NewMoviesViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Cuntity = movie.Cuntity;
            GenresId = movie.GenresId;
        }

    }
}