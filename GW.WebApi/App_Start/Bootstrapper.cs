using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GW.WebApi.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}