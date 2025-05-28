using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Automapper cannot automatically map properties with different names,
            // so we need to specify the mapping explicitly.
            CreateMap<LeaveType, IndexVM>()
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
        }
    }
}