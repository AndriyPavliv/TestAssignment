using System.Collections.Generic;
using TestAssignment.Infrastructure.EF;

namespace TestAssignment.Services
{
    public interface IDataService
    {
        IList<EmployeeSales> LoadEmployeeSales(string Name);
    }
}