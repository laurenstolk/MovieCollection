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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EntryResponse>().HasData(

                new EntryResponse
                {
                    MovieID = 1,
                    Category = "Drama",
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
                    Category = "Comedy",
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
                    Category = "History",
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