using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  10/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public class StudentRepository : IStudentInterface
    {
        AppDbContext _appDbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public int BlockStudent(int studentID)
        {
            var student = (from _Student in _appDbContext.Student
                           join _User in _appDbContext.User
                           on _Student.StudentId equals _User.RoleID
                           where _User.Role == 's' && _User.RoleID == studentID
                           select _User).FirstOrDefault();

            if (student == null)
            {
                return 0;
            }
            else
            {
                student.Status = false;

                _appDbContext.SaveChanges();

                return 1;
            }
        }

        public ICollection<GetAllStudentsDTO> GetAllStudents()
        {
            //var students = _appDbContext.Student.ToList();

            var students = (from _students in _appDbContext.Student
                            select new GetAllStudentsDTO { StudentId = _students.StudentId, 
                                FullName = _students.FirstName +" "+ _students.LastName}).ToList();
            return students;
        }

        public ICollection<Student> GetStudentsByAttribute(string Attribute)
        {
            var Students = _appDbContext.Student.Where(c => c.StudentId.ToString().Contains(Attribute) 
                                                        || c.FirstName.Contains(Attribute) 
                                                        || c.LastName.Contains(Attribute) 
                                                        || c.DateOfBirth.ToString().Contains(Attribute) 
                                                        || c.Gender.Contains(Attribute) 
                                                        || c.Address.Contains(Attribute) 
                                                        || c.LandNo.Contains(Attribute) 
                                                        || c.ParentMobileNo.Contains(Attribute) 
                                                        || c.Grade.ToString().Contains(Attribute) 
                                                        || c.Section.ToString().Contains(Attribute) 
                                                        || c.Medium.Contains(Attribute)).ToList();
            return Students;
        }

        public Student GetStudentByID(int studentID)
        {
            var student = _appDbContext.Student.Where(c => c.StudentId == studentID).SingleOrDefault();
            return student;
        }

        public int ResetPassword(int studentID)
        {
            var Student = (from _Student in _appDbContext.Student
                           join _User in _appDbContext.User
                           on _Student.StudentId equals _User.RoleID
                           where _User.Role == 's' && _User.RoleID == studentID
                           select _User).FirstOrDefault();

            if(Student == null)
            {
                return 0;
            }
            else
            {
                Student.Password = "LMS@123";

                _appDbContext.SaveChanges();

                return 1;
            }

            
        }
    }
}
