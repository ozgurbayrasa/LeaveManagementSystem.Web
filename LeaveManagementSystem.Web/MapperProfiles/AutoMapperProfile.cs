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
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));

            // Mapping from LeaveTypeCreateVM to LeaveType.
            // Form data will be sent as LeaveType to the database.
            CreateMap<LeaveTypeCreateVM, LeaveType>();

            // I need to map for both ways. We need to use Reverse Map as well.
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();

        }
    }
}