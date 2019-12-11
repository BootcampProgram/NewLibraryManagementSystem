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
        ICollection<Student> GetAllStudents();

        Student GetStudentByID(int ID);

        Student GetStudentByAttribute(int ID);

        int BlockStudent(int id, Student studentObject);

        int ResetPassword(int id, Student studentObject);
    }
}
