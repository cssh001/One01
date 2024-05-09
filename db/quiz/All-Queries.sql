SELECT * FROM [dbo].[QuizQuestions];
SELECT * FROM [dbo].[Categories];
SELECT * FROM [dbo].[SubCategories];
EXEC [dbo].[GetAllQuizzes]


ALTER TABLE [dbo].[SubCategories]
ADD 
CreatedAt DATETIME,
ModifiedAt DATETIME;

ALTER TABLE [dbo].[SubCategories]

DROP COLUMN CreateAt, UpdateAt;