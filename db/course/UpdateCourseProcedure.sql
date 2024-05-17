
CREATE OR ALTER PROC [dbo].[UpdateCourseProcedure]
    @Id INT,
    @CategoryId INT,
    @SubCategoryID INT,
    @Description NVARCHAR(MAX),
    @Credit NVARCHAR(50),
    @VideoLink NVARCHAR(MAX),
    @Title NVARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[CourseVideo] SET
        [CategoryId] = @CategoryId,
        [SubCategoryID] = @SubCategoryID,
        [Description] = @Description,
        [Credit] = @Credit,
        [VideoLink] = @VideoLink,
        [Title] = @Title,
        [ModifiedAt] = GETDATE()
    WHERE [Id] = @Id;
END;