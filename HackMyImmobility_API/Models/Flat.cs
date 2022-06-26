namespace HackMyImmobility_API.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public Boolean easeWheelchair { get; set; }
        public Boolean easeBlind { get; set; }
        public Boolean easePartiallyBlind{ get; set; }
        public Boolean easeDeaf { get; set; }
        public Boolean easeMental { get; set; }
        public Boolean easeElderlyPeople { get; set; }
        public Boolean easeAmputee { get; set; }
        public Boolean easeCare { get; set; }
        public Boolean easeDoctor { get; set; }
        public Boolean easeMarket { get; set; }
        public String email { get; set; }
        public String url { get; set; }
        public String description { get; set; }
        public String address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }

        public override string ToString() {
            return $"";
        }
    }

    
}
