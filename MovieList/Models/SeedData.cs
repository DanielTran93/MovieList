using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieListContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieListContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Dunkirk",
                         ReleaseDate = DateTime.Parse("2017-07-13"),
                         Genre = "Action, Drama, History",
                         Rating = 8
                     }

                );
                context.SaveChanges();
            }
        }
    }
}
