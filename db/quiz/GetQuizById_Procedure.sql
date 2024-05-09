ALTER PROC [dbo].[GetQuizByIdProcedure]
    (
    @Id INT
)
AS
BEGIN
    SELECT
        quiz.[Id] as QuizId,
        quiz.[CategoryId],
        cat.[CategoryName],
        subCat.[Id] as SubCategoryId,
        subCat.[SubCategoryName],
        quiz.[UserId] as UserID,
        quiz.[GameName],
        quiz.[Title],
        quiz.[Question],
        quiz.[Image],
        quiz.[Options],
        quiz.[CorrectAnswer]
    FROM
        [dbo].[QuizQuestions] quiz
        INNER JOIN [dbo].[Categories] cat ON quiz.[CategoryId] = cat.[Id]
        INNER JOIN [dbo].[SubCategories] subCat ON quiz.[SubCategoryId] = subCat.[Id]
    WHERE quiz.[Id] = @Id
    ORDER BY quiz.[Id] DESC
END;