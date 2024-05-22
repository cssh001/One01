CREATE PROCEDURE [TourImage_CreateProcedure] 
(
  @TourId int,
  @ImageName nvarchar(255),
  @ImageOrder int
)
AS
BEGIN
  INSERT INTO [dbo].[TourImages] (TourId, ImageName, ImageOrder)
  VALUES (@TourId, @ImageName, @ImageOrder);
END;