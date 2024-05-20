CREATE OR ALTER PROCEDURE [dbo].[CreateNewProvinceProcedure]
    (
    @ProvinceCode NVARCHAR(10),
    @NameEn NVARCHAR(50),
    @NameKh NVARCHAR(50),
    @CountryId INTEGER,
    @ProvinceImage NVARCHAR(255)
)
AS
BEGIN
    INSERT INTO [dbo].[Province]
        (
        [ProvinceCode],
        [NameEn],
        [NameKh],
        [CountryId],
        [ProvinceImage],
        [CreatedAt],
        [ModifiedAt]
        )
    VALUES
        (
            @ProvinceCode,
            @NameEn,
            @NameKh,
            @CountryId,
            @ProvinceImage,
            GETDATE(),
            GETDATE() 
  );
END;