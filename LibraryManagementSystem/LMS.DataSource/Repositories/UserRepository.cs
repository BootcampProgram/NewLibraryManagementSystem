using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class UserRepository : IUserInterface
    {
        AppDbContext _appDbContext;

        public UserRepository(AppDbContext repo)
        {
            _appDbContext = repo;
        }

        public void CreateUser(User newUser)
        {
            _appDbContext.User.Add(newUser);
            _appDbContext.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            var user = _appDbContext.User.Where(c => c.UserID == userID).SingleOrDefault();

            _appDbContext.User.Remove(user);
            _appDbContext.SaveChanges();
        }

        public ICollection<User> GetAllUsers()
        {
            var users = _appDbContext.User.ToList();
            return users;
        }

        public User GetUserByID(int userID)
        {
            var user = _appDbContext.User.Where(c => c.UserID == userID).SingleOrDefault();
            return user;
        }

        public int ResetPassword(int userID)
        {
            var user = (from _Librarian in _appDbContext.Librarian
                        join _User in _appDbContext.User
                        on _Librarian.LibrarianID equals _User.RoleID
                        where _User.Role == 'L' && _User.UserID == userID
                        select _User).SingleOrDefault();

            if (user == null)
            {
                return 0;
            }
            else
            {
                user.Password = "LMS@123";
                _appDbContext.SaveChanges();
                return 1;
            }
        }

        public int UpdateUser(int userID, User userObject)
        {
            var user = _appDbContext.User.Where(c => c.UserID == userID).SingleOrDefault();

            if (userID == 0)
            {
                return 0;
            }
            else
            {
                user.Role = userObject.Role;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }

}
