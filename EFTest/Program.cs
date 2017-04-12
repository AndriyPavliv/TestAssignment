
using System.Linq;
using TestAssignment.Services.Impl;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataSvc = new DataService();
            var result = dataSvc.LoadEmployeeSales(1, 3, string.Empty).ToList();            
        }
    }
}
