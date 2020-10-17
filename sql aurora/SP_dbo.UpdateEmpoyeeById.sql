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