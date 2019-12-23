using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    //-----------------------------------------------------------------
    //$Developer : Aysha Firouzs
    //$Created on : 13/12/19
    //$Mobile No : 0767779845
    //$Email : ayshuu1997@gmail.com
    //$Description (if any) :
    //-----------------------------------------------------------------
    public interface IPaymentInterface
    {
        ICollection<Payment> GetAllpaymentByStudentID(int id);

        void CreatePaymentByBorrowingID(Payment newPayment);

    }
}
