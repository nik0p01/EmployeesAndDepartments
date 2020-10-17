USE [C:\T2\EMPLOYEESANDDEPARTMENTS.MDF]
GO

/****** Object:  Table [dbo].[WorkingRates]    Script Date: 17.10.2020 22:04:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkingRates](
	[IdDepartment] [int] NOT NULL,
	[IdWorkPosition] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Chief] [bit] NOT NULL,
 CONSTRAINT [PK_WorkingRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WorkingRates]  WITH CHECK ADD  CONSTRAINT [FK_WorkingRates_Departments] FOREIGN KEY([IdDepartment])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkingRates] CHECK CONSTRAINT [FK_WorkingRates_Departments]
GO

ALTER TABLE [dbo].[WorkingRates]  WITH CHECK ADD  CONSTRAINT [FK_WorkingRates_WorkPositions] FOREIGN KEY([IdWorkPosition])
REFERENCES [dbo].[WorkPositions] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkingRates] CHECK CONSTRAINT [FK_WorkingRates_WorkPositions]
GO

