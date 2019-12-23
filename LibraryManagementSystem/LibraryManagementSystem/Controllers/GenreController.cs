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
    [Route("api/Genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreInterface _genreRepo;

        public GenreController(IGenreInterface repo)
        {
            _genreRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreRepo.GetAllGenres();
            return Ok(genres);
        }

        [HttpGet("{genreID}")]
        public IActionResult GetGenreByID(int genreID)
        {
            var genre = _genreRepo.GetGenreByID(genreID);
            return Ok(genre);
        }

        [HttpPost("New")]
        public IActionResult CreateGenre([FromBody] Genre newGenre)
        {
            _genreRepo.CreateGenre(newGenre);
            return Ok();
        }

        [HttpPut("Update/{genreID}")]
        public IActionResult UpdateGenre(int genreID, [FromBody] Genre genreObject)
        {
            if (genreID < 0)
            {
                return BadRequest();
            }

            int update = _genreRepo.UpdateGenre(genreID, genreObject);

            if (update == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        [HttpDelete("Delete/{genreID}")]
        public IActionResult DeleteGenre(int genreID)
        {
            if (genreID < 0)
            {
                return BadRequest();
            }

            _genreRepo.DeleteGenre(genreID);

            return Ok();
        }
    }
}