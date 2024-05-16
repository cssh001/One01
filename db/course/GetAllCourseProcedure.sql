ALTER PROC [dbo].[GetAllCourseProcedure]
AS 
BEGIN
    SELECT TOP 200 
    [Id], [CategoryId], [SubCategoryId], [Title], [VideoLink], [Credit], [Description],[CreatedAt], [ModifiedAt]
    FROM [dbo].[CourseVideo]
    ORDER BY [CreatedAt] DESC;
END;



TRUNCATE TABLE [dbo].[CourseVideo];