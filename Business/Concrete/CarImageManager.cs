using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId), Messages.ProductsListed);
        }

        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.Id == Id), Messages.ProductsListed);
        }

        public IResult Add(IFormFile file,  CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            var imageResult = FileHelper.Upload(file);
            if (result==null && imageResult.Success)
            {
                carImage.Date = System.DateTime.Now;
                carImage.ImagePath = imageResult.Message;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult(imageResult.Message);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c=>c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(IFormFile file ,CarImage carImage)
        {
            var imageToUpdate = _carImageDal.Get(c=>c.Id == carImage.Id);
            if (imageToUpdate==null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            var updatedFile = FileHelper.Update(file, imageToUpdate.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ProductUpdated);

        }


        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
