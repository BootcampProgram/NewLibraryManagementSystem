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
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 13/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorInterface _authorRepo;

        public AuthorController(IAuthorInterface authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var author = _authorRepo.GetAllAuthors();
            return Ok(author);
        }

        [HttpGet("{id}")]

        public IActionResult GetAuthorById(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var author = _authorRepo.GetByAuthorId(id);
            return Ok(author);
        }

        [HttpPost]

        public IActionResult CreateAuthor([FromBody] Author newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newObj == null)
            {
                return BadRequest();
            }

            _authorRepo.CreateAuthor(newObj);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateAuthor(int id, [FromBody] Author newObj)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            int result = _authorRepo.UpdateAuthor(id, newObj);
            if (result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeletAuthor(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _authorRepo.DeleteAuthor(id);

            return Ok();
        }





    }
}