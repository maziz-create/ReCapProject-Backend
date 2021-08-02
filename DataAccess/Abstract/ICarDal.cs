using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null); //eğer bir şart varsa, onu da al.



        //alttaki bütün fonksiyonlar silinecek. Üstteki fonksiyona dökülecek her şey.
        List<CarDetailDto> GetCarDetailsByBrandId(int id);
        List<CarDetailDto> GetCarDetailsByColourId(int id);
        List<CarDetailDto> GetCarDetail(int id);
        List<CarDetailDto> GetCarsByBrandIdAndColorId(int brandId, int colourId);
    }
}
