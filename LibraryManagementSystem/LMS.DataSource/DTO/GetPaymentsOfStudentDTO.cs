using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetPaymentsOfStudentDTO
    {
        public int BorrowingId { get; set; }
        public DateTime ReturnDate { get; set; }
        public double DuePayment { get; set; }
    }
}
