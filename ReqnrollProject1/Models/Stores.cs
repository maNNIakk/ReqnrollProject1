namespace ReqnrollProject1.Models
{
    public class Stores
    {
        public string? StoreName { get; set; }
        public GeoLocation? Location { get; set; }

        public class StoreContext
        {
            public List<Stores>? StoresList { get; set; } = new List<Stores>();
        }

        public class GeoLocation
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
