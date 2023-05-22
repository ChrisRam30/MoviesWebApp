using Microsoft.EntityFrameworkCore;
using Movies.Data;

namespace Movies.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MoviesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MoviesContext>>()))
        {
            if (context == null || context.MovieName == null)
            {
                throw new ArgumentNullException("Null MoviesContext");
            }

            // Look for any movies.
            if (context.MovieName.Any())
            {
                return;   // DB has been seeded
            }

            context.MovieName.AddRange(
                new MovieName
                {
                    Title = "Pacific Rim",
                    ReleaseDate = DateTime.Parse("2011-2-12"),
                    Genre = "Action",
                    Price = 8.99M,
                    Rating = "PG-13"
                },

                new MovieName
                {
                    Title = "A Knights Tale ",
                    ReleaseDate = DateTime.Parse("2004-3-13"),
                    Genre = "Drama",
                    Price = 9.99M,
                    Rating = "PG-13"
                },

                new MovieName
                {
                    Title = "Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1999-2-23"),
                    Genre = "Drama",
                    Price = 9.99M,
                    Rating = "R"
                },

                new MovieName
                {
                    Title = "Batman Begins",
                    ReleaseDate = DateTime.Parse("2009-4-15"),
                    Genre = "Action",
                    Price = 10.99M,
                    Rating = "PG-13"
                }
            );
            context.SaveChanges();
        }
    }
}