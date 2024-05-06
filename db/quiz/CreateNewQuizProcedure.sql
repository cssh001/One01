USE [DB01]
GO

/****** Object:  StoredProcedure [dbo].[CreateNewQuizProcedure]    Script Date: 5/5/2024 5:07:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CreateNewQuizProcedure]
    @CategoryId INT,
    @SubCategoryId INT,
    @UserId INT,
    @GameName NVARCHAR(255) = NULL,
    @Title NVARCHAR(255) = NULL,
    @Question NVARCHAR(255),
    @Image NVARCHAR(255) = NULL,
    @Options NVARCHAR(500),
    @CorrectAnswer INT
AS
BEGIN
    INSERT INTO [DB01].[dbo].[QuizQuestions] (CategoryId, SubCategoryId, UserId, GameName, Title, Question, Image, Options, CorrectAnswer)
    VALUES (@CategoryId, @SubCategoryId, @UserId, @GameName, @Title, @Question, @Image, @Options, @CorrectAnswer);
END;
GO
