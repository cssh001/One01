EXEC [dbo].[UpdateQuizProcedure]
    @QuizId = 1,
    @CategoryId = 1,
    @UserId = 456,
    @GameName = 'Sample Game',
    @Title = 'Sample Title',
    @Question = 'Sample Question?',
    @Image = 'image.jpg',
    @Options = '["Option A", "Option B", "Option C", "Option D"]',
    @CorrectAnswer = 1;

