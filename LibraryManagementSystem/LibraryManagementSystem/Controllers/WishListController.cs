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



    [Route("api/WishList")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishListInterface _wishListRepo;

        public WishListController (IWishListInterface repo)
        {
            _wishListRepo = repo;
        }


        [HttpPost("New")]
        public IActionResult CreateWishListItem([FromBody] WishList newWishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newWishList == null)
            {
                return BadRequest();
            }

            _wishListRepo.CreateWishListItem(newWishList);
            return NoContent();
        }


        [HttpDelete("Delete/{wishListID}")]
        public IActionResult DeleteWishListItemByID(int wishListID)
        {
            if (wishListID <= 0)
            {
                return BadRequest();
            }
            else
            {
                _wishListRepo.DeleteWishListItemByID(wishListID);
                return Ok();
            }
        }
    }
}