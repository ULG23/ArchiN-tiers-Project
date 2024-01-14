using System;
using JeBalance.DTOs;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace JeBalance.Services
{
    public class DenonciationAppService : ApplicationService, IDenonciationAppService, ITransientDependency
	{


        [HttpPost]
        public Guid PostCreateDenonciation(DenonciationDTO _denonciation)
        {

            return new Guid();
        }
    }
}

