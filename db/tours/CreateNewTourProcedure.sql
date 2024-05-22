CREATE OR ALTER PROCEDURE [dbo].[CreateNewTourProcedure] (
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