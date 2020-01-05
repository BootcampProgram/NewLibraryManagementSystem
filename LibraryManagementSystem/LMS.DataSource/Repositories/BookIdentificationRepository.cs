using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class BookIdentificationRepository : IBookIdentificationInterface
    {
        AppDbContext _appDbContext;

        public BookIdentificationRepository(AppDbContext repo)
        {
            _appDbContext = repo;
        }
        public void CreateBookIdentification(BookIdentification newBookIdentification)
        {
            _appDbContext.BookIdentification.Add(newBookIdentification);
            _appDbContext.SaveChanges();
        }

        public void DeleteBookIdentification(int bookID)
        {
            var bookIdentification = _appDbContext.BookIdentification.Where(c => c.BookID == bookID).SingleOrDefault();

            _appDbContext.BookIdentification.Remove(bookIdentification);
            _appDbContext.SaveChanges();
        }

        public ICollection<BookIdentification> GetAllBookIdentifications()
        {
            var bookIdentifications = _appDbContext.BookIdentification.ToList();
            return bookIdentifications;
        }

        public BookIdentification GetBookIdentificationByID(int bookID)
        {
            var bookIdentification = _appDbContext.BookIdentification.Where(c => c.BookID == bookID).SingleOrDefault();
            return bookIdentification;
        }

        public int GetGeneratedBookIdByDetailID(int detailID)
        {
            var isFound = _appDbContext.BookIdentification.Where(c => c.DetailID == detailID).FirstOrDefault();
            if(isFound == null)
            {
                return 0;
            }
            else
            {
                var generatedBookId = _appDbContext.BookIdentification.Where(c => c.DetailID == detailID).Max(s => s.BookID);
                return generatedBookId;
            }
        }

        public int UpdateBookIdentification(int bookID, BookIdentification bookIdentificationObject)
        {
            var bookIdentification = _appDbContext.BookIdentification.Where(c => c.BookID == bookID).SingleOrDefault();

            if (bookID == 0)
            {
                return 0;
            }
            else
            {
                bookIdentification.Status = bookIdentificationObject.Status;
                bookIdentification.DetailID = bookIdentificationObject.DetailID;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
