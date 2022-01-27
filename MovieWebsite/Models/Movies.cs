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
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        // Edited, Lent_To, and Notes should not be required 
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        // Notes should not be over 25 characters 
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
