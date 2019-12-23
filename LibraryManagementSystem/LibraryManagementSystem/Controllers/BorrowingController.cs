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
    [Route("api/Borrowing")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        IBorrowingInterface _borrowingRepo;

        public BorrowingController(IBorrowingInterface repo)
        {
            _borrowingRepo = repo;
        }

        [HttpGet("History")]
        public IActionResult GetBorrowingsHistory()
        {
            var borrowings = _borrowingRepo.GetBorrowingsHistory();
            return Ok(borrowings);
        }

        [HttpGet("Present")]
        public IActionResult GetPresentBorrowings()
        {
            var borrowings = _borrowingRepo.GetPresentBorrowings();
            return Ok(borrowings);
        }

        [HttpGet("{borrowingID}")]
        public IActionResult GetBorrowingByID(int borrowingID)
        {
            var borrowing = _borrowingRepo.GetBorrowingByID(borrowingID);
            return Ok(borrowing);
        }

        [HttpGet("{boookID)}")]
        public IActionResult GetBorrowingByBookID(int boookID)
        {
            var borrowing = _borrowingRepo.GetBorrowingByBookID(boookID);
            return Ok(borrowing);
        }

        [HttpGet("{studentID)}")]
        public IActionResult GetBorrowingByStudentID(int studentID)
        {
            var borrowing = _borrowingRepo.GetBorrowingByStudentID(studentID);
            return Ok(borrowing);
        }

        [HttpPut("Update/{borrowingID}")]
        public IActionResult UpdateBorrowing(int borrowingID, [FromBody] Borrowing borrowingObject)
        {
            if (borrowingID < 0)
            {
                return BadRequest();
            }

            int update = _borrowingRepo.UpdateBorrowing(borrowingID, borrowingObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

    }
}