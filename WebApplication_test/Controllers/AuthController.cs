using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;
using WebAPI.Domains.Model.EmployeeAggregate;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "pablo" || password == "123")
            {
                var token = TokenService.generate_token(new Employee());
                return Ok(token);
            }

            return BadRequest("Username or password invalid");
        }
    }
}
