using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }
        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId), Messages.ProductsListed);
        }


        public IDataResult<List<Car>> GetCarsByColourId(int colourId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColourId==colourId), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //return _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
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
    }
}
