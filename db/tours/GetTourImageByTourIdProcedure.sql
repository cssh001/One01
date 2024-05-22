
CREATE OR ALTER PROC [dbo].[GetTourImageByTourIdProcedure]
(@TourId INTEGER)
AS
BEGIN
    SELECT [Id], [TourId], [ImageName], [ImageOrder]
    FROM [dbo].[TourImages] 
    WHERE [TourId] = @TourId
    ORDER BY [ImageOrder] ASC;
END; 

