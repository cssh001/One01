CREATE OR ALTER PROCEDURE CreateNewCityProcedure
(
  @CityName nvarchar(255),
  @CountryId int = 855,
  @CityImage nvarchar(255)
)
AS
BEGIN
  INSERT INTO [dbo].[City] (CityName, CountryId, CityImage, CreatedAt, ModifiedAt)
  VALUES (@CityName, @CountryId, @CityImage, GETDATE(), GETDATE());
END;