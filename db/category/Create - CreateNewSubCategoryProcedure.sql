ALTER PROC [dbo].[CreateNewSubCategoryProcedure]
	(
	@CategoryId INT,
	@SubCategoryName NVARCHAR(50),
	@Image NVARCHAR(200),
	@Description NVARCHAR(200)
)
AS
BEGIN
	IF EXISTS (
	SELECT 1
	FROM [dbo].[Categories]
	WHERE [Id] = @CategoryId
) BEGIN
		INSERT INTO [dbo].[SubCategories]
			(
			[CategoryId],
			[SubCategoryName],
			[Image],
			[Description]
			)
		VALUES
			(
				@CategoryId,
				@SubCategoryName,
				@Image,
				@Description
	);
	END;
ELSE BEGIN
		PRINT 'Category with provided CategoryId does not exist';
	END
END;