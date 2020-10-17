CREATE PROCEDURE [GetAllDepartments]

AS
BEGIN

  SET NOCOUNT ON;
  SELECT *
  FROM dbo.Departments  as D
  
END