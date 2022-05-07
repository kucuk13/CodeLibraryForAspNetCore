using AutoMapper;

namespace AutoMapperExample.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDao, EmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("d MMMM yyyy")))
                .ForMember(dest => dest.Manager, opt => opt.Ignore());
        }
    }
}
