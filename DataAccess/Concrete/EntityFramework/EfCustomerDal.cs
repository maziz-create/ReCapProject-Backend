using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    //EfEntityRepositoryBase
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDBContext>, ICustomerDal
    {
        public Customer GetByUserId(int UserId)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {

                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             where c.UserId == UserId
                             select new Customer
                             {
                                 CompanyName = c.CompanyName,
                                 Id = c.Id,
                                 UserId = c.UserId
                             };
                return result.First();

            }
        }
    }
}