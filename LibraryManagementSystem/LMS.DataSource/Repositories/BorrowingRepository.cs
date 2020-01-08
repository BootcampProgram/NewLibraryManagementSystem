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

        public ICollection<GetAllBorrowingsDTO> GetAllBorrowings()
        {
            var borrowings = (from _borrowings in _appDbContext.Borrowing
                               join _bookID in _appDbContext.BookIdentification
                               on _borrowings.BookID equals _bookID.BookID
                               join _bookDetail in _appDbContext.BookDetail
                               on _bookID.DetailID equals _bookDetail.DetailID
                               join _student in _appDbContext.Student
                               on _borrowings.StudentId equals _student.StudentId
                               join _publisher in _appDbContext.Publisher
                               on _bookDetail.PublisherID equals _publisher.PublisherID
                               join _genre in _appDbContext.Genre
                               on _bookDetail.GenreID equals _genre.GenreID
                               join _shelve in _appDbContext.Shelve
                               on _bookDetail.ShelveID equals _shelve.ShelveID
                               select new GetAllBorrowingsDTO
                               {
                                   BookDetailID = _bookDetail.DetailID,
                                   BorrowDate = _borrowings.BorrowDate,
                                   BookID = _bookID.BookID,
                                   DetailID = _bookDetail.DetailID,
                                   Title = _bookDetail.Title,
                                   ISBN = _bookDetail.ISBN,
                                   Genre = _genre.Name,
                                   Language = _bookDetail.Language,
                                   Status = _borrowings.Status,
                                   CoverImage = _bookDetail.CoverImage,
                                   studentFullName = _student.FirstName + " " + _student.LastName,
                                   StudentId = _student.StudentId,
                                   Publisher = _publisher.Name
                               }).ToList();

            return borrowings;
        }

        public ICollection<GetAllBorrowingsByStudentIdDTO> GetAllBorrowingsByStudentID(int studentID)
        {

            var borrowings = (from borrowing in _appDbContext.Borrowing
                              join bookid in _appDbContext.BookIdentification
                              on borrowing.BookID equals bookid.BookID
                              join bookDetail in _appDbContext.BookDetail
                              on bookid.DetailID equals bookDetail.DetailID
                              where borrowing.StudentId == studentID
                              select new GetAllBorrowingsByStudentIdDTO
                              {
                                  BorrowingId = borrowing.BorrowingId,
                                  BookDetailID = bookid.DetailID,
                                  Title = bookDetail.Title,
                                  Status = borrowing.Status,
                                  BorrowDate = borrowing.BorrowDate,
                                  ReturnDate = borrowing.ReturnDate
                              }
                              ).ToList();

            
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
