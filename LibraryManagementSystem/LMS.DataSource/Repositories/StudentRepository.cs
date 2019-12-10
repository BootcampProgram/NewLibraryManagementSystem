using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class StudentRepository : IStudentInterface
    {
        AppDbContext appDbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public int BlockStudent(int id, Student studentObject)
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public ICollection<Borrowing> GetBorrowingsByStudentId(int ID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Payment> GetPaymentsByStudentId(int ID)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByAttribute(int ID)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByID(int ID)
        {
            throw new NotImplementedException();
        }

        public int ResetPassword(int id, Student studentObject)
        {
            throw new NotImplementedException();
        }
    }
}
