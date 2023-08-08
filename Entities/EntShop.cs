namespace Entities
{
    public class EntShop
    {
        public int shopid { get; set; }
        public int boid { get; set; }
        public string? city { get; set; }
        public string? area { get; set; }
        public string? location { get; set; }
        
        public string? phone { get; set; }
        public string? logurl { get; set; }
        public string? coverimageurl { get; set; }

        public bool isactive { get; set; }

        public string? businessdescription { get; set; }

    }
}