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
    //$Created on               :  13/12/2019
    //$Mobile No                :  0778377630
    //$Email                    :  ireshasilva96@gmail.com
    //$Description (If Any)     : 
    //-----------------------------------------------------------------


    public class WishListRepository : IWishListInterface
    {
        AppDbContext _appDbContext;

        public WishListRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public void CreateWishListItem(WishList newWishList)
        {
            _appDbContext.WishList.Add(newWishList);
            _appDbContext.SaveChanges();
        }


        public void DeleteWishListItemByID(int wishListID)
        {
            var wishListItem = _appDbContext.WishList.Where(c => c.WishListID == wishListID).FirstOrDefault();
            _appDbContext.WishList.Remove(wishListItem);
            _appDbContext.SaveChanges();
        }
    }
}
