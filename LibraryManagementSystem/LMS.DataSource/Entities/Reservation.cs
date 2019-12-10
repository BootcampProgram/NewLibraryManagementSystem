using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DataSource.Entities
{
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 09/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        public DateTime DateReserved { get; set; }

        public string Shelve { get; set; }

        public string Status { get; set; }

        [ForeignKey("StudentId")]
        public Student ParentStudent { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("BookID")]
        public BookIdentification ParentBook { get; set; }
        public int BookID { get; set; }
    }
}
