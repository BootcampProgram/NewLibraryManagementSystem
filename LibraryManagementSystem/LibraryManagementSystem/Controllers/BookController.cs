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
    //$Created on : 11/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookInterface _bookRepo;

        public BookController(IBookInterface bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var book = _bookRepo.GetAllBooks();
            return Ok(book);
        }

        [HttpGet("{id}")]

        public IActionResult GetBookById(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var book = _bookRepo.GetBookByBookID(id);
            return Ok(book);
        }

        [HttpPost]

        public IActionResult CreateBook([FromBody] BookDetail newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(newObj == null)
            {
                return BadRequest();
            }

            _bookRepo.CreateBook(newObj);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] BookDetail newObj)
        {
            if(id < 0)
            {
                return BadRequest();
            }

            int result = _bookRepo.UpdateBook(id,newObj);
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

        public IActionResult DeleteBook(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _bookRepo.DeleteBook(id);

            return Ok();
        }
    }
}