using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetAllBooksDetailDTO
    {
        public int DetailID { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string ShelveCode { get; set; }

        public string Availability { get; set; }
    }
}
