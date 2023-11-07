using WebAPI.Domains.DTOs;

namespace WebAPI.Domains.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
