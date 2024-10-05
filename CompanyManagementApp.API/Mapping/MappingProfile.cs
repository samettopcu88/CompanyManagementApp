using AutoMapper;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO
            CreateMap<Company, CompanyDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<AppRole, AppRoleDTO>();
            CreateMap<AppUser, AppUserDTO>();
            CreateMap<ExpenseRequest, ExpenseRequestDTO>();
            CreateMap<LeaveRequest, LeaveRequestDTO>();
            CreateMap<Notification, NotificationDTO>();
            CreateMap<Resume, ResumeDTO>();

            // DTO -> Entity
            CreateMap<CompanyDTO, Company>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<AppRoleDTO, AppRole>();
            CreateMap<AppUserDTO, AppUser>();
            CreateMap<ExpenseRequestDTO, ExpenseRequest>();
            CreateMap<LeaveRequestDTO, LeaveRequest>();
            CreateMap<NotificationDTO, Notification>();
            CreateMap<ResumeDTO, Resume>();
        }
    }
}
