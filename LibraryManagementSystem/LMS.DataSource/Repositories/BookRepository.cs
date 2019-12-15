﻿using LMS.DataModel;
using LMS.DataSource.Entities;
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

        public ICollection<GetAllBooksDTO> GetAllBooks()
        {
            var BookDetails = (from Detail in _appDbContext.BookDetail
                               join Shelf in _appDbContext.Shelve
                               on Detail.ShelveID equals Shelf.ShelveID
                               join Book in _appDbContext.BookIdentification
                               on Detail.DetailID equals Book.DetailID
                               join Borrow in _appDbContext.Borrowing
                               on Book.BookID equals Borrow.BookID
                               select new { DetailID = Detail.DetailID, Title = Detail.Title, ISBN = Detail.ISBN, ShelveCode = Shelf.Code, Availability = Borrow.Status.Where(c => c == 'B').Count() != 0 ? "Available" : "Unavailable" }).ToList();

            return (ICollection<GetAllBooksDTO>) BookDetails;
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
