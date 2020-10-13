-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,11.10.2020>
-- Description:	<Description,,Show list of departments with chief>
-- =============================================
CREATE PROCEDURE DepartmentsWithChief

AS
BEGIN

  SET NOCOUNT ON;
  SELECT D.Id AS DepartmentID,  D.Name AS NameDepartment,  EMP.Name AS ChiefHame
  FROM dbo.Departments  as D
  LEFT JOIN ( SELECT WR.Id, WR.Chief, E.Name
	FROM dbo.WorkingRates as WR, dbo.EmployeeWorkingRates as EWR, dbo.Employees as E
	WHERE   WR.Id = EWR.IdWorkingRate AND EWR.IdEmployee= E.Id AND WR.Chief =1) AS EMP ON D.Id= EMP.Id
END
GO
