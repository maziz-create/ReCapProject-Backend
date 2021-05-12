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
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public IResult Add(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _colourDal.Add(colour);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap

            //güncelleme işini anlamakta sorun yaşıyorum...
            _colourDal.Update(colour);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Colour>> GetAll()
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Colour> GetById(int Id)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return new SuccessDataResult<Colour>(_colourDal.Get(c=>c.Id==Id), Messages.ProductsListed);
        }

        
    }
}
