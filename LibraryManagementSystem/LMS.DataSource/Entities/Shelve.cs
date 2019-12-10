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
    public class Shelve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelveID { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
