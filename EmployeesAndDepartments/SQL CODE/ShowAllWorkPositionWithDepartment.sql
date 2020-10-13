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
CREATE PROCEDURE ShowAllWorkPositionWithDepartment

AS
BEGIN
	SET NOCOUNT ON;
	SELECT D.Name, WP.Name
	FROM dbo.Departments  as D,dbo.WorkingRates as WR, dbo.WorkPositions AS WP
	WHERE     D.Id= WR.IdDepartment AND WP.Id = WR.IdWorkPosition

END
GO
