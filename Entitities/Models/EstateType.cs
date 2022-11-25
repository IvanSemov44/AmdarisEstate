

namespace Entities.Models
{
    public class EstateType
    {
        public Guid EstateTypeId { get; set; }

        public string? TypeName { get; set; }

        public ICollection<Estate>? Estates { get; set; }
    }
}
