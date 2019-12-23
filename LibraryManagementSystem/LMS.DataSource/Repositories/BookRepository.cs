using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 11/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public class BookRepository : IBookInterface
    {
        AppDbContext _appDbContext;

        public BookRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }
        public void CreateBook(BookDetail BookObject)
        {
            _appDbContext.BookDetail.Add(BookObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var Book = _appDbContext.BookDetail.Where(c => c.DetailID == id).SingleOrDefault();
            _appDbContext.BookDetail.Remove(Book);
            _appDbContext.SaveChanges();
        }

        public ICollection<GetAllBooksDetailDTO> GetAllBooks()
        {
            //var BookDetails = _appDbContext.BookDetail.ToList();

            var BookDetails = (from Book in _appDbContext.BookDetail
                               join Shelf in _appDbContext.Shelve
                               on Book.ShelveID equals Shelf.ShelveID
                               select new GetAllBooksDetailDTO { DetailID = Book.DetailID, Title = Book.Title, ISBN = Book.ISBN, ShelveCode = Shelf.Code, Availability = null }).ToList();

            foreach(GetAllBooksDetailDTO book in BookDetails)
            {
                var numberOfAvailableCopies = _appDbContext.BookIdentification.Where(c => c.DetailID == book.DetailID && c.Status == "1").Count();
                var numberOfAvailableCopyIDs = _appDbContext.BookIdentification.Where(c => c.DetailID == book.DetailID && c.Status == "1").ToList();

                if (numberOfAvailableCopies == 0)
                {
                    book.Availability = "Not Available";
                }
                else
                {
                    var totalReservationsCount = 0;
                    var totalBorrowingsCount = 0;
                    foreach (BookIdentification aBook in numberOfAvailableCopyIDs)
                    {
                        var reservationsCount = (from BookID in _appDbContext.BookIdentification
                                                 join Res in _appDbContext.Reservation
                                                 on BookID.BookID equals Res.BookID
                                                 where Res.BookID == aBook.BookID && Res.Status == "Active"
                                                 select Res).Count();
                        if(reservationsCount != 0)
                        {
                            totalReservationsCount += 1;
                        }

                        var borrowingsCount = (from BookID in _appDbContext.BookIdentification
                                               join Bor in _appDbContext.Borrowing
                                               on BookID.BookID equals Bor.BookID
                                               where Bor.BookID == aBook.BookID && Bor.Status == "B"
                                               select Bor).Count();
                        if (borrowingsCount != 0)
                        {
                            totalBorrowingsCount += 1;
                        }
                    }

                    int currentBookCount = numberOfAvailableCopies - (totalReservationsCount + totalBorrowingsCount);

                    if (currentBookCount == 0)
                    {
                        book.Availability = "No";
                    }
                    else
                    {
                        book.Availability = "Yes";
                    }
                }
            }

            return BookDetails;
        }

        public BookIdentification GetBookByBookID(int id)
        {
            var Book = _appDbContext.BookIdentification.Where(c => c.BookID == id).SingleOrDefault();
            return Book;
        }

        public int UpdateBook(int id, BookDetail BookObject)
        {
            var Book = _appDbContext.BookDetail.Where(c => c.DetailID == id).SingleOrDefault();
            if (Book == null)
            {
                return 0; //if Fails return 0
            }
            else
            {
                Book.ISBN = BookObject.ISBN;
                Book.Title = BookObject.Title;
                Book.Year = BookObject.Year;
                Book.Language = BookObject.Language;
                Book.Price = BookObject.Price;


                _appDbContext.SaveChanges();
                return 1; //if success return 1

            }
        }

    }
}
