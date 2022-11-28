

namespace IvanRealEstate.Shared.DataTransferObject.EstateType
{
    public record EstateTypeDto
    {
        public Guid EstateTypeId { get; init; }

        public string? TypeName { get; init; }

    }
}
