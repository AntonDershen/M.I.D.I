using BussinessLogic.Interface.Services;
using BussinessLogic.Services;
using DataAccess.Interface.Repositories;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ninject;
using DataAccess.Interface.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ResolveModule
{
    public static class ResolveConfig
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            kernel.Bind<DbContext>().To<Context>().InSingletonScope();

            kernel.Bind<IMusicRepository>().To<MusicRepository>();
            kernel.Bind<IMusicService>().To<MusicService>();
        }
      
    }
}
