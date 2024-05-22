CREATE OR ALTER PROC [dbo].[TourImages_DeleteByIdPrucedure]
(@Id INTEGER)
AS 
BEGIN
    DELETE FROM [dbo].[TourImages] WHERE [Id] = @Id;
END;