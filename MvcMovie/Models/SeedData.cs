using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "G",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Documentary",
                        Rating = "G",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "PG",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
