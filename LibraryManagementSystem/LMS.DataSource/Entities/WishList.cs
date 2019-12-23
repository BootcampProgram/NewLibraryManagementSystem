using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DataSource.Entities
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  10/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------

    public class WishList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID { get; set; }

        [ForeignKey("StudentID")]
        public Student ParentStudentID { get; set; }
        public int StudentID { get; set; }

        [ForeignKey("DetailID")]
        public BookDetail ParentBookDetail { get; set; }
        public int DetailID { get; set; }
    }
}
