using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LMS.DataSource.DTO;

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

        public PaymentRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public void CreatePaymentByBorrowingID(Payment paymentObject)
        {
            _appDbContext.Payment.Add(paymentObject);
            _appDbContext.SaveChanges();
        }

        public ICollection<GetPaymentsOfStudentDTO> GetAllpaymentByStudentID(int id)
        {

            var Payments = (from borrowing in _appDbContext.Borrowing
                            join payment in _appDbContext.Payment
                            on borrowing.BorrowingId equals payment.BorrowingId
                            where borrowing.StudentId == id
                            select new GetPaymentsOfStudentDTO { 
                                BorrowingId = payment.BorrowingId, 
                                ReturnDate = borrowing.ReturnDate,
                                DuePayment = payment.DuePayment
                            }).ToList();
            return Payments;
        }

    }
}
