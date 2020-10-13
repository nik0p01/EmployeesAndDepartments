GO
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
-- Create date: <Create Date,,12.10.2020>
-- Description:	<Description,,Show Update Empoyee by id>
-- =============================================
CREATE PROCEDURE UpdateEmpoyeeById
@id INT,
@name NCHAR(50),
@email NCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Employees
	SET  Email =  @email, Name= @name
	WHERE Id = @id
END
GO