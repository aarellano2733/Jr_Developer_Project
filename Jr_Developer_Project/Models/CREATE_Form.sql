USE [Form]
GO

/****** Object:  Table [dbo].[Form]    Script Date: 2/28/2019 10:28:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Form](
	[FormId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY]
GO

