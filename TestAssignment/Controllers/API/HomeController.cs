using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAssignment.Services;

namespace TestAssignment.Controllers.API
{
    public class HomeController : ApiController
    {
        private readonly IDataService _dataService;        

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;            
        }

    }
}
