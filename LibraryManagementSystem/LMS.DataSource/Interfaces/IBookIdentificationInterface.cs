using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IBookIdentificationInterface
    {

        ICollection<BookIdentification> GetAllBookIdentifications();

        BookIdentification GetBookIdentificationByID(int bookID);

        void CreateBookIdentification(BookIdentification newBookIdentification);

        int UpdateBookIdentification(int bookID, BookIdentification bookIdentificationObject);

        void DeleteBookIdentification(int bookID);
    }
}
