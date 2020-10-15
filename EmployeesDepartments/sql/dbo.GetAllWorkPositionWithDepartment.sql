-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,11.10.2020>
-- Description:	<Description,,Show list of departments with chief>
-- =============================================
CREATE PROCEDURE [GetAllWorkPositionWithDepartment]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT D.Name AS DepartmentName, WP.Name AS PosinionName, WR.Id
	FROM dbo.Departments  as D,dbo.WorkingRates as WR, dbo.WorkPositions AS WP
	WHERE     D.Id= WR.IdDepartment AND WP.Id = WR.IdWorkPosition

END