CREATE OR ALTER PROC [dbo].[Tours_DeleteProcedure]
(@TourId INTEGER)
AS 
BEGIN
    DELETE FROM [dbo].[Tourses] WHERE [Id] = @TourId;
    DELETE FROM [dbo].[TourImages] wHERE [TourId] = @TourId;
END;