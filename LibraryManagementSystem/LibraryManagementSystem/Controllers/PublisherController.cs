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
    //$Created on               :  13/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherInterface _interfaceRepo;

        public PublisherController(IPublisherInterface repo)
        {
            _interfaceRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            var publishers = _interfaceRepo.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("{publisherID}")]
        public IActionResult GetPublisherByID(int publisherID)
        {
            var publisher = _interfaceRepo.GetPublisherByID(publisherID);
            return Ok(publisher);
        }

        [HttpPost("New")]
        public IActionResult CreateReservation([FromBody] Publisher newPublisher)
        {
             _interfaceRepo.CreatePublisher(newPublisher);
            return Ok();
        }

        [HttpPut("Update/{publisherID}")]
        public IActionResult UpdatePublisher(int publisherID, [FromBody] Publisher publisherObject)
        {
            if (publisherID < 0)
            {
                return BadRequest();
            }

            int update = _interfaceRepo.UpdatePublisher(publisherID, publisherObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("Delete/{publisherID}")]
        public IActionResult DeletePublisher(int publisherID)
        {
            if (publisherID < 0)
            {
                return BadRequest();
            }

            _interfaceRepo.DeletePublisher(publisherID);

            return Ok();
        }
    }
}