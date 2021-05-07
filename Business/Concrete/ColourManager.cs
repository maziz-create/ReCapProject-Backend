using Business.Abstract;
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

        public void Add(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _colourDal.Add(colour);
        }

        public void Delete(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            _colourDal.Delete(colour);
        }

        public List<Colour> GetAll()
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return _colourDal.GetAll();
        }

        public Colour GetById(int Id)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap
            return _colourDal.Get(c=>c.Id==Id);
        }

        public void Update(Colour colour)
        {
            //şartlar şartlar şartlar
            //uygunsa buyur yap

            //güncelleme işini anlamakta sorun yaşıyorum...
            _colourDal.Update(colour);
        }
    }
}
