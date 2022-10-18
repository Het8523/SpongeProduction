using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpongeProduction.Data;
using System;
using System.Linq;

namespace SpongeProduction.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SpongeProductionContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SpongeProductionContext>>()))
            {
                // Look for any movies.
                if (context.Sponge.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sponge.AddRange(
                    new Sponge
                    {
                        Company = "Soapify",
                        Colour = "Red",
                        Shape ="Circle",
                        ReleaseDate = DateTime.Parse("1979-10-29"),
                        Price = 3.6M,
                        Rating = 2

                    },

                    new Sponge
                    {
                        Company = "Bathen",
                        Colour = "Yellow",
                        Shape = "Star",
                        ReleaseDate = DateTime.Parse("1956-2-08"),
                        Price = 10M,
                        Rating = 5


                    },

                    new Sponge
                    {
                        Company = "Pureology",
                        Colour = "Orange",
                        Shape = "Hettagon",
                        ReleaseDate = DateTime.Parse("1987-03-03"),
                        Price = 8M,
                        Rating = 3

                    },

                    new Sponge
                    {
                        Company = "Refreomatic",
                        Colour = "Black",
                        Shape = "Hexagon",
                        ReleaseDate = DateTime.Parse("1975-06-18"),
                        Price = 5.8M,
                        Rating = 5

                    },

                    new Sponge
                    {
                        Company = "Clarifyvio",
                        Colour = "Pink",
                        Shape = "Square",
                        ReleaseDate = DateTime.Parse("1945-3-18"),
                        Price = 6.7M,
                        Rating = 2

                    },

                    new Sponge
                    {
                        Company = "Purelux",
                        Colour = "Green",
                        Shape = "Random",
                        ReleaseDate = DateTime.Parse("1959-12-22"),
                        Price = 10.2M,
                        Rating = 4

                    },

                    new Sponge
                    {
                        Company = "Cleanistic",
                        Colour = "Brown",
                        Shape = "Half Circle",
                        ReleaseDate = DateTime.Parse("1999-11-16"),
                        Price = 5.34M,
                        Rating = 5

                    },

                    new Sponge
                    {
                        Company = "Sudsy",
                        Colour = "Purple",
                        Shape = "Pantagon",
                        ReleaseDate = DateTime.Parse("1990-04-25"),
                        Price = 6.09M,
                        Rating = 4

                    },

                    new Sponge
                    {
                        Company = "Purery",
                        Colour = "Maroon",
                        Shape = "Tringle",
                        ReleaseDate = DateTime.Parse("1950-09-18"),
                        Price = 7.8M,
                        Rating = 3

                    },

                    new Sponge
                    {
                        Company = "Bathio",
                        Colour = "Blue",
                        Shape = "Oval",
                        ReleaseDate = DateTime.Parse("1960-07-13"),
                        Price = 2M,
                        Rating = 4

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
