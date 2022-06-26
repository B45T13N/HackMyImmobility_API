using Microsoft.EntityFrameworkCore;

namespace HackMyImmobility_API.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {
                // Look for any movies.
                if (context.Flats.Any())
                {
                    return;   // DB has been seeded
                }

                context.Flats.AddRange(
                    new Flat
                    {
                        easeWheelchair = true,
                        easeBlind =true,
                        easePartiallyBlind =true,
                        easeDeaf =true,
                        easeMental =true,
                        easeElderlyPeople =true,
                        easeAmputee =true,
                        easeCare =true,
                        easeDoctor = true,
                        easeMarket = true,
                        email = "@",
                        url = "de",
                        description = "dheo",
                        address = "Villejuif",
                        lat = 48.7934205,
                        lng = 2.3531731,
                    },

                    new Flat
                    {
                        easeWheelchair = true,
                        easeBlind = true,
                        easePartiallyBlind = true,
                        easeDeaf = true,
                        easeMental = true,
                        easeElderlyPeople = true,
                        easeAmputee = true,
                        easeCare = true,
                        easeDoctor = true,
                        easeMarket = true,
                        email = "@",
                        url = "de",
                        description = "dheo",
                        address = "Montgeron",
                        lat = 48.6952329,
                        lng = 2.4287385,
                    },

                    new Flat
                    {
                        easeWheelchair = true,
                        easeBlind = true,
                        easePartiallyBlind = true,
                        easeDeaf = true,
                        easeMental = true,
                        easeElderlyPeople = true,
                        easeAmputee = true,
                        easeCare = true,
                        easeDoctor = true,
                        easeMarket = true,
                        email = "@",
                        url = "de",
                        description = "dheo",
                        address = "Vitry sur seine",
                        lat = 48.7892899,
                        lng = 2.3775506,
                    },

                    new Flat
                    {
                        easeWheelchair = true,
                        easeBlind = true,
                        easePartiallyBlind = true,
                        easeDeaf = true,
                        easeMental = true,
                        easeElderlyPeople = true,
                        easeAmputee = true,
                        easeCare = true,
                        easeDoctor = true,
                        easeMarket = true,
                        email = "@",
                        url = "de",
                        description = "dheo",
                        address = "30 Rue de la montage 52200 Villefranche",
                        lat = 30.000,
                        lng = 40.000,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
