namespace IvanRealEstate.Shared.RequestFeatures
{
    public class EstateParameters : RequestParameters
    {
        public EstateParameters() => OrderBy = "created";

        public bool? Sell { get; set; }

        public uint MinYear { get; set; }
        public uint MaxYear { get; set; } = int.MaxValue;

        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;

        public uint MinRooms { get; set; }
        public uint MaxRooms { get; set; } = int.MaxValue;

        public uint MinFloor { get; set; }
        public uint MaxFloor { get; set; } = int.MaxValue;

        public uint MinArea { get; set; }
        public uint MaxArea { get; set; } = int.MaxValue;


        public Guid? City { get; set; }
        public Guid? Country { get; set; }
        public Guid? Currency { get; set; }
        public Guid? EstateType { get; set; }
        public Guid? OwnerId { get; set; }

        public string SearchTerm { get; set; }

        public bool ValidYearRange => MaxYear > MinYear;
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public bool ValidRoomsRange => MaxRooms > MinRooms;
        public bool ValidFloorRange => MaxFloor > MinFloor;
        public bool ValidAreaRange => MaxArea > MinArea;
    }
}
