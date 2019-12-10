using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DataSource.Entities
{
    //-----------------------------------------------------------------
    //$Developer : Shazir Shafeeque
    //$Created on : 08/12/2019
    //$Mobile No : 077-0079872
    //$Email : soozu082@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public class Librarian
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibrarianID { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        public string ContactNo { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public int JobEnrolled { get; set; }
        public string Image { get; set; }
    }
}
