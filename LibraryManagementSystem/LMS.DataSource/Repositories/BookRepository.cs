﻿using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 11/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public class BookRepository : IBookInterface
    {
        AppDbContext _appDbContext;

        public BookRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }
        public void CreateBook(BookDetail BookObject)
        {
            _appDbContext.BookDetail.Add(BookObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var Book = _appDbContext.BookDetail.Where(c => c.DetailID == id).SingleOrDefault();
            _appDbContext.BookDetail.Remove(Book);
            _appDbContext.SaveChanges();
        }

        public ICollection<BookDetail> GetAllBooks()
        {
            var BookDetail = _appDbContext.BookDetail.ToList();
            return BookDetail;
        }

        public BookIdentification GetBookByBookID(int id)
        {
            var Book = _appDbContext.BookIdentification.Where(c => c.BookID == id).SingleOrDefault();
            return Book;
        }

        public int UpdateBook(int id, BookDetail BookObject)
        {
            var Book = _appDbContext.BookDetail.Where(c => c.DetailID == id).SingleOrDefault();
            if (Book == null)
            {
                return 0; //if Fails return 0
            }
            else
            {
                Book.ISBN = BookObject.ISBN;
                Book.Title = BookObject.Title;
                Book.Year = BookObject.Year;
                Book.Language = BookObject.Language;
                Book.Price = BookObject.Price;


                _appDbContext.SaveChanges();
                return 1; //if success return 1

            }
        }
    }
}
