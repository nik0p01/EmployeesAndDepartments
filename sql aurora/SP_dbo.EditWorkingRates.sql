-- =============================================
-- Author:		<Author,,Simonov NB>
-- Create date: <Create Date,,12.10.2020>
-- Description:	<Description,,Edit WorkingRates>
-- =============================================
CREATE PROCEDURE EditWorkingRates

@namePosition NCHAR(50),
@Chief BIT,
@idDepartment INT,
@idWorkingRates INT

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
		UPDATE WorkingRates
		SET	IdDepartment = @idDepartment, IdWorkPosition=@idWorkPositions, Chief=@Chief 
		WHERE WorkingRates.Id = @idWorkingRates
	COMMIT
END