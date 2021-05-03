using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        int _id;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int Id)
        {
            _id = Id;
            return _carDal.GetById(_id);
        }

        public void AddCar(Car car)
        {
            _carDal.Add(car);
        }   
        
        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
        }

    }
}
