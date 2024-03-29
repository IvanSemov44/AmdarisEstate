﻿namespace IvanRealEstate.Shared.DataTransferObject.Estate
{
    using IvanRealEstate.Shared.DataTransferObject.Image;

    public record EstateDto
    {
        public Guid OwnerId { get; init; }
        public Guid EstateId { get; init; }
        public string? Neighborhood { get; init; }
        public string? Address { get; init; }
        public string? Description { get; init; }
        public int YearOfCreation { get; init; }
        public double Price { get; init; }
        public int Floor { get; init; }
        public int Rooms { get; init; }
        public string? Extras { get; init; }
        public bool Sell { get; init; }
        public double? EstateArea { get; set; }
        public DateTime? Created { get; init; }
        public DateTime? Changed { get; init; }
        public Guid CityId { get; init; }
        public Guid CurencyId { get; init; }
        public Guid CountryId { get; init; }
        public Guid EstateTypeId { get; init; }
        public IEnumerable<ImageDto>? Images { get; set; }

    }
}
