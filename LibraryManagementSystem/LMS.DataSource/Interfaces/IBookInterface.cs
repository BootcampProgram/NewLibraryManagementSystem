using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 11/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public interface IBookInterface
    {
        ICollection<GetAllBooksDetailDTO> GetAllBooks();

        BookIdentification GetBookByBookID(int i);

        void CreateBook(BookDetail BookObject);

        int UpdateBook(int id, BookDetail BookObject);

        void DeleteBook(int id);
    }
}
