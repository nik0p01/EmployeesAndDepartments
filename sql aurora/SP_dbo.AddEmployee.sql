﻿-- =============================================
-- Author:		SimonovNB
-- Create date: 11.10.2020
-- Description:	Add new Employee
-- =============================================
CREATE PROCEDURE AddEmployee
	-- Add the parameters for the stored procedure here
	@name NVARCHAR(50),
	@email NVARCHAR(50),
	@HalfRate bit,
	@idWorkingRates INT
	AS
	BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 DECLARE     @idEmployee  int  

	BEGIN TRAN
	INSERT INTO  Employees( Name, Email)
	VALUES(@name, @email)
	SELECT @idEmployee = scope_identity();

	INSERT INTO  EmployeeWorkingRates( IdEmployee , IdWorkingRate, HalfRare)
	VALUES(@idEmployee, @idWorkingRates, @HalfRate)
	

	COMMIT
	
END