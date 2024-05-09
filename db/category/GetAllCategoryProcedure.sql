ALTER PROC [dbo].[GetAllCategories]
AS
BEGIN
	SELECT [Id] AS CategoryId, [CategoryName],[Image],[Description],[CreatedAt],[ModifiedAt] FROM [dbo].[Categories]
	ORDER BY [Id] DESC
END;


