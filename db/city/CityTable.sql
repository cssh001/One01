CREATE TABLE [dbo].[City] 
(
    Id INTEGER IDENTITY(1,1) NOT NULL,
    CityName VARCHAR(255) NOT NULL,
    CountryId INTEGER NOT NULL,
    CityImage NVARCHAR(255),
    CreatedAt DATETIME,
    ModifiedAt DATETIME,
);