CREATE PROCEDURE [dbo].[GetEmployeeSalesInfo]	
	@StartIdx INT,
	@EndIdx INT,
	@Name NVARCHAR(MAX) = NULL	
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT esi3.*
	FROM (
			SELECT				
				  RowNum = ROW_NUMBER() OVER (ORDER BY esi2.FirstName, esi2.LastName)
				, esi2.*
				, HasMore = CASE WHEN COUNT(esi2.EmployeeID) OVER() > @EndIdx THEN 1 ELSE 0 END
			FROM (
				SELECT e.EmployeeID
					 , e.FirstName
				     , e.LastName
					 , e.Title
					 , SUM(od.Quantity) AS NumberOfProductsSold
					 , e2.FirstName+' '+e2.LastName AS RefersTo
				FROM dbo.Employees e
				LEFT JOIN dbo.Employees e2 ON e.ReportsTo = e2.EmployeeID
				LEFT JOIN dbo.Orders o ON e.EmployeeID = o.EmployeeID
				INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID	
				WHERE @Name IS NULL OR e.FirstName LIKE '%' + @Name + '%' OR e.LastName LIKE '%' + @Name + '%'
				GROUP BY e.EmployeeID, e.FirstName, e.LastName, e.Title, e2.FirstName+' '+e2.LastName			
			) esi2
		) esi3
	WHERE esi3.RowNum > @StartIdx AND esi3.RowNum <= @EndIdx;
END