using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models
{
    public static class SeeData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {   
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>())) 
            {
                //Procurar por qualquer um filme
                if (context.Movie.Any()) 
                {
                    return; //Banco de dados foi semeado
                }

                context.Movie.AddRange(new Movie
                {
                    Title = "Harry Potter",
                    ReleaseDate = DateTime.Parse("2000-2-12"),
                    Genre = "Ficção",
                    Price = 7.99M,
                    Rating = "R"
                },
                new Movie

                {
                    Title = "Homen de ferro 3",
                    ReleaseDate = DateTime.Parse("2005-5-12"),
                    Genre = "Ação",
                    Price = 13.99M,
                    Rating = "P"
                },
                new Movie
                {
                    Title = "Viuva negra",
                    ReleaseDate = DateTime.Parse("2012-2-12"),
                    Genre = "Romance",
                    Price = 34.99M,
                    Rating = "R"
                }
                );
                context.SaveChanges();
            }
        }
    }
}
