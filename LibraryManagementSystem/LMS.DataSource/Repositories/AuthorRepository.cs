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
    //$Created on : 13/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public class AuthorRepository : IAuthorInterface
    {
        AppDbContext _appDbContext;

        public AuthorRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }
        public void CreateAuthor(Author AuthorObject)
        {
            _appDbContext.Author.Add(AuthorObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _appDbContext.Author.Where(c => c.AuthortId == id).SingleOrDefault();
            _appDbContext.Author.Remove(author);
            _appDbContext.SaveChanges();
        }

        public ICollection<Author> GetAllAuthors()
        {
            var Author = _appDbContext.Author.ToList();
            return Author;
        }

        public Author GetByAuthorId(int id)
        {
            var author = _appDbContext.Author.Where(c => c.AuthortId == id).SingleOrDefault();
            return author;
        }

        public int UpdateAuthor(int id, Author AuthorObject)
        {
            var author = _appDbContext.Author.Where(c => c.AuthortId == id).SingleOrDefault();
            if (author == null)
            {
                return 0; //if Fails return 0
            }
            else
            {

                author.Name = AuthorObject.Name;
               


                _appDbContext.SaveChanges();
                return 1; //if success return 1

            }
        }
    }
}
