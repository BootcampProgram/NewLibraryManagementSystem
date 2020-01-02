using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetAllBorrowingsByStudentIdDTO
    {
        public int BorrowingId { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookDetailID { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }
    }
}
