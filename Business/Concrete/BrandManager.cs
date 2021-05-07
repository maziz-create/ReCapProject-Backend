using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return _brandDal.GetAll();
        }

        public Brand GetById(int Id)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return _brandDal.Get(b=>b.Id==Id);
        }

        public void Update(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap

            //güncellemeyi tam oturtamadım kafamda
            _brandDal.Update(brand);
            
        }
    }
}
