CREATE
OR ALTER PROCEDURE [dbo].[UpdateProvinceProcedure]
    (
    @Id INTEGER,
    @ProvinceCode NVARCHAR(10),
    @NameEn NVARCHAR(50),
    @NameKh NVARCHAR(50),
    @CountryId INTEGER,
    @ProvinceImage NVARCHAR(255)
)
AS
BEGIN
    DECLARE @ExistingId INT;
    SELECT @ExistingId = [Id]
    FROM [dbo].[Province]
    WHERE [Id] = @Id;
    IF (@ExistingId IS NOT NULL) BEGIN
        UPDATE [dbo].[Province]
        SET [ProvinceCode] = @ProvinceCode,
            [NameEn] = @NameEn,
            [NameKh] = @NameKh,
            [CountryId] = @CountryId,
            [ProvinceImage] = @ProvinceImage,
            [ModifiedAt] = GETDATE()
        WHERE [Id] = @Id;
    END
    ELSE 
    BEGIN
        RAISERROR('Province with code ''%s'' not found. Update failed.', 10, 1, @Id);
        -- RAISERROR('Province with code ''%s'' not found. Update failed.');
    END;
END;