using System.Collections.Generic;

namespace TestAssignment.Models.EmployeeSales
{
    public class EmployeeSalesListViewModel
    {
        public EmployeeSalesFilterModel Filter { get; set; }
        public List<EmployeeSalesListRowModel> EmployeeSales { get; set; }
        public bool HasMore { get; set; }

        public EmployeeSalesListViewModel()
        {
            Filter = new EmployeeSalesFilterModel();
            EmployeeSales = new List<EmployeeSalesListRowModel>();
        }
    }
}