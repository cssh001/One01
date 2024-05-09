ALTER PROCEDURE [dbo].[GetAllSubCategoriesProcedure]
AS 
BEGIN
	SELECT SubCat.[Id],
		SubCat.[CategoryId],
		SubCat.[SubCategoryName],
		SubCat.[Description],
		COUNT(quiz.[Id]) as TotalQuizzes,
		Cat.[CategoryName],
		SubCat.[CreatedAt]
	FROM [dbo].[SubCategories] as SubCat
		INNER JOIN [dbo].[Categories] Cat ON Cat.Id = SubCat.CategoryId
		LEFT JOIN [dbo].[QuizQuestions] quiz ON quiz.[SubCategoryId] = SubCat.[Id]
	GROUP BY SubCat.[Id], SubCat.[CategoryId], SubCat.[SubCategoryName], SubCat.[Description], Cat.[CategoryName], SubCat.[CreatedAt]
	ORDER BY SubCat.[Id] DESC;
END;


