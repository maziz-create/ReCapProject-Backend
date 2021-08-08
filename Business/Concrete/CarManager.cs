using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(duration: 30)] //mermoyde bunun return değerini 10 dakika tut
        [PerformanceAspect(5)] //bu method 5 saniyeden fazla çaşılırsa beni uyar.
        public IDataResult<List<Car>> GetAll()
        {
            //Thread.Sleep(5000);//performans denemesi içindi.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        [CacheAspect(duration: 30)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.ProductsListed);
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            return result;
        }

        [SecuredOperation("car.add,moderator,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("car.delete,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("car.update,moderator,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult AddTransactionalTest(Car car)        //mantığını anlayamadım
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id));
            return result;
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColourId(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColourId == id));
            return result;
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetail(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id));
            return result;
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colourId)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColourId == colourId));
            return result;
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandName == brandName && c.ColourName == colorName));
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandName == brandName));
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColourName(string colourName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColourName == colourName));
        }
    }
}
