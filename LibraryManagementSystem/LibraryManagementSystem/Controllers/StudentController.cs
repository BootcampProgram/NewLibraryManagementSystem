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
    //$Developer                :  Iresha Silva
    //$Created on               :  11/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentInterface _studentRepo;

        public StudentController(IStudentInterface repo)
        {
            _studentRepo = repo;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentRepo.GetAllStudents();
            return Ok(students);
        }


        [HttpGet("{studentID}")]
        public IActionResult GetStudentByID(int studentID)
        {
            var student = _studentRepo.GetStudentByID(studentID);
            return Ok(student);
        }

        [HttpPut("reset/{studentID}")]
        public IActionResult ResetPassword(int studentID)
        {
            var successReset = _studentRepo.ResetPassword(studentID);

            if(successReset == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("block/{studentID}")]
        public IActionResult BlockUser(int studentID)
        {
            var successBlock = _studentRepo.BlockStudent(studentID);

            if(successBlock == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpPut("unblock/{studentID}")]
        public IActionResult UnblockUser(int studentID)
        {
            var successUnblock = _studentRepo.UnblockStudent(studentID);

            if (successUnblock == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpGet("Attribute/{Attribute}")]
        public IActionResult GetStudentsByAttribute(string Attribute)
        {
            var students = _studentRepo.GetStudentsByAttribute(Attribute);
            return Ok(students);
        }
    }
}