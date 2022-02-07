using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class MovieEntriesContext : DbContext
    {
        // Set up a constructor 
        public MovieEntriesContext(DbContextOptions<MovieEntriesContext> options) : base(options)
        {
            // leave blank for now 
        }

        public DbSet<Movies> movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName="Action/Thriller"},
                new Category { CategoryID = 2, CategoryName = "Drama" },
                new Category { CategoryID = 3, CategoryName = "Family" },
                new Category { CategoryID = 4, CategoryName = "Comedy" }
                );
            mb.Entity<Movies>().HasData(

                new Movies
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title="The Bourne Identity",
                    Year= 2002,
                    Director = "Doug Liman",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Cousin Ben",
                    Notes = "Loved it! Very intense."
                },

                new Movies
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "The Blind Side",
                    Year = 2009,
                    Director = "John Lee Hancock",
                    Rating = "PG-13",
                    Edited = true,
                    Lent_To = "",
                    Notes = ""
                },

                new Movies
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "Monsters University",
                    Year = 2013,
                    Director = "Dan Scanlon",
                    Rating = "G",
                    Edited = false,
                    Lent_To = "",
                    Notes = "even better than the first!"
                }
            );
        }
    }
}
