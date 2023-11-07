using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domains.Model.EmployeeAggregate
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string? Photo { get; private set; }

        public Employee(string Name, int Age, string Photo)
        {
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Age = Age;
            this.Photo = Photo;
        }

        public Employee()
        {
        }
    }
}
