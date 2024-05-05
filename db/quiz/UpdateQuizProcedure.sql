CREATE PROCEDURE [dbo].[UpdateQuizProcedure]
    @QuizId INT,
    @CategoryId INT = NULL,
    @UserId INT = NULL,
    @GameName NVARCHAR(255) = NULL,
    @Title NVARCHAR(255),
    @Question NVARCHAR(MAX),
    @Image NVARCHAR(255) = NULL,
    @Options NVARCHAR(MAX),
    @CorrectAnswer INT
AS
BEGIN
    UPDATE [dbo].[QuizQuestions]
    SET
        [CategoryId] = @CategoryId,
        [UserId] = @UserId,
        [GameName] = @GameName,
        [Title] = @Title,
        [Question] = @Question,
        [Image] = @Image,
        [Options] = @Options,
        [CorrectAnswer] = @CorrectAnswer
    WHERE
        [Id] = @QuizId
END;