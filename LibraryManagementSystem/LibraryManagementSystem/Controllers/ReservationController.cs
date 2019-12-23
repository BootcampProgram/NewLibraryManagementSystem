using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  11/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationInterface _reservationRepo;

        public ReservationController(IReservationInterface repo)
        {
            _reservationRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            //check records of status = expired or not
            //if expired change the status to expired

            var reservations = _reservationRepo.GetAllReservations();
            return Ok(reservations);
        }

        [HttpGet("{studentID}")]
        public IActionResult GetReservationByStudentID(int studentID)
        {
            var reservation = _reservationRepo.GetReservationsByStudentID(studentID);
            return Ok(reservation);
        }

        [HttpGet("Status/{status}")]
        public IActionResult GetReservationsByStatus(string status)
        {
            var _status = _reservationRepo.GetReservationsByStatus(status);
            return Ok(_status);
        }

        [HttpGet("Shelve/{shelve}")]
        public IActionResult GetReservationsByShelve(string shelve)
        {
            var _shelve = _reservationRepo.GetReservationsByShelve(shelve);
            return Ok(_shelve);
        }


        [HttpPost("New")]
        public IActionResult CreateReservation([FromBody] Reservation newReservation)
        {
            int result = _reservationRepo.CreateReservation(newReservation);

            if (result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("UpdateStatus/{status}")]
        public IActionResult UpdateStatus(string status)
        {
            var UpdateStatus = _reservationRepo.UpdateStatus(status);
            if (UpdateStatus == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("SubShelve/{reservationID}")]
        public IActionResult AddedToSubShelve(int reservationID)
        {
            var ChangeShelve = _reservationRepo.AddedToSubShelve(reservationID);

            if (ChangeShelve == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("MainShelve/{reservationID}")]
        public IActionResult ReturnedToMainShelve(int reservationID)
        {
            var ChangeShelve = _reservationRepo.ReturnedToMainShelve(reservationID);

            if (ChangeShelve == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("Cancel/{reservationID}")]
        public IActionResult CancelReservation(int reservationID)
        {
            var cancel = _reservationRepo.CancelReservation(reservationID);
            if (cancel == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}