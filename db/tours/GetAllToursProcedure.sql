CREATE OR ALTER PROCEDURE [dbo].[GetAllToursProcedure]
AS
BEGIN

    SELECT
        [Id],
        [TourImages],
        [Thumbnail],
        [Title],
        [CountryId],
        [ProvinceId],
        [DistrictId],
        [AreaName],
        [Description],
        [Price],
        [MapEmbed],
        [CreatedAt],
        [ModifiedAt]
    FROM [dbo].[Tourses]
    ORDER BY [Id] DESC;
END;
