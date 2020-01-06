using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  11/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public interface IReservationInterface
    {
        ICollection<GetAllReservationsDTO> GetAllReservations();

        ICollection<BookDetail> GetReservationsByStudentID(int studentID);

        ICollection<Reservation> GetReservationsByStatus(string status);

        ICollection<Reservation> GetReservationsByShelve(string shelve);

        int UpdateStatus(string status);

        int AddedToSubShelve(int reservationID);

        int ReturnedToMainShelve(int reservationID);

        int CreateReservation(Reservation newReservation);

        int CancelReservation(int reservationID);

        void DeleteReservations(int reservationID);
    }
}
