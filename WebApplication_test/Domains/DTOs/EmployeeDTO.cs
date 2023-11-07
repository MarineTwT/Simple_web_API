using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebAPI.Domains.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string? Photo { get; set; }
    }
}
