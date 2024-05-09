ALTER PROCEDURE [dbo].[CreateNewQuizProcedure]
    @CategoryId INT,
    @SubCategoryId INT,
    @GameName NVARCHAR(255) = NULL,
    @Title NVARCHAR(255) = NULL,
    @Question NVARCHAR(255),
    @Image NVARCHAR(255) = NULL,
    @Options NVARCHAR(500),
    @CorrectAnswer INT
AS
BEGIN
    INSERT INTO [DB01].[dbo].[QuizQuestions] (CategoryId, SubCategoryId, GameName, Title, Question, Image, Options, CorrectAnswer, CreatedAt, ModifiedAt)
    VALUES (@CategoryId, @SubCategoryId, @GameName, @Title, @Question, @Image, @Options, @CorrectAnswer, GETDATE(), GETDATE())
END;
GO
