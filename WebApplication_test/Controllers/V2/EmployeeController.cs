using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ViewModels;
using WebAPI.Domains.DTOs;
using WebAPI.Domains.Model.EmployeeAggregate;

namespace WebAPI.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("2.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filepath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream filestream = new FileStream(filepath, FileMode.Create);
            employeeView.Photo.CopyTo(filestream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filepath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult Download(int id)
        {
            var employee = _employeeRepository.Get(id);

            var databytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(databytes, "image/png");
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            //_logger.Log(LogLevel.Error, "Teve um erro");

            var employee = _employeeRepository.Get(pageNumber, pageQuantity);

            //_logger.LogInformation("Teste");

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employee = _employeeRepository.Get(id);
            var employeedto = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeedto);
        }
    }
}
