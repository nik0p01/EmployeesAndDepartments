-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,12.10.2020>
-- Description:	<Description,,Show list Empoyees by department id>
-- =============================================
CREATE PROCEDURE [GetEmpoyeesByDepartmentId]
@departmentID INT
AS
BEGIN

  SET NOCOUNT ON;
  SELECT E.* , WP.Name 
  FROM dbo.Employees  as E, dbo.EmployeeWorkingRates as EWR, dbo.WorkingRates as WR , dbo.Departments as D, dbo.WorkPositions as WP
  WHERE   D.Id = @departmentID AND  WR.Id = EWR.IdWorkingRate AND EWR.IdEmployee= E.Id AND  D.Id= WR.IdDepartment AND WP.Id = WR.Id
END