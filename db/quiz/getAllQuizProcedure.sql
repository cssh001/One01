ALTER PROC [dbo].[GetAllQuizzes]
AS BEGIN
    SELECT
        quiz.[Id] as QuizId,
        quiz.[CategoryId],
        cat.[CategoryName],
        quiz.[UserId] as UserID,
        quiz.[GameName],
        quiz.[Title],
        quiz.[Question],
        quiz.[Image],
        quiz.[Options],
        quiz.[CorrectAnswer]
    FROM
        [dbo].[QuizQuestions] quiz
        RIGHT JOIN [dbo].[Categories] cat ON quiz.[CategoryId] = cat.[Id]
    ORDER BY quiz.[Id] DESC
END;