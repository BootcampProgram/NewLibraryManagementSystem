using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class BorrowingRepository : IBorrowingInterface
    {
        AppDbContext _appDbContext;

        public BorrowingRepository(AppDbContext repo)
        {
            _appDbContext = repo;
        }

        public ICollection<GetBorrowingsHistoryDTO> GetBorrowingsHistory()
        {

            var borrowings = (from _bookIdentification in _appDbContext.BookIdentification
                             join _bookDetail in _appDbContext.BookDetail
                             on _bookIdentification.DetailID equals _bookDetail.DetailID
                             join _borrowing in _appDbContext.Borrowing
                             on _bookIdentification.BookID equals _borrowing.BookID
                             join _payment in _appDbContext.Payment
                             on _borrowing.BorrowingId equals _payment.BorrowingId
                             select new GetBorrowingsHistoryDTO
                             {
                                 BorrowingID = _borrowing.BorrowingId,
                                 Title = _bookDetail.Title,
                                 BorrowDate = _borrowing.BorrowDate,
                                 ReturnDate = _borrowing.ReturnDate,
                             }).ToList();

            
            return borrowings;
        }

        public ICollection<GetPresentBorrowingsDTO> GetPresentBorrowings()
        {

            var borrowings = (from _bookIdentification in _appDbContext.BookIdentification
                             join _bookDetail in _appDbContext.BookDetail
                             on _bookIdentification.DetailID equals _bookDetail.DetailID
                             join _borrowing in _appDbContext.Borrowing
                             on _bookIdentification.BookID equals _borrowing.BookID
                             join _publisher in _appDbContext.Publisher
                             on _bookDetail.PublisherID equals _publisher.PublisherID
                             join _bookDetailAuthor in _appDbContext.BookDetailAuthor
                             on _bookDetail.DetailID equals _bookDetailAuthor.DetailID
                             join _author in _appDbContext.Author
                             on _bookDetailAuthor.AuthorId equals _author.AuthortId
                             join _genre in _appDbContext.Genre
                             on _bookDetail.GenreID equals _genre.GenreID
                             where _borrowing.Status == "B"
                             select new GetPresentBorrowingsDTO
                             {
                                 Title = _bookDetail.Title,
                                 Author = _author.Name,
                                 ISBN = _bookDetail.ISBN,
                                 Genre = _genre.Name,
                                 Language = _bookDetail.Language,
                                 Publisher = _publisher.Name,
                                 BorrowDate = _borrowing.BorrowDate,
                             }).ToList();

            DateTime getCurrentDateTime = DateTime.Now;

            foreach (GetPresentBorrowingsDTO record in borrowings)
            {
                var returnDate = (record.BorrowDate).AddDays(14);
                var days = (getCurrentDateTime - returnDate).TotalDays;

                if (days >= 14)
                {
                    var payment = days * 5;
                    record.Payments = payment;
                    record.ReturnDate = returnDate;
                }
                else
                {
                    record.Payments = 0;
                }
            }
            return borrowings;
        }

        public Borrowing GetBorrowingByBookID(int boookID)
        {
            var borrowing = _appDbContext.Borrowing.Where(c => c.BookID == boookID).SingleOrDefault();
            return borrowing;
        }

        public Borrowing GetBorrowingByID(int borrowingID)
        {
            var borrowing = _appDbContext.Borrowing.Where(c => c.BorrowingId == borrowingID).SingleOrDefault();
            return borrowing;
        }

        public Borrowing GetBorrowingByStudentID(int studentID)
        {
            var borrowing = _appDbContext.Borrowing.Where(c => c.StudentId == studentID).SingleOrDefault();
            return borrowing;
        }

        public int UpdateBorrowing(int borrowingID, Borrowing borrowingObject)
        {
            var borrowing = _appDbContext.Borrowing.Where(c => c.BorrowingId == borrowingID).SingleOrDefault();

            if (borrowingID == 0)
            {
                return 0;
            }
            else
            {
                borrowing.BorrowDate = borrowingObject.BorrowDate;
                borrowing.ReturnDate = borrowingObject.ReturnDate;
                borrowing.Status = borrowingObject.Status;
                borrowing.StudentId = borrowingObject.StudentId;
                borrowing.LibrarianID = borrowingObject.LibrarianID;
                borrowing.BookID = borrowingObject.BookID;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
