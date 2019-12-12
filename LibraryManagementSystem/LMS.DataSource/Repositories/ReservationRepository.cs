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

        public int AddedToSubShelve(int ID)
        {
            var student = _appDbContext.Reservation.Where(c => c.ReservationId == ID && c.Shelve == "Main").FirstOrDefault();

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

        public int CancelReservation(int ID)
        {
            var reservation = _appDbContext.Reservation.Where(c => c.ReservationId == ID && c.Status == "Active").FirstOrDefault();

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
            }
            else
            {
                return 0;
            }
        }

        public ICollection<Reservation> GetAllReservations()
        {
            //var reservations = _appDbContext.Reservation.ToList();
            //return reservations;

            //var reservations = _appDbContext.Reservation.Where(c => c.Status == "Active").ToList();

            //DateTime getCurrentDateTime = DateTime.Now;

            //foreach (Reservation record in reservations)
            //{
            //    var hours = (getCurrentDateTime - record.DateReserved).TotalHours;

            //    if (hours >= 24)
            //    {
            //        record.Status = "Expired";
            //        _appDbContext.SaveChanges();
            //    }
            //}

            //return 1;

            throw new NotImplementedException();
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

        public ICollection<BookDetail> GetReservationsByStudentID(int ID)
        {
            //check is that expired
            var reservations = _appDbContext.Reservation.Where(c => c.StudentId == ID && c.Status == "Active").ToList();

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
                              where _reservation.StudentId == ID && _reservation.Status == "Active"
                              select _bookDetail).ToList();

            //Showing recent expired book details
            var ExpiredReservations = _appDbContext.Reservation.Where(c => c.StudentId == ID && c.Status == "Expired").ToList();

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
            }

            return bookDetail;
        }

        public int ReturnedToMainShelve(int ID)
        {
            var student = _appDbContext.Reservation.Where(c => c.ReservationId == ID && c.Shelve=="Sub").FirstOrDefault();

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
