using Core.Entities;
//using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // class: referans tip olsun gönderilen şey. int tarzı değer tipler gönderilmesin
    // IEntity(X) : gönderilen şey X ya da X ' i implemente eden bir şey olsun.
    // new() : newlenebilir olmalı... interfaceler newlenemez o yüzden interface olan IEntity gönderme diyor...
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtre gönderim durumu olursa o filtreye göre çalış.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
