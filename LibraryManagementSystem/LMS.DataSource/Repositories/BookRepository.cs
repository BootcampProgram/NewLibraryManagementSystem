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
            var Copies = _appDbContext.BookIdentification.Where(c => c.DetailID == id).ToList();
            _appDbContext.BookDetail.Remove(Book);
            foreach(BookIdentification record in Copies)
            {
                 _appDbContext.BookIdentification.Remove(record);
            }
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

        public GetBookDetailsDTO GetBookByBookID(int bookid)
        {
            var Book = (from bookDetail in _appDbContext.BookDetail
                        join publisher in _appDbContext.Publisher
                        on bookDetail.PublisherID equals publisher.PublisherID
                        join genre in _appDbContext.Genre
                        on bookDetail.GenreID equals genre.GenreID
                        join shelve in _appDbContext.Shelve
                        on bookDetail.ShelveID equals shelve.ShelveID
                        where bookDetail.DetailID == bookid
                        select new GetBookDetailsDTO
                        {
                            CoverImage = bookDetail.CoverImage,
                            Title = bookDetail.Title,
                            ISBN = bookDetail.ISBN,
                            Publisher = publisher.Name,
                            Genre = genre.Name,
                            Shelve = shelve.Code,
                            Language = bookDetail.Language,
                            Year = bookDetail.Year,
                            Price = bookDetail.Price
                        }).FirstOrDefault();

            if(Book != null)
            {
                var getAuthors = (from bookDetail in _appDbContext.BookDetail
                                  join bookAuthor in _appDbContext.BookDetailAuthor
                                  on bookDetail.DetailID equals bookAuthor.DetailID
                                  join author in _appDbContext.Author
                                  on bookAuthor.AuthorId equals author.AuthortId
                                  where bookDetail.DetailID == bookid
                                  select author.Name).ToList();

                Book.Author = getAuthors;

                var bookCopies = (from bookDetail in _appDbContext.BookDetail
                                  join bookId in _appDbContext.BookIdentification
                                  on bookDetail.DetailID equals bookId.DetailID
                                  where bookDetail.DetailID == bookid
                                  select new IndividualBookStatusDTO { BookID = bookId.BookID }).ToList();

                foreach(IndividualBookStatusDTO book in bookCopies)
                {
                    book.Status = _appDbContext.BookIdentification.Where(c => c.BookID == book.BookID && c.Status == "0").FirstOrDefault() != null ? "Misplaced"
                        : (_appDbContext.Borrowing.Where(c => c.BookID == book.BookID && c.Status == "B").FirstOrDefault() != null ? "Borrowed" 
                        : (_appDbContext.Reservation.Where(c => c.BookID == book.BookID && c.Status == "Active").FirstOrDefault() != null ? "Reserved" 
                        : "Available"));
                }

                Book.Copies = bookCopies;
            }
            //var Book = _appDbContext.BookIdentification.Where(c => c.BookID == id).SingleOrDefault();
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
