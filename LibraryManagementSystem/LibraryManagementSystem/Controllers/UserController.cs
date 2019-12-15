using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserInterface _userRepo;

        public UserController(IUserInterface repo)
        {
            _userRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userID}")]
        public IActionResult GetUserByID(int userID)
        {
            var user = _userRepo.GetUserByID(userID);
            return Ok(user);
        }

        [HttpPost("New")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            _userRepo.CreateUser(newUser);
            return Ok();
        }

        [HttpPut("Update/{userID}")]
        public IActionResult UpdateUser(int userID, [FromBody] User userObject)
        {
            if (userID < 0)
            {
                return BadRequest();
            }

            int update = _userRepo.UpdateUser(userID, userObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpPut("Reset/{userID}")]
        public IActionResult ResetPassword(int userID)
        {
            var user = _userRepo.ResetPassword(userID);

            if (user == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpDelete("Delete/{userID}")]
        public IActionResult DeleteUser(int userID)
        {
            if (userID < 0)
            {
                return BadRequest();
            }

            _userRepo.DeleteUser(userID);

            return Ok();
        }
    }

}