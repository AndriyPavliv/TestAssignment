namespace TestAssignment.Models.EmployeeSales
{
    public class EmployeeSalesListRowModel
    {
        public int RowNum { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int NumberOfProductsSold { get; set; }
        public string RefersTo { get; set; }
    }
}