-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,12.10.2020>
-- Description:	<Description,,Show Update Empoyee by id>
-- =============================================
CREATE PROCEDURE GetEmpoyeeById
@id INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT E.Id ,E.Name , E.Email FROM dbo.Employees AS E
	WHERE Id = @id
END