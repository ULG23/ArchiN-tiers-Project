using System;
using JeBalance.DTOs;
using Volo.Abp.DependencyInjection;

namespace JeBalance.Services
{
	public class DenonciationAppService : IDenonciationAppService, ITransientDependency
	{

        public Guid CreateDenonciation(DenonciationDTO _denonciation)
        {
            

            return new Guid();
        }
    }
}

