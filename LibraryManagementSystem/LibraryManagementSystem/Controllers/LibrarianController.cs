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
    [Route("api/Librarian")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        ILibrarianInterface _librarianRepo;

        public LibrarianController(ILibrarianInterface repo)
        {
            _librarianRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllLibrarians()
        {
            var librarians = _librarianRepo.GetAllLibrarians();
            return Ok(librarians);
        }

        [HttpGet("{librarianID}")]
        public IActionResult GetLibrarianByID(int librarianID)
        {
            var librarian = _librarianRepo.GetLibrarianByID(librarianID);
            return Ok(librarian);
        }

        [HttpPost("New")]
        public IActionResult CreateLibrarian([FromBody] Librarian newLibrarian)
        {
            _librarianRepo.CreateLibrarian(newLibrarian);
            return Ok();
        }

        [HttpPut("Update/{librarianID}")]
        public IActionResult UpdateLibrarian(int librarianID, [FromBody] Librarian librarianObject)
        {
            if (librarianID < 0)
            {
                return BadRequest();
            }

            int update = _librarianRepo.UpdateLibrarian(librarianID, librarianObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpPut("Reset/{librarianID}")]
        public IActionResult ResetPassword(int librarianID)
        {
            var librarian = _librarianRepo.ResetPassword(librarianID);

            if (librarian == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpDelete("Delete/{librarianID}")]
        public IActionResult DeleteLibrarian(int librarianID)
        {
            if (librarianID < 0)
            {
                return BadRequest();
            }

            _librarianRepo.DeleteLibrarian(librarianID);

            return Ok();
        }
    }
}