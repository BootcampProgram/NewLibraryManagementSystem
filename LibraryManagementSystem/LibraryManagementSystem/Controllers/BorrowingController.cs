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
    [Route("api/borrowing")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        IBorrowingInterface _borrowingRepo;

        public BorrowingController(IBorrowingInterface repo)
        {
            _borrowingRepo = repo;
        }

        [HttpGet("all")]
        public IActionResult GetAllBorrowings()
        {
            //check records of status = expired or not
            //if expired change the status to expired

            var borrowings = _borrowingRepo.GetAllBorrowings();
            return Ok(borrowings);
        }


        [HttpGet("student/{studentID}")]
        public IActionResult GetAllBorrowingsByStudentIDCon(int studentID)
        {
            if(studentID <= 0)
            {
                return BadRequest();
            }
            var borrowing = _borrowingRepo.GetAllBorrowingsByStudentID(studentID);
            return Ok(borrowing);
        }

        [HttpGet("{borrowingID}")]
        public IActionResult GetBorrowingByID(int borrowingID)
        {
            var borrowing = _borrowingRepo.GetBorrowingByID(borrowingID);
            return Ok(borrowing);
        }

        [HttpGet("book/{boookID)}")]
        public IActionResult GetBorrowingByBookID(int boookID)
        {
            var borrowing = _borrowingRepo.GetBorrowingByBookID(boookID);
            return Ok(borrowing);
        }

        [HttpGet("example/{studentID}")]
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