CREATE OR ALTER PROC UpdateCityProcedure
    (
    @Id INTEGER,
    @CityName NVARCHAR(255),
    @CountryId INTEGER = 0,
    @CityImage NVARCHAR(50)
)
AS
BEGIN
    UPDATE [dbo].[City] 
    SET [CityName] = @CityName, [CountryId] = @CountryId, [CityImage] = @CityImage
    WHERE [Id] = @Id;
END;

