using System.Collections.Generic;
using System.Linq;
using TestAssignment.Infrastructure.EF;

namespace TestAssignment.Services.Impl
{
    public class DataService : IDataService
    {
        public IList<object> LoadEmployeeSales(string name)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                IEnumerable<object> result = context.GetEmployeeSalesInfo(name);
                return result.ToList();
            }
        }
    }
}