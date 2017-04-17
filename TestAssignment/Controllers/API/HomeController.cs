using System.Linq;
using System.Web.Http;
using TestAssignment.Models.EmployeeSales;
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

        [HttpPost]
        public EmployeeSalesListViewModel Search(EmployeeSalesFilterModel filter)
        {
            var model = new EmployeeSalesListViewModel { Filter = filter };
            LoadEmployeeSales(model);

            return model;
        }

        private void LoadEmployeeSales(EmployeeSalesListViewModel model)
        {
            var res = _dataService.LoadEmployeeSales(model.Filter.Name);
            model.EmployeeSales = res.Select(x => new EmployeeSalesListRowModel(x)).ToList();             
        }
    }
}