using LMS.DataSource.DTO;
using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IBorrowingInterface
    {
        ICollection<GetAllBorrowingsByStudentIdDTO> GetAllBorrowingsByStudentID(int studentID);

        Borrowing GetBorrowingByID(int borrowingID);

        Borrowing GetBorrowingByBookID(int boookID);

        Borrowing GetBorrowingByStudentID(int studentID);

        int UpdateBorrowing(int borrowingID, Borrowing borrowingObject);
    }
}
