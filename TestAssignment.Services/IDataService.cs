using System.Collections.Generic;

namespace TestAssignment.Services
{
    public interface IDataService
    {
        IList<object> LoadEmployeeSales(string Name);
    }
}