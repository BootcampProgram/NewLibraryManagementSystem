using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetBorrowingsHistoryDTO
    {
        public int BorrowingID { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string Title { get; set; }

        public string OverDuePayment { get; set; }
    }
}

