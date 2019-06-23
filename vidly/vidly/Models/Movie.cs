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

        public DateTime ReleaseDate { get; set; }

        public  DateTime DateAdded { get; set; }

        public int NumStocks { get; set; }

    }
}