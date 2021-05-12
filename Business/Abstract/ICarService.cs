using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByColourId(int colourId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<Car> GetById(int Id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}