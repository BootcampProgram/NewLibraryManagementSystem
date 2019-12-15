using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
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
