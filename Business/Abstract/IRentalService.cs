using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<Rental> GetById(int Id); 
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        //IResult CheckReturnDateByCarId(int carId);    //=>rentalmanager
        IResult IsRentable(Rental rental);
        IResult CheckFindeksScoreSufficiency(Rental rental);
    }
}
