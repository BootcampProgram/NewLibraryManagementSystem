using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class LibrarianRepository : ILibrarianInterface
    {
        AppDbContext _appDbContext;

        public LibrarianRepository(AppDbContext repo)
        {
            _appDbContext = repo;
        }

        public void CreateLibrarian(Librarian newLibrarian)
        {
            _appDbContext.Librarian.Add(newLibrarian);
            _appDbContext.SaveChanges();
        }

        public void DeleteLibrarian(int librarianID)
        {
            var librarian = _appDbContext.Librarian.Where(c => c.LibrarianID == librarianID).SingleOrDefault();

            _appDbContext.Librarian.Remove(librarian);
            _appDbContext.SaveChanges();
        }

        public ICollection<Librarian> GetAllLibrarians()
        {
            var librarians = _appDbContext.Librarian.ToList();
            return librarians;
        }

        public Librarian GetLibrarianByID(int librarianID)
        {
            var librarian = _appDbContext.Librarian.Where(c => c.LibrarianID == librarianID).SingleOrDefault();
            return librarian;
        }

        public int ResetPassword(int librarianID)
        {
            var librarian = (from _Librarian in _appDbContext.Librarian
                             join _User in _appDbContext.User
                             on _Librarian.LibrarianID equals _User.RoleID
                             where _User.Role == 'L' && _User.RoleID == librarianID
                             select _User).SingleOrDefault();

            if (librarian == null)
            {
                return 0;
            }
            else
            {
                librarian.Password = "LMS@123";
                _appDbContext.SaveChanges();
                return 1;
            }
        }

        public int UpdateLibrarian(int librarianID, Librarian librarianObject)
        {
            var librarian = _appDbContext.Librarian.Where(c => c.LibrarianID == librarianID).SingleOrDefault();

            if (librarianID == 0)
            {
                return 0;
            }
            else
            {
                librarian.FirstName = librarianObject.FirstName;
                librarian.LastName = librarianObject.LastName;
                librarian.DateOfBirth = librarianObject.DateOfBirth;
                librarian.Gender = librarianObject.Gender;
                librarian.Address = librarianObject.Address;
                librarian.ContactNo = librarianObject.ContactNo;
                librarian.NIC = librarianObject.NIC;
                librarian.JobEnrolled = librarianObject.JobEnrolled;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
