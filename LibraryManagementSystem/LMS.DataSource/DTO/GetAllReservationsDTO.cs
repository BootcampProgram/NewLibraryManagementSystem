using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetAllReservationsDTO
    {
        public int DetailID { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public string Status { get; set; }

        public string Shelve { get; set; }

        public string CoverImage { get; set; }

        public int StudentId { get; set; }

        public string studentFullName { get; set; }

        public string Grade { get; set; }
    }
}
