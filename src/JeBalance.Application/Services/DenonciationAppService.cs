using System;
using JeBalance.DTOs;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;

namespace JeBalance.Services
{
    public class DenonciationAppService : IDenonciationAppService, ITransientDependency
	{


        [HttpPost]
        public Guid CreateDenonciation(DenonciationDTO _denonciation)
        {

            return new Guid();
        }
    }
}

