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

        public int BlockStudent(int id, Student studentObject)
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> GetAllStudents()
        {
            var students = _appDbContext.Student.ToList();
            return students;
        }

        public Student GetStudentByAttribute(int ID)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByID(int ID)
        {
            var student = _appDbContext.Student.Where(c => c.StudentId == ID).SingleOrDefault();
            return student;
        }

        public int ResetPassword(int ID, Student studentObject)
        {
            var ResetStudentPassword = (from _Student in _appDbContext.Student
                                        join _User in _appDbContext.User
                                        on _Student.StudentId equals _User.UserID
                                        where _User.UserID == ID
                                        select _User).ToList();
        }
    }
}
