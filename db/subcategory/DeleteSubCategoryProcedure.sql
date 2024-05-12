CREATE PROC [dbo].[DeleteSubCategoryProcedure]
(
@Id INT
)
AS 
BEGIN
	DELETE FROM [dbo].[SubCategories] WHERE [Id]= @Id;
	DELETE FROM [dbo].[QuizQuestions] WHERE [SubCategoryId] = @Id;
END;


