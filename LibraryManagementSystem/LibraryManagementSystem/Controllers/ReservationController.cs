using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.DataSource.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{

    //-----------------------------------------------------------------
    //$Developer                :  Iresha Silva
    //$Created on               :  10/12/2019
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
            var reservations = _reservationRepo.GetAllReservations();
            return Ok(reservations);
        }

        [HttpGet("{ID}")]
        public IActionResult GetReservationByStudentID(int ID)
        {
            var reservation = _reservationRepo.GetReservationsByStudentID(ID);
            return Ok(reservation);
        }
    }
}