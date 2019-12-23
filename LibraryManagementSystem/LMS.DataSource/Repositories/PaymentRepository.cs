using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
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
    public class PaymentRepository: IPaymentInterface
    {
        AppDbContext _appDbContext;


        public void CreatePaymentByBorrowingID(Payment paymentObject)
        {
            _appDbContext.Payment.Add(paymentObject);
            _appDbContext.SaveChanges();
        }

        public ICollection<Payment> GetAllpaymentByStudentID(int id)
        {
           
            var Payments = (from S in _appDbContext.Student
                            join B in _appDbContext.Borrowing
                            on S.StudentId equals B.StudentId
                            join P in _appDbContext.Payment
                            on B.BorrowingId equals P.BorrowingId
                            where S.StudentId == id
                            select P).ToList();
            return Payments;
        }

    }
}
