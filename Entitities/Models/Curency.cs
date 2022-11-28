namespace Entities.Models
{
    public class Curency
    {
        public Guid CurencyId { get; set; }

        public string? CurencyName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
    }
}
