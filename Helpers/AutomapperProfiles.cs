using AutoMapper;
using WebAPIForHousing.Dtos;
using WebAPIForHousing.Models;

namespace WebAPIForHousing.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();


        }
    }
}
