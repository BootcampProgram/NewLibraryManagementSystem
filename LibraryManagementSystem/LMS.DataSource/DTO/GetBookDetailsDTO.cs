using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.DTO
{
    public class GetBookDetailsDTO
    {
        public string CoverImage { get; set; }
        public string Title { get; set; }
        public ICollection<string> Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Shelve { get; set; }
        public string Language { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public ICollection<IndividualBookStatusDTO> Copies { get; set; }
    }
}
