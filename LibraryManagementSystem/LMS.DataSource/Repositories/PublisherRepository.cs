using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  13/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public class PublisherRepository : IPublisherInterface
    {
        AppDbContext _appDbContext;

        public PublisherRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public void CreatePublisher(Publisher newPublisher)
        {
            _appDbContext.Publisher.Add(newPublisher);
            _appDbContext.SaveChanges();

        }

        public void DeletePublisher(int publisherID)
        {
            var publisher = _appDbContext.Publisher.Where(c => c.PublisherID == publisherID).SingleOrDefault();

            _appDbContext.Publisher.Remove(publisher);
            _appDbContext.SaveChanges();
        }

        public ICollection<Publisher> GetAllPublishers()
        {
            var publishers = _appDbContext.Publisher.ToList();
            return publishers;
        }

        public Publisher GetPublisherByID(int publisherID)
        {
            var publisher = _appDbContext.Publisher.Where(c => c.PublisherID == publisherID).SingleOrDefault();
            return publisher;
        }

        public int UpdatePublisher(int publisherID, Publisher publisherObject)
        {
            var _updatePublisher = _appDbContext.Publisher.Where(c => c.PublisherID == publisherID).SingleOrDefault();

            if (publisherID == 0)
            {
                return 0;
            }
            else
            {
                _updatePublisher.Name = publisherObject.Name;
                _appDbContext.SaveChanges();
                return 1;
            }

        }
    }
}
