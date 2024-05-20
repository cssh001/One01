CREATE OR ALTER PROC UpdateCityProcedure
    (
    @Id INTEGER,
    @CityName NVARCHAR(255),
    @CountryId INTEGER,
    @CityImage NVARCHAR(255)
)
AS
BEGIN
    UPDATE [dbo].[City] 
    SET [CityName] = @CityName, [CountryId] = @CountryId, [CityImage] = @CityImage, [ModifiedAt] = GETDATE()
    WHERE [Id] = @Id;
END;

