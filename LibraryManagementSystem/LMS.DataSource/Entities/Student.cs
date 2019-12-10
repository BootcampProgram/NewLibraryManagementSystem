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
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

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
        public string LandNo { get; set; }

        [Phone]
        public string ParentMobileNo { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public char Section { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        public int YearEnrolled { get; set; }
        public string Image { get; set; }
    }
}
