CREATE TABLE [dbo].[District]
(
    Id INTEGER PRIMARY KEY IDENTITY(1,1),
    ProvinceId INTEGER NOT NULL,
    NameEn NVARCHAR(50) NOT NULL,
    NameKh NVARCHAR(50) NOT NULL,
    DistrictImage NVARCHAR(255),
    DistrictCode NVARCHAR(10),
    CreatedAt DATETIME,
    ModifiedAt DATETIME,
);