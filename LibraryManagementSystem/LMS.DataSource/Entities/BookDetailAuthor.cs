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
    public class BookDetailAuthor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("DetailID")]
        public BookDetail ParentDeatilID { get; set; }
        public int DetailID { get; set; }

        [ForeignKey("AuthorId")]
        public Author ParentAuthorId { get; set; }
        public int AuthorId { get; set; }
    }
}
