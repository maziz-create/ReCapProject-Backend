using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        public IResult Payment()
        {
            var rd = new Random().Next(2);
            //2'den küçük, negatif olmayan sayı döndürecek. yani 0 ya da 1 'i.
            //Yani aslında ödemenin yapılması tamamen şans:d
            if (rd == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
