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
                        EaseTransport = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "30 Rue de la montage 52200 Villefranche",
                        Lat = 30.000,
                        Lng = 40.000,
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
                        EaseTransport = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "30 Rue de la montage 52200 Villefranche",
                        Lat = 30.000,
                        Lng = 40.000,
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
                        EaseTransport = true,
                        Email = "@",
                        URL = "de",
                        Description = "dheo",
                        Address = "30 Rue de la montage 52200 Villefranche",
                        Lat = 30.000,
                        Lng = 40.000,
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
                        EaseTransport = true,
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
