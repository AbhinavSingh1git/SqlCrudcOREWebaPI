
using AutoMapper;
using EmployeeWebApi.Dtos;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreatedto, Employee>();
            CreateMap<EmployeeUpdatedto, Employee>();
            CreateMap<Employee, EmployeeUpdatedto>();
        }

    }
}