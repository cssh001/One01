ALTER PROC [dbo].[CreateNewCourseProcedure]
(
    @Title NVARCHAR(255),
    @CategoryId INTEGER,
    @SubCategoryId INTEGER,
    @VideoLink NVARCHAR(255),
    @Description NVARCHAR(255),
    @Credit VARCHAR(20)
)
AS 
BEGIN
    INSERT INTO [dbo].[CourseVideo] (CategoryId, SubCategoryId, Title, VideoLink, Description, Credit, CreatedAt, ModifiedAt) 
    VALUES (@CategoryId, @SubCategoryId,@Title, @VideoLink, @Description, @Credit, GETDATE(), GETDATE());
END;
