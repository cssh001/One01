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


EXEC [dbo].[QuizQuestionProcedure]  
 @operation = 'DELETE', 
 @Id = 1;

 
EXEC [dbo].[QuizQuestionProcedure]  
 @operation = 'READ';