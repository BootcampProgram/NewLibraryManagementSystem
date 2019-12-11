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


        [HttpGet("{ID}")]
        public IActionResult GetStudentByID(int ID)
        {
            var student = _studentRepo.GetStudentByID(ID);
            return Ok(student);
        }

        [HttpPut("{ID}/User")]
        public IActionResult ResetPassword(int ID)
        {
            var ResetStudentPassword = _studentRepo.ResetPassword(ID);
            return Ok(ResetStudentPassword);
        }
    }
}