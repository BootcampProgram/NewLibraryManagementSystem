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
    //$Developer : Aysha Firouzs
    //$Created on : 13/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentInterface _paymentRepo;

        public PaymentController(IPaymentInterface paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpGet("{id}")]

        public IActionResult GetPaymentByStudentID(int id)
        {
            var payment = _paymentRepo.GetAllpaymentByStudentID(id);
            return Ok(payment);
        }

        [HttpPost]

        public IActionResult CreatePayment([FromBody] Payment newobj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newobj == null)
            {
                return BadRequest();
            }

            _paymentRepo.CreatePaymentByBorrowingID(newobj);

            return NoContent();
        }
    }
}