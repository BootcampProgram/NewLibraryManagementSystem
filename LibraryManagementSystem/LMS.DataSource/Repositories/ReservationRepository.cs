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

        public int AddedToSubShelve(string shelve)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reservation> GetAllReservations()
        {
            var reservations = _appDbContext.Reservation.ToList();
            return reservations;
        }

        public Reservation GetReservationByShelve(string shelve)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public ICollection<BookDetail> GetReservationsByStudentID(int ID)
        {
            var bookDetail = (from _reservation in _appDbContext.Reservation
                              join _bookID in _appDbContext.BookIdentification
                              on _reservation.BookID equals _bookID.BookID
                              join _bookDetail in _appDbContext.BookDetail
                              on _bookID.DetailID equals _bookDetail.DetailID
                              where _reservation.StudentId == ID
                              select _bookDetail).ToList();

            return bookDetail;
        }

        public int ReturnedToMainShelve(string shelve)
        {
            throw new NotImplementedException();
        }

        public int UpdateStatus(string status)
        {
            throw new NotImplementedException();
        }
    }
}
