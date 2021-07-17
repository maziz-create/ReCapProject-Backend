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
        public List<CarDetailDto> GetCarDetails()
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
                                 carId = c.Id,
                                 carName = c.Name,
                                 brandId = b.BrandId,
                                 brandName = b.BrandName,
                                 colourId = c.Id,
                                 colourName = colour.ColourName,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 modelYear = c.ModelYear,
                                 imagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.ToList();
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
                                 carId = c.Id,
                                 carName = c.Name,
                                 brandId = b.BrandId,
                                 brandName = b.BrandName,
                                 colourId = c.Id,
                                 colourName = colour.ColourName,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 modelYear = c.ModelYear,
                                 imagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.Where(c => c.carId == id).ToList();
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
                                 brandId = c.BrandId,
                                 carId = c.Id,
                                 colourId = c.Id,
                                 carName = c.Name,
                                 brandName = b.BrandName,
                                 colourName = colour.ColourName,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 modelYear = c.ModelYear,
                                 imagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                                 //imagePaths = (from x in context.CarImages where x.CarId == c.Id select new CarImage { Id = x.Id, CarId = x.CarId, Date = x.Date, ImagePath = x.ImagePath }).ToList()
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
                                 colourId = c.ColourId,
                                 carId = c.Id,
                                 brandId = b.BrandId,
                                 carName = c.Name,
                                 brandName = b.BrandName,
                                 colourName = colour.ColourName,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 modelYear = c.ModelYear,
                                 imagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
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
                                 carId = c.Id,
                                 carName = c.Name,
                                 brandId = b.BrandId,
                                 brandName = b.BrandName,
                                 colourId = c.Id,
                                 colourName = colour.ColourName,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 modelYear = c.ModelYear,
                                 imagePaths = (from x in context.CarImages where x.CarId == c.Id select x.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }
    }
}