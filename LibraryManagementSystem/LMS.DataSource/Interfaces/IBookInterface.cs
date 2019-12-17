using System;
﻿using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    interface IBookInterface
    {
        ICollection<BookDetail> GetAllBooks();

        BookIdentification GetBookByBookID(int i);

        void CreateBook(BookDetail BookObject);

        int UpdateBook(int id, BookDetail BookObject);

        void DeleteBook(int id);
    }
}
