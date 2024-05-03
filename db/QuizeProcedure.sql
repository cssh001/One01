CREATE TABLE QuizQuestions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT,
    UserId INT,
    GameName NVARCHAR(255),
    Title NVARCHAR(255),
    Question NVARCHAR(MAX) NOT NULL,
    Image NVARCHAR(255),
    Options NVARCHAR(MAX) NOT NULL,
    CorrectAnswer INT NOT NULL,
    Answered BIT
);

INSERT INTO [dbo].[QuizQuestions] (CategoryId, UserId, GameName, Title, Question, Image, Options, CorrectAnswer, Answered)
VALUES 
(2, 1, 'Game2', 'Title 2', 'Question 2', NULL, '["a","b","c","d"]', 2, 0)


SELECT * FROM [dbo].[QuizQuestions];

------ Create store procedure for GameQuiz
CREATE PROCEDURE QuizQuestionProcedure
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
    IF @Operation = 'Create'
    BEGIN
        -- Create (Insert)
        INSERT INTO [dbo].[QuizQuestions] (CategoryId, UserId, GameName, Title, Question, Image, Options, CorrectAnswer, Answered)
        VALUES (@CategoryId, @UserId, @GameName, @Title, @Question, @Image, @Options, @CorrectAnswer, @Answered);
    END
    ELSE IF @Operation = 'Read'
    BEGIN
        -- Read (Select)
        SELECT * FROM [dbo].[QuizQuestions];
    END
    ELSE IF @Operation = 'Update'
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
    ELSE IF @Operation = 'Delete'
    BEGIN
        -- Delete
        DELETE FROM [dbo].[QuizQuestions] WHERE Id = @Id;
    END
END;



----- 
DECLARE @Operation VARCHAR(5) = 'Create';
DECLARE @CategoryId INT = 1;
DECLARE @UserId INT = 2;
DECLARE @GameName NVARCHAR(MAX) = 'HEllo';
DECLARE @Title NVARCHAR(MAX) = '1234dd';
DECLARE @Question NVARCHAR(MAX) = '1234';
DECLARE @Image NVARCHAR(MAX) = '234534';
DECLARE @Options NVARCHAR(MAX) = 'sdfdsfsdfsdf';
DECLARE @CorrectAnswer INT = 1;
DECLARE @Answered BIT = 0;

EXEC [dbo].[QuizQuestionProcedure] 
    @Operation = @Operation,
    @CategoryId = @CategoryId,
    @UserId = @UserId,
    @GameName = @GameName,
    @Title = @Title,
    @Question = @Question,
    @Image = @Image,
    @Options = @Options,
    @CorrectAnswer = @CorrectAnswer,
    @Answered = @Answered;

EXEC [dbo].[QuizQuestionProcedure] @operation = 'Read';