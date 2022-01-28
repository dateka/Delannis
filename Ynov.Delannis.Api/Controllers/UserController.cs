using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ynov.Delannis.Application.UserAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions;

namespace Ynov.Delannis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) => _userService = userService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            try
            {
                await _userService.RegistrationAsync(dto.UserName, dto.Email, dto.Password);
                return Ok();
            }
            catch (DomainExceptionBase be)
            {
                return BadRequest(be.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
    }
}