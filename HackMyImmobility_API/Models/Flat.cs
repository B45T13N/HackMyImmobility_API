namespace HackMyImmobility_API.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public Boolean EaseWheelchair { get; set; }
        public Boolean EaseBlind { get; set; }
        public Boolean EasePartiallyBlind{ get; set; }
        public Boolean EaseDeaf { get; set; }
        public Boolean EaseMental { get; set; }
        public Boolean EaseElderlyPeople { get; set; }
        public Boolean EaseAmputee { get; set; }
        public Boolean EaseCare { get; set; }
        public Boolean EaseDoctor { get; set; }
        public Boolean EaseMarket { get; set; }
        public Boolean EaseTransport { get; set; }
        public String Email { get; set; }
        public String URL { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public override string ToString() {
            return $"";
        }
    }

    
}
