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
    //$Developer                :  Iresha Silva
    //$Created on               :  11/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------

    public class ReservationRepository : IReservationInterface
    {
        AppDbContext _appDbContext;

        public ReservationRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public int AddedToSubShelve(int reservationID)


            //validation
        {
            var student = _appDbContext.Reservation.Where(c => c.ReservationId == reservationID && c.Shelve == "Main").FirstOrDefault();

            if (student == null)
            {
                return 0;
            }
            else
            {
                student.Shelve = "Sub";
                _appDbContext.SaveChanges();
                return 1;
            }
        }

        public int CancelReservation(int reservationID)
        {
            var reservation = _appDbContext.Reservation.Where(c => c.ReservationId == reservationID && c.Status == "Active").FirstOrDefault();

            if (reservation == null)
            {
                return 0;
            }
            else
            {
                reservation.Status = "Cancel";
                _appDbContext.SaveChanges();
                return 1;
            }
        }

        public int CreateReservation(Reservation newReservation)
        {
            var reservationCount = _appDbContext.Reservation.Where(c => c.StudentId == newReservation.StudentId && c.Status == "Active").Count();

            if (reservationCount < 2)
            {
                _appDbContext.Reservation.Add(newReservation);
                _appDbContext.SaveChanges();
                return 1;
                //error responses
            }
            else
            {
                return 0;
            }
        }

        public ICollection<GetAllReservationsDTO> GetAllReservations()
        {
            //Delete expired data over 72 hours from database
            var allReservations = _appDbContext.Reservation.ToList();

            DateTime getCurrentDateTime = DateTime.Now;

            foreach (Reservation record in allReservations)
            {
                var hours = (getCurrentDateTime - record.DateReserved).TotalHours;

                if (hours >= 24)
                {
                    record.Status = "Expired";
                    _appDbContext.SaveChanges();
                }
                if (hours >= 72)
                {
                    _appDbContext.Reservation.Remove(record);
                    _appDbContext.SaveChanges();
                }
            }
            //------------------------------------------------

            var reservation = (from _reservation in _appDbContext.Reservation
                               join _bookID in _appDbContext.BookIdentification
                               on _reservation.BookID equals _bookID.BookID
                               join _bookDetail in _appDbContext.BookDetail
                               on _bookID.DetailID equals _bookDetail.DetailID
                               join _student in _appDbContext.Student
                               on _reservation.StudentId equals _student.StudentId
                               join _publisher in _appDbContext.Publisher
                               on _bookDetail.PublisherID equals _publisher.PublisherID
                               join _genre in _appDbContext.Genre
                               on _bookDetail.GenreID equals _genre.GenreID
                               join _shelve in _appDbContext.Shelve
                               on _bookDetail.ShelveID equals _shelve.ShelveID
                               select new GetAllReservationsDTO {
                                   ReservationID = _reservation.ReservationId,
                                   DateReserved = _reservation.DateReserved,
                                   BookID = _bookID.BookID,
                                   DetailID = _bookDetail.DetailID,
                                   Title = _bookDetail.Title, 
                                   ISBN = _bookDetail.ISBN, 
                                   Genre = _genre.Name, 
                                   Language = _bookDetail.Language, 
                                   Status = _reservation.Status, 
                                   ShelveCode = _shelve.Code,
                                   Shelve = _reservation.Shelve,
                                   CoverImage = _bookDetail.CoverImage, 
                                   studentFullName = _student.FirstName + " " + _student.LastName, 
                                   Grade = (_student.Grade).ToString() + " " + (_student.Section).ToString(), 
                                   StudentId = _student.StudentId, 
                                   Publisher = _publisher.Name}).ToList();


            foreach (GetAllReservationsDTO resvDetails in reservation)
            {
                var author = (from _bookDetailAuthor in _appDbContext.BookDetailAuthor
                              join _author in _appDbContext.Author
                              on _bookDetailAuthor.AuthorId equals _author.AuthortId
                              join _bookDetail in _appDbContext.BookDetail
                              on _bookDetailAuthor.DetailID equals _bookDetail.DetailID
                              where _bookDetailAuthor.DetailID == resvDetails.DetailID
                              select _author.Name).ToList();

                resvDetails.Author = author[0];
            }
            return reservation;
        }

        public ICollection<Reservation> GetReservationsByShelve(string shelve)
        {
            var _shelve = _appDbContext.Reservation.Where(c => c.Shelve.Contains(shelve)).ToList();
            return _shelve;
        }

        public ICollection<Reservation> GetReservationsByStatus(string status)
        {
            var ReservationStatus = _appDbContext.Reservation.Where(c => c.Status.Contains(status)).ToList();
            return ReservationStatus;
        }

        public ICollection<BookDetail> GetReservationsByStudentID(int studentID)
        {
            //check is that expired
            var reservations = _appDbContext.Reservation.Where(c => c.StudentId == studentID && c.Status == "Active").ToList();

            DateTime getCurrentDateTime = DateTime.Now;

            foreach (Reservation record in reservations)
            {
                var hours = (getCurrentDateTime - record.DateReserved).TotalHours;

                if (hours >= 24)
                {
                    record.Status = "Expired";
                    _appDbContext.SaveChanges();
                }
            }

            var bookDetail = (from _reservation in _appDbContext.Reservation
                              join _bookID in _appDbContext.BookIdentification
                              on _reservation.BookID equals _bookID.BookID
                              join _bookDetail in _appDbContext.BookDetail
                              on _bookID.DetailID equals _bookDetail.DetailID
                              where _reservation.StudentId == studentID && _reservation.Status == "Active"
                              select _bookDetail).ToList();

            //Showing recent expired book details
            var ExpiredReservations = _appDbContext.Reservation.Where(c => c.StudentId == studentID && c.Status == "Expired").ToList();

            foreach (Reservation record in ExpiredReservations)
            {
                var hours = (getCurrentDateTime - record.DateReserved).TotalHours;

                if (hours <= 48)
                {
                    var ExpiredBookDetail =   (from _reservation in _appDbContext.Reservation
                                              join _bookID in _appDbContext.BookIdentification
                                              on _reservation.BookID equals _bookID.BookID
                                              join _bookDetail in _appDbContext.BookDetail
                                              on _bookID.DetailID equals _bookDetail.DetailID
                                              where _reservation.ReservationId == record.ReservationId
                                              select _bookDetail).ToList();

                    foreach(BookDetail book in ExpiredBookDetail)
                    {
                        bookDetail.Add(book);
                    } 
                }
                else if(hours >= 72)
                {
                    _appDbContext.Reservation.Remove(record);
                    _appDbContext.SaveChanges();
                }
            }

            return bookDetail;
        }

        public int ReturnedToMainShelve(int reservationID)
        {
            var student = _appDbContext.Reservation.Where(c => c.ReservationId == reservationID && c.Shelve=="Sub").FirstOrDefault();

            if (student == null)
            {
                return 0;
            }
            else
            {
                student.Shelve = "Main";
                _appDbContext.SaveChanges();
                return 1;
            }
        }

        public int UpdateStatus(string status)
        {

            //var reservedTime = _appDbContext.Reservation.Where(c => c.DateReserved >=)
            throw new NotImplementedException();
        }
    }
}
