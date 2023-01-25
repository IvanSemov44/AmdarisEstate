namespace IvanRealEstate.Entities.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Text { get; set; }

        public bool? IsRead { get; set; }

        public DateTime? Created { get; set; }

        public Guid OwnerId { get; set; }
        public User? User { get; set; }
    }
}
