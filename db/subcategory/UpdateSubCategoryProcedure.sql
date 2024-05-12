CREATE PROCEDURE [dbo].[UpdateSubCategoryProcedure]
    (
    @Id INT,
    @CategoryId INT,
    @SubCategoryName NVARCHAR(50),
    @Image VARCHAR(50),
    @Description NVARCHAR(MAX)
)
AS
BEGIN
    UPDATE [dbo].[SubCategories] 
    SET [CategoryId] = @CategoryId,
        [SubCategoryName]  = @SubCategoryName,
        [Image] = @Image,
        [Description] = @Description,
        [ModifiedAt] = GETDATE()
    WHERE [Id] = @Id;
END;
