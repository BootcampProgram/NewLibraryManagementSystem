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
    [Route("api/BookIdentification")]
    [ApiController]
    public class BookIdentificationController : ControllerBase
    {
        IBookIdentificationInterface _bookIdentificationRepo;

        public BookIdentificationController(IBookIdentificationInterface repo)
        {
            _bookIdentificationRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllBookIdentifications()
        {
            var bookIdentifications = _bookIdentificationRepo.GetAllBookIdentifications();
            return Ok(bookIdentifications);
        }

        [HttpGet("{bookID}")]
        public IActionResult GetBookIdentificationByID(int bookID)
        {
            var bookIdentification = _bookIdentificationRepo.GetBookIdentificationByID(bookID);
            return Ok(bookIdentification);
        }

        [HttpGet("new/{detailID}")]
        public IActionResult GetNewGeneratedBookID(int detailID)
        {
            var GeneratedId = _bookIdentificationRepo.GetGeneratedBookIdByDetailID(detailID);
            return Ok(GeneratedId);
        }

        [HttpPost("New")]
        public IActionResult CreateBookIdentification([FromBody] BookIdentification newBookIdentification)
        {
            _bookIdentificationRepo.CreateBookIdentification(newBookIdentification);
            return Ok();
        }

        [HttpPut("Update/{bookID}")]
        public IActionResult UpdateBookIdentification(int bookID, [FromBody] BookIdentification bookIdentificationObject)
        {
            if (bookID < 0)
            {
                return BadRequest();
            }

            int update = _bookIdentificationRepo.UpdateBookIdentification(bookID, bookIdentificationObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpDelete("Delete/{bookID}")]
        public IActionResult DeleteBookIdentification(int bookID)
        {
            if (bookID < 0)
            {
                return BadRequest();
            } 

            _bookIdentificationRepo.DeleteBookIdentification(bookID);

            return Ok();
        }
    }
}
