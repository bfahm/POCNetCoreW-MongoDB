using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticatedMongoDb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticatedMongoDb.Controllers
{
    /// <summary>
    /// This controller contains method to access sensitive data that's only available to an adminstrator..
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(new
            {
                Message = "Access as Admin Granted",
                Payload = _userRepository.GetAll()
            });
        }

        [HttpDelete]
        public IActionResult DeleteUser(string userId)
        {
            var toBeDeleted = _userRepository.GetById(new Guid(userId));
            if (toBeDeleted != null)
            {
                _userRepository.DeleteById(new Guid(userId));

                return Ok(new
                {
                    Message = "Access as Admin Granted",
                    Payload = $"Account '{toBeDeleted.Username}' Deleted Successfully.."
                });
            }

            return NotFound(new
            {
                Message = "Access as Admin Granted",
                Payload = "Specified user was not found."
            });
        }

        [HttpDelete]
        public IActionResult DeleteAllUsers()
        {
            _userRepository.DeleteAll();
            return Ok(new
            {
                Message = "Access as Admin Granted",
                Payload = "All users where deleted, you need to create a new account."
            });
        }
    }
}
