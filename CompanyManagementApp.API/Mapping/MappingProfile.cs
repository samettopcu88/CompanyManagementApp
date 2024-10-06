using AutoMapper;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity <-> DTO
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<ExpenseRequest, ExpenseRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<Resume, ResumeDTO>().ReverseMap();
        }
    }
}
