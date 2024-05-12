CREATE PROC [dbo].[DeleteQuizProcedure]
@Id INT
AS 
BEGIN
	DELETE FROM [dbo].[QuizQuestions] WHERE Id = @Id;
END;


