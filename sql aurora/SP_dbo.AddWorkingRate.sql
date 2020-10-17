-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,12.10.2020>
-- Description:	<Description,,Show Update Empoyee by id>
-- =============================================
CREATE PROCEDURE [AddWorkingRate]

@namePosition NCHAR(50),
@Chief BIT,
@idDepartment INT

AS
BEGIN
	DECLARE @idWorkPositions INT
	BEGIN TRAN
	SELECT TOP(1) @idWorkPositions = WorkPositions.Id FROM
	WorkPositions
	WHERE WorkPositions.Name = @namePosition
	SELECT @idWorkPositions
	IF @idWorkPositions IS NULL
	BEGIN
		INSERT INTO  WorkPositions( Name)
		VALUES(@namePosition)
		SELECT @idWorkPositions = scope_identity();
	END
	INSERT INTO WorkingRates (IdDepartment, IdWorkPosition, Chief )
	VALUES (@idDepartment, @idWorkPositions, @Chief)
	COMMIT
END