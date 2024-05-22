CREATE TABLE [dbo].[Tourses]
(
    Id INTEGER PRIMARY KEY IDENTITY(1,1),
    TourImageId INTEGER,
    Thumbnail NVARCHAR(255) NOT NULL,
    Title NVARCHAR(255),
    CountryId INTEGER,
    ProvinceId INTEGER,
    DistrictId INTEGER,
    AreaName NVARCHAR(255) NOT NULL,
    Price INTEGER NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    MapEmbed NVARCHAR(255),
    CreatedAt DATETIME,
    ModifiedAt DATETIME,
);