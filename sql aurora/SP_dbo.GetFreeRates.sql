-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,11.10.2020>
-- Description:	<Description,,Show list of departments with chief>
-- =============================================
CREATE PROCEDURE [GetFreeRates]

AS
BEGIN
	SELECT D.Name AS DepartmentName, WP.Name AS PositionName, CAST(EWR.SUMHalfRare AS BIT) AS HalfRare  FROM
	(
		SELECT  EWR.IdWorkingRate AS IDWR,COUNT(EWR.IdEmployee) AS COUNT ,  SUM(CAST( EWR.HalfRare AS INT )) AS SUMHalfRare
		FROM  dbo.EmployeeWorkingRates AS EWR
		GROUP BY EWR.IdWorkingRate
	) AS EWR, dbo.WorkingRates AS WR,dbo.Departments AS D, dbo.WorkPositions AS WP
	WHERE ( (EWR.COUNT=0) OR (EWR.COUNT=1 AND EWR.SUMHalfRare=1) ) AND EWR.IDWR = WR.Id AND WR.IdDepartment = D.Id AND WR.IdWorkPosition = WP.Id

END