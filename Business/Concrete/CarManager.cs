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

        public List<Car> GetCarsByBrandId(int brandid)
        {
            _id = brandid;
            return _carDal.GetAll(c=>c.BrandId==_id);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            _id = colorId;
            return _carDal.GetAll(c=>c.ColorId==_id);

        }

        public void AddCar(Car car)
        {
            if (car.Name.Length>=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }

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
