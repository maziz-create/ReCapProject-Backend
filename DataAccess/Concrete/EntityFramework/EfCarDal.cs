using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        //eğer bir şart gelirse onu filter olarak alacağız.
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (var context = new ReCapDBContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                                 on p.BrandId equals b.BrandId
                             join c in context.Colours
                                 on p.ColourId equals c.ColourId
                             select new CarDetailDto
                             {
                                 CarId = p.Id,
                                 CarName = p.Name,
                                 BrandName = b.BrandName,
                                 ColourName = c.ColourName,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}