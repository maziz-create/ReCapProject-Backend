using Business.Abstract;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c=>c.BrandId==brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c=>c.ColourId== colorId);
        }

        public void Add(Car car)
        {
            // şartlar ... mesela yetkisi var mı ? arabanın adı 2 harften büyük mü vs
            if (car.Name.Length>=2 && car.DailyPrice>0) //şartların biri.
            {
                _carDal.Add(car);
            }
        }   
        
        public void Delete(Car car)
        {
            // şartlar ... mesela yetkisi var mı ? arabanın adı 2 harften büyük mü vs
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            // şartlar ... mesela yetkisi var mı ? arabanın adı 2 harften büyük mü vs
            // bu güncelleme işini pek kavrayamadım sanki... memoryde güncellenen car objesi mi gönderiliyor acaba
            _carDal.Update(car);
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(p=>p.Id==Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
