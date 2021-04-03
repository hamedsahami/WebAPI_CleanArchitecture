using AutoMapper;
using Hahn.ApplicationProcess.February2021.Data.Interfaces;
using Hahn.ApplicationProcess.February2021.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            //services.AddScoped(typeof(IMapper),typeof(Mapper));

          
        }
    }
}
