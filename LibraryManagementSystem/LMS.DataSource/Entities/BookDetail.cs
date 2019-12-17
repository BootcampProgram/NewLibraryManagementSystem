using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DataSource.Entities
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  09/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------

    public class BookDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailID { get; set; }

        [Required]
        public string ISBN { get; set; }


        [Required]
        public string Title { get; set; }

        public string Year { get; set; }

        public string Language { get; set; }

        public double Price { get; set; }

        //public string CoverImage { get; set; }

        [ForeignKey("PublisherID")]
        public Publisher ParentPublisher { get; set; }
        public int PublisherID { get; set; }


        [ForeignKey("GenreID")]
        public Genre ParentGenre { get; set; }
        public int GenreID { get; set; }


        [ForeignKey("ShelveID")]
        public Shelve ParentShelve { get; set; }
        public int ShelveID { get; set; }


    }
}
