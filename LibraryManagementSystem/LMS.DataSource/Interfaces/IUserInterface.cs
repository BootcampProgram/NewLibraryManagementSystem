using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetAllUsers();

        User GetUserByID(int userID);

        void CreateUser(User newUser);

        int UpdateUser(int userID, User userObject);

        int ResetPassword(int userID);

        void DeleteUser(int userID);
    }
}
