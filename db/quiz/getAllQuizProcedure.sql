ALTER PROC [dbo].[GetAllQuizzesProcedure]
AS 
BEGIN
    SELECT
        quiz.[Id] as QuizId,
        quiz.[CategoryId],
        cat.[CategoryName],
        subCat.[Id] as SubCategoryId,
        subCat.[SubCategoryName],
        quiz.[GameName],
        quiz.[Title],
        quiz.[Question],
        quiz.[Image],
        quiz.[Options],
        quiz.[CorrectAnswer],
        quiz.[CreatedBy],
        quiz.[ModifiedBy],
        quiz.[CreatedAt],
        quiz.[ModifiedAt]
    FROM
        [dbo].[QuizQuestions] quiz
        INNER JOIN [dbo].[Categories] cat ON quiz.[CategoryId] = cat.[Id]
        INNER JOIN [dbo].[SubCategories] subCat ON quiz.[SubCategoryId] = subCat.[Id]
    ORDER BY quiz.[Id] DESC
END;

