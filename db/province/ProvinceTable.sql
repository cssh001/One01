CREATE TABLE [dbo].[Province]
( 
    Id INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PrivinceCode NVARCHAR(10),
    NameEn NVARCHAR(50) NOT NULL,
    NameKh NVARCHAR(50),
    CountryId INTEGER NULL,
    ProvinceImage NVARCHAR(255),
    CreatedAt DATETIME NOT NULL,
    ModifiedAt DATETIME NOT NULL,
);