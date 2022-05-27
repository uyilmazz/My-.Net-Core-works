using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using MovieStore.Entities;


namespace MovieStore.DBOperations
{

    public class DataGenerator
    {

        public static void initialize(IServiceProvider serviceProvider)
        {

            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {   

                context.Films.AddRange(
                    new Film{
                        Id = 1,
                        Name = "Hobbit",
                        Date = new DateTime(2000, 9, 1),
                        GenreId = 2,
                        DirectorId = 1,
                        Price = 125
                    },
                    new Film{
                        Id = 2,
                        Name = "Wanted",
                        Date = new DateTime(1995, 2, 5),
                        GenreId = 1,
                        DirectorId = 2,
                        Price = 568
                    },
                    new Film{
                        Id = 3,
                        Name = "Negotiation",
                        Date = new DateTime(2010,12, 15),
                        GenreId = 3,
                        DirectorId = 3,
                        Price = 4123
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Dram",
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Action",
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Adventure",
                    },
                    new Genre
                    {
                        Id = 4,
                        Name = "Horror",
                    }

                );
                context.SaveChanges();
            }
        }
    }

}