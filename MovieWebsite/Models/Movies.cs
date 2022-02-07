using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class Movies
    {

        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please enter a Title for the movie.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter a Year for the movie.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter a Director for the movie.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please enter a Rating for the movie.")]
        public string Rating { get; set; }

        // Edited, Lent_To, and Notes should not be required 
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        // Notes should not be over 25 characters 
        [MaxLength(25)]
        public string Notes { get; set; }


        // Foreign Keys
        [Required(ErrorMessage = "Please enter a Category for the movie.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
