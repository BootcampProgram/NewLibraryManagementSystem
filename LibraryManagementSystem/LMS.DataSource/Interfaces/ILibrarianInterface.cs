using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  15/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public interface ILibrarianInterface
    {
        ICollection<Librarian> GetAllLibrarians();

        Librarian GetLibrarianByID(int librarianID);

        void CreateLibrarian(Librarian newLibrarian);

        int UpdateLibrarian(int librarianID, Librarian librarianObject);

        int ResetPassword(int librarianID);

        void DeleteLibrarian(int librarianID);
    }
}
