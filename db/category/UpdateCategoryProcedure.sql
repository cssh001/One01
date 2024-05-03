ALTER PROC [dbo].[UpdateCategoryProcedure]
	(
	@CategoryId INT,
	@CategoryName NVARCHAR(200),
	@Description NVARCHAR(250)
)
AS 
BEGIN
	UPDATE [dbo].[Categories] SET [CategoryName] = @CategoryName, [Description] = @Description WHERE [Id] = @CategoryId;
END;

-- EXEC [dbo].[UpdateCategoryProcedure] 'CSS2', 'Css2 just update data from senghong', 2;