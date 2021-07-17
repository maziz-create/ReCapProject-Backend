using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection); //collection yüklenecek.
        //örnek collectionlar => IHttpAccessor(İstek takipçisi), caching => ICacheManager
    }
}
