CREATE OR ALTER PROC [dbo].[DeleteCourseProcedure]
    (
    @Id INTEGER)
AS
BEGIN
    DELETE FROM [dbo].[CourseVideo]
    WHERE [Id] = @Id;
END;


