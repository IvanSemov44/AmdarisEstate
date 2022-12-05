
namespace IvanRealEstate.Test.HandlersTests
{
    using AutoMapper;

    public static class MapperConfig
    {
        public static IMapper Configuration() =>
            new MapperConfiguration(e =>e.AddProfile<MappingProfile>()).CreateMapper();
    }
}
