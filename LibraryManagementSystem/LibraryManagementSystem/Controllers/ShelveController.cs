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
    [Route("api/[controller]")]
    [ApiController]
    public class ShelveController : ControllerBase
    {
        IShelveInterface _shelveRepo;

        public ShelveController(IShelveInterface shelveRepo)
        {
            _shelveRepo = shelveRepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var shelve = _shelveRepo.GetAllShelve();
            return Ok(shelve);
        }

        [HttpGet("{id}")]

        public IActionResult GetByShelveId(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var shelve = _shelveRepo.GetByShelveId(id);
            return Ok(shelve);
        }

        [HttpPost]

        public IActionResult CreateShelve([FromBody] Shelve newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newObj == null)
            {
                return BadRequest();
            }

            _shelveRepo.CreateShelve(newObj);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateShelve(int id, [FromBody] Shelve newObj)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            int result = _shelveRepo.UpdateShelve(id, newObj);
            if (result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteShelve(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _shelveRepo.DeleteShelve(id);

            return Ok();
        }
    }
}