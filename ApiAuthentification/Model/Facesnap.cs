namespace ApiAuthentification.Model
{
    public class Facesnap
    {   
        public Guid id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public int snaps { get; set; }
        public string? location { get; set; }

        public DateTime? createdAt { get; set; }
    }
}
