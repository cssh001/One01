
CREATE OR ALTER PROC [dbo].[UpdateCourseProcedure]
    @Id INT,
    @CategoryId INT,
    @SubCategoryID INT,
    @Description NVARCHAR(MAX),
    @Credit VARCHAR(20),
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
        [Title] = @Title
    WHERE [Id] = @Id;
END;