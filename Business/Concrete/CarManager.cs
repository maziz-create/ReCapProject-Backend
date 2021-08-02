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

        [CacheAspect(duration: 10)] //mermoyde bunun return değerini 10 dakika tut
        [PerformanceAspect(5)] //bu method 5 saniyeden fazla çaşılırsa beni uyar.
        public IDataResult<List<Car>> GetAll()
        {
            //Thread.Sleep(5000);//performans denemesi içindi.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.ProductsListed);
        }    

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            return result;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {
            //İş kodları
            //Yetkisi var mı?

            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);

            //return new ErrorResult(Messages.ProductNameInvalid);
        }   
        
        public IResult Delete(Car car)
        {
            // şartlar ... mesela yetkisi var mı ? arabanın adı 2 harften büyük mü vs
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Car car)
        {
            // şartlar ... mesela yetkisi var mı ? arabanın adı 2 harften büyük mü vs
            // bu güncelleme işini pek kavrayamadım sanki... memoryde güncellenen car objesi mi gönderiliyor acaba
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult AddTransactionalTest(Car car)        //mantığını anlayamadım
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(id));
            return result;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColourId(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColourId(id));
            return result;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int id)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(id));
            return result;
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colourId)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrandIdAndColorId(brandId, colourId));
            return result;
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandName == brandName && c.ColourName == colorName));
        }
    }
}
