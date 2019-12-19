using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetPresentBorrowingsDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public Double Payments { get; set; }
    }
}
