USE [C:\T2\EMPLOYEESANDDEPARTMENTS.MDF]
GO

/****** Object:  Table [dbo].[EmployeeWorkingRates]    Script Date: 17.10.2020 22:03:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeWorkingRates](
	[IdEmployee] [int] NOT NULL,
	[IdWorkingRate] [int] NOT NULL,
	[HalfRare] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeWorkingRate] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC,
	[IdWorkingRate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeWorkingRates]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeWorkingRates_Employees] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employees] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeWorkingRates] CHECK CONSTRAINT [FK_EmployeeWorkingRates_Employees]
GO

ALTER TABLE [dbo].[EmployeeWorkingRates]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeWorkingRates_WorkingRates] FOREIGN KEY([IdWorkingRate])
REFERENCES [dbo].[WorkingRates] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeWorkingRates] CHECK CONSTRAINT [FK_EmployeeWorkingRates_WorkingRates]
GO

