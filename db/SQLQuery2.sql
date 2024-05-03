USE [DB01]
GO
/****** Object:  StoredProcedure [dbo].[QuizQuestionProcedure]    Script Date: 4/9/2024 11:35:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------ Create store procedure for GameQuiz
ALTER PROCEDURE [dbo].[QuizQuestionProcedure]
     @Operation VARCHAR(5),  -- 'C' for Create, 'R' for Read, 'U' for Update, 'D' for Delete
    @Id INT = NULL,
    @CategoryId INT = NULL,
    @UserId INT = NULL,
    @GameName NVARCHAR(MAX) = NULL,
    @Title NVARCHAR(MAX) = NULL,
    @Question NVARCHAR(MAX) = NULL,
    @Image NVARCHAR(MAX) = NULL,
    @Options NVARCHAR(MAX) = NULL,
    @CorrectAnswer INT = NULL,
    @Answered BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF UPPER(@Operation) = 'CREATE'
    BEGIN
        -- Create (Insert)
        INSERT INTO [dbo].[QuizQuestions] (CategoryId, UserId, GameName, Title, Question, Image, Options, CorrectAnswer, Answered)
        VALUES (@CategoryId, @UserId, @GameName, @Title, @Question, @Image, @Options, @CorrectAnswer, @Answered);
    END
    ELSE IF UPPER(@Operation) = 'READ'
    BEGIN
        -- Read (Select)
        SELECT * FROM [dbo].[QuizQuestions];
    END
    ELSE IF UPPER(@Operation) = 'UPDATE'
    BEGIN
        -- Update
        UPDATE [dbo].[QuizQuestions]
        SET CategoryId = ISNULL(@CategoryId, CategoryId),
            UserId = ISNULL(@UserId, UserId),
            GameName = ISNULL(@GameName, GameName),
            Title = ISNULL(@Title, Title),
            Question = ISNULL(@Question, Question),
            Image = ISNULL(@Image, Image),
            Options = ISNULL(@Options, Options),
            CorrectAnswer = ISNULL(@CorrectAnswer, CorrectAnswer),
            Answered = ISNULL(@Answered, Answered)
        WHERE Id = @Id;
    END
    ELSE IF UPPER(@Operation) = 'DELETE'
    BEGIN
        -- Delete
        DELETE FROM [dbo].[QuizQuestions] WHERE Id = @Id;
    END
END;