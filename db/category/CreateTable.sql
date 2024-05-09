CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[Image] [varchar](250) NULL,
	[Description] [varchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedAt] [datetime] NULL,
);


