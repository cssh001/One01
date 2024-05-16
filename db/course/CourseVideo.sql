CREATE TABLE [dbo].[CourseVideo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[Description] [nvarchar](255) NULL,
	[Credit] [varchar](50) NULL,
	[VideoLink] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedAt] [datetime] NULL
);