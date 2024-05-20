CREATE OR ALTER PROCEDURE GetAllProvinceProcedure
AS
BEGIN
    SELECT TOP (200) 
        [Id],
        [ProvinceCode],
        [NameEn],
        [NameKh],
        [CountryId],
        [ProvinceImage],
        [CreatedAt],
        [ModifiedAt]
    FROM [dbo].[Province]
    ORDER BY [Id] DESC;
END;
