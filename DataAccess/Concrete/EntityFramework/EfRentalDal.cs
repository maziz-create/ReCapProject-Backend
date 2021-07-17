using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {

                var result = from r in context.Rentals
                             join u in context.Users
                             on r.UserId equals u.Id
                             join car in context.Cars
                             on r.CarId equals car.Id
                             select new RentalDetailDto
                             {
                                 CarId = car.Id,
                                 CustomerId = u.Id,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CarName = car.Name,
                                 BrandName = car.BrandId.ToString(),
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
                             
            }
        }
    }
}
