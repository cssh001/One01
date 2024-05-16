CREATE OR ALTER PROCEDURE [dbo].[GetCountsProcedure]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        (SELECT COUNT([CategoryName]) FROM [dbo].[Categories]) AS CategoryCount,
        (SELECT COUNT([Question]) FROM [dbo].[QuizQuestions]) AS QuestionCount,
        (SELECT COUNT([SubCategoryName]) FROM [dbo].[SubCategories]) AS SubCategoryCount,
        (SELECT COUNT([Id]) FROM [dbo].[CourseVideo]) AS VideoCount;
END;
