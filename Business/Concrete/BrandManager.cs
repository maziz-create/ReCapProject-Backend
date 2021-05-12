using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Brand brand)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap

            //güncellemeyi tam oturtamadım kafamda
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductUpdated);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Brand> GetById(int Id)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id==Id));
        }

       
    }
}
