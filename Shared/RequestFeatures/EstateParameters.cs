namespace IvanRealEstate.Shared.RequestFeatures
{
    public class EstateParameters : RequestParameters
    {
        public uint MinYear { get; set; }
        public uint MaxYear { get; set; } = int.MaxValue;

        public Guid? City { get; set; }
        public string SearchTerm { get; set; }

        public bool ValidYearRange => MaxYear > MinYear;
    }
}
