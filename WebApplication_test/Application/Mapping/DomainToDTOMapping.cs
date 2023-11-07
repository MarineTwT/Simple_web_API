using AutoMapper;
using WebAPI.Domains.DTOs;
using WebAPI.Domains.Model.EmployeeAggregate;

namespace WebAPI.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.Name));
        }
    }
}
