CREATE OR ALTER PROC [dbo].[Tour_UpdateProcedure](
    @TourId INTEGER,
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
    UPDATE [dbo].[Tourses] 
  SET [Thumbnail] = @Thumbnail, 
    [Title] = @Title, 
    [CountryId] = @CountryId, 
    [ProvinceId] = @ProvinceId, 
    [DistrictId] = @DistrictId, 
    [AreaName] = @AreaName,
    [Price] = @Price,
    [Description] = @Description,
    [MapEmbed] = @MapEmbed,
    [ModifiedAt] = GETDATE()
    WHERE [Id] = @TourId
END;