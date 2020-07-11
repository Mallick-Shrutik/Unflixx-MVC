using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unflixx.Models;

namespace Unflixx.ViewModels
{
    public class GenresViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStocks { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }

        }

        public GenresViewModel()
        {
            Id = 0;
        }

        public GenresViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStocks = movie.NumberInStocks;
            GenreId = movie.GenreId;
        }

    }
}