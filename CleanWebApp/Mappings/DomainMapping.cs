using System.Linq;
using AutoMapper;
using CA.Domain.Employees;
using CA.Domain.EmployeeTypes;
using CA.WebApp.ViewModels;

namespace CleanWebApp.Mappings
{
    public class DomainMapping : Profile
    {
        public DomainMapping()
        {
            
            CreateMap<Employee, EmployeeViewModel>()
                 .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.EmployeeType.Id));


        }
    }
}
