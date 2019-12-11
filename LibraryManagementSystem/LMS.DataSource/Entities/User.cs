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

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Maximum 10 Characters Accepted")]
        [MinLength(7, ErrorMessage = "Minimum 7 Characters Needed")]
        public string Password { get; set; }

        [Required]
        public char Role { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
