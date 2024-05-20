CREATE OR ALTER PROCEDURE [dbo].[CreateNewTourProcedure] (
  @TourImages int,
  @Thumbnail nvarchar(255),
  @Title nvarchar(255),
  @CountryId int,
  @ProvinceId int,
  @DistrictId int,
  @AreaName nvarchar(255),
  @Price int,
  @Description nvarchar(max),
  @MapEmbed nvarchar(255)
)
AS
BEGIN

  INSERT INTO [dbo].[Tourses] (
    [TourImages],
    [Thumbnail],
    [Title],
    [CountryId],
    [ProvinceId],
    [DistrictId],
    [AreaName],
    [Price],
    [Description],
    [MapEmbed],
    [CreatedAt],
    [ModifiedAt]
  )
  VALUES (
    @TourImages,
    @Thumbnail,
    @Title,
    @CountryId,
    @ProvinceId,
    @DistrictId,
    @AreaName,
    @Price,
    @Description,
    @MapEmbed,
    GETDATE(), 
    GETDATE()  
  );
END;