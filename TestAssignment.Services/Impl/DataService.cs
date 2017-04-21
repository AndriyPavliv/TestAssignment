using System.Collections.Generic;
using System.Linq;
using TestAssignment.Infrastructure.EF;

namespace TestAssignment.Services.Impl
{
    public class DataService : IDataService
    {
        public IList<EmployeeSales> LoadEmployeeSales(int pageIdx, int pageSize, string name)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.GetEmployeeSalesInfo((pageIdx - 1) * pageSize, pageIdx * pageSize, name).ToList();                
            }
        }
    }
}