using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  10/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public interface IStudentInterface
    {
        ICollection<GetAllStudentsDTO> GetAllStudents();

        Student GetStudentByID(int studentID);

        ICollection<Student> GetStudentsByAttribute(string Attribute);

        int BlockStudent(int studentID);

        int ResetPassword(int studentID);
    }
}
