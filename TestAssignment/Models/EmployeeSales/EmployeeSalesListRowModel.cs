namespace TestAssignment.Models.EmployeeSales
{
    public class EmployeeSalesListRowModel
    {
        public long RowNum { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public long NumberOfProductsSold { get; set; }
        public string RefersTo { get; set; }

        public EmployeeSalesListRowModel(Infrastructure.EF.EmployeeSales entity)
        {
            RowNum = entity.RowNum.GetValueOrDefault();
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Title = entity.Title;
            NumberOfProductsSold = entity.NumberOfProductsSold.GetValueOrDefault();
            RefersTo = entity.RefersTo;
        }
    }
}