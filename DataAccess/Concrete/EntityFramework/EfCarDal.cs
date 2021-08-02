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

        public List<CarDetailDto> GetCarDetail(int id)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join colour in context.Colours
                             on c.ColourId equals colour.ColourId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColourId = c.Id,
                                 ColourName = colour.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.Where(c => c.CarId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int Id)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join colour in context.Colours
                             on c.ColourId equals colour.ColourId
                             where c.BrandId == Id
                             select new CarDetailDto
                             {
                                 BrandId = c.BrandId,
                                 CarId = c.Id,
                                 ColourId = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 ColourName = colour.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                         
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColourId(int Id)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join colour in context.Colours
                             on c.ColourId equals colour.ColourId
                             where c.ColourId == Id
                             select new CarDetailDto
                             {
                                 ColourId = c.ColourId,
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 ColourName = colour.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandIdAndColorId(int brandId, int colourId)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join colour in context.Colours
                             on c.ColourId equals colour.ColourId
                             where c.BrandId == brandId
                             where c.ColourId == colourId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColourId = c.Id,
                                 ColourName = colour.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }
    }
}