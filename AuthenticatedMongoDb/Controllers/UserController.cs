using AuthenticatedMongoDb.Models;
using AuthenticatedMongoDb.Repositories;
using AuthenticatedMongoDb.Services;
using AuthenticatedMongoDb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticatedMongoDb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestViewModel request)
        {
            var user = _userRepository.GetByUsername(request.Username);

            if(user != null && user.Password == request.Password)
            {
                var token = _authenticationService.GenerateBearerToken(user);
                return Ok(token);
            }

            return Unauthorized("Wrong username or password");
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRequestViewModel request)
        {
            User newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Role = request.Role,
                Username = request.Username,
                PrimaryAddress = new Address
                {
                    State = request.State,
                    StreetAddress = request.StreetAddress,
                    City = request.City,
                    ZipCode = request.ZipCode
                }
            };

            _userRepository.InsertRecord(newUser);

            return Ok(request);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetSenstiveData()
        {
            return Ok(new { 
                Message = "Access as Admin Granted",
                Payload = _userRepository.GetAll()
            });;
        }
    }
}
