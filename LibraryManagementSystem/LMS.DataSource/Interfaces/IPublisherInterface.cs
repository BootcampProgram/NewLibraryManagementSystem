using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IPublisherInterface
    {

        //-----------------------------------------------------------------
        //$Developer                :  Iresha Silva
        //$Created on               :  13/12/2019
        //$Mobile No                :  0778377630
        //$Email                    :  ireshasilva96@gmail.com
        //$Description (If Any)     : 
        //-----------------------------------------------------------------


        ICollection<Publisher> GetAllPublishers();

        Publisher GetPublisherByID(int publisherID);

        void CreatePublisher(Publisher newPublisher);

        int UpdatePublisher(int publisherID, Publisher publisherObject);

        void DeletePublisher(int publisherID);
    }
}
