using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Genre { get; set; }

        [Required]
        [Display (Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }

        public  DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display (Name = "Number in Stock")]
        public int NumStocks { get; set; }

    }
}