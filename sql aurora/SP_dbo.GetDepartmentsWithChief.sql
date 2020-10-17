CREATE PROCEDURE [GetDepartmentsWithChief]

AS
BEGIN

  SET NOCOUNT ON;
  SELECT D.Id AS DepartmentID,  D.Name AS NameDepartment,  EMP.Name AS ChiefHame
  FROM dbo.Departments  as D
  LEFT JOIN ( SELECT WR.Id, WR.Chief, E.Name
	FROM dbo.WorkingRates as WR, dbo.EmployeeWorkingRates as EWR, dbo.Employees as E
	WHERE   WR.Id = EWR.IdWorkingRate AND EWR.IdEmployee= E.Id AND WR.Chief =1) AS EMP ON D.Id= EMP.Id
END