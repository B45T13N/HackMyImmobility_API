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
                        EaseWheelchair = true,
                        EaseBlind =true,
                        EasePartiallyBlind =true,
                        EaseDeaf =true,
                        EaseMental =true,
                        EaseElderlyPeople =true,
                        EaseAmputee =true,
                        EaseCare =true,
                        EaseDoctor = true,
                        EaseMarket = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "Villejuif",
                        Lat = 48.7934205,
                        Lng = 2.3531731,
                    },

                    new Flat
                    {
                        EaseWheelchair = true,
                        EaseBlind = true,
                        EasePartiallyBlind = true,
                        EaseDeaf = true,
                        EaseMental = true,
                        EaseElderlyPeople = true,
                        EaseAmputee = true,
                        EaseCare = true,
                        EaseDoctor = true,
                        EaseMarket = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "Montgeron",
                        Lat = 48.6952329,
                        Lng = 2.4287385,
                    },

                    new Flat
                    {
                        EaseWheelchair = true,
                        EaseBlind = true,
                        EasePartiallyBlind = true,
                        EaseDeaf = true,
                        EaseMental = true,
                        EaseElderlyPeople = true,
                        EaseAmputee = true,
                        EaseCare = true,
                        EaseDoctor = true,
                        EaseMarket = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "Vitry sur seine",
                        Lat = 48.7892899,
                        Lng = 2.3775506,
                    },

                    new Flat
                    {
                        EaseWheelchair = true,
                        EaseBlind = true,
                        EasePartiallyBlind = true,
                        EaseDeaf = true,
                        EaseMental = true,
                        EaseElderlyPeople = true,
                        EaseAmputee = true,
                        EaseCare = true,
                        EaseDoctor = true,
                        EaseMarket = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "30 Rue de la montage 52200 Villefranche",
                        Lat = 30.000,
                        Lng = 40.000,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
