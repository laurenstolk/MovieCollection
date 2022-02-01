using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieEntryContext : DbContext
    {
        //Constructor
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options)
        {
            // blank for now
        }

        public DbSet<EntryResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName="Action/Adventure"},
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" },
                new Category { CategoryID = 9, CategoryName = "History" },
                new Category { CategoryID = 10, CategoryName = "Romance" },
                new Category { CategoryID = 11, CategoryName = "Science Fiction" }
                );



            mb.Entity<EntryResponse>().HasData(

                new EntryResponse
                {
                    MovieID = 1,
                    CategoryID = 3,
                    Title = "The Hundred Foot Journey",
                    Year = 2014,
                    Director = "Lasse Hallstrom",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new EntryResponse
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Sky High",
                    Year = 2005,
                    Director = "Mike Mitchell",
                    Rating = "G",
                    Edited = false,
                    LentTo = "Kylie Fromm",
                    Notes = ""
                },
                new EntryResponse
                {
                    MovieID = 3,
                    CategoryID = 9,
                    Title = "Hidden Figures",
                    Year = 2016,
                    Director = "Theodore Melfi",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }

    }
}