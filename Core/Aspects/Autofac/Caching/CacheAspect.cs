using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;  //memory'de kalma süresi
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)   //constructor   
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)  //invocation => method
        {
            //Method.ReflectedType.FullName => methodun bulunduğu kısmın namespace'i
            //biz Cache Keyleri verirken methodun namespacesini, bulunduğu interface'i ve methodun ismini kullanıyoruz. Bu şekilde verilen key ile o an caching yapılacak method hemen bulunabiliyor.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); //arguments = methodun parametreleri. Bunu, parametrelerin eleman olduğu bir liste şeklinde veriyoruz.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // keyi üretirken eğer parametre varsa parametreleri de ekle. yoksa eğer null olarak bırak parametre yerlerini. 
            if (_cacheManager.IsAdd(key))   //cache mevcut mu?
            {
                invocation.ReturnValue = _cacheManager.Get(key);    //cache varmış, o zaman key değeri ile verilen cacheyi memoryden get edip methodun hazırda bulunan return valuesi olarak gönder gitsin.
                return;
            }
            invocation.Proceed();   //cache memoryde mevcut değil. o zaman methodu çalıştır. 
            _cacheManager.Add(key, invocation.ReturnValue, _duration);  //methodu çalıştırdıktan sonra cacheye de ekle.
        }
    }
}
