ALTER PROCEDURE [dbo].[UpdateQuizProcedure]
    @QuizId INT,
    @CategoryId INT ,
    @SubCategoryId INT ,
    @GameName NVARCHAR(255),
    @Title NVARCHAR(255),
    @Question NVARCHAR(MAX),
    @Image NVARCHAR(255),
    @Options NVARCHAR(MAX),
    @CorrectAnswer INT
AS
BEGIN
    UPDATE [dbo].[QuizQuestions]
    SET
        [CategoryId] = @CategoryId,
        [SubCategoryId] = @SubCategoryId,
        [GameName] = @GameName,
        [Title] = @Title,
        [Question] = @Question,
        [Image] = @Image,
        [Options] = @Options,
        [CorrectAnswer] = @CorrectAnswer
    WHERE
        [Id] = @QuizId
END;