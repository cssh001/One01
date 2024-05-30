CREATE OR ALTER PROCEDURE [dbo].[District_UpdateDataProcedure]
    (
    @Id int,
    @ProvinceId int,
    @NameEn nvarchar(50),
    @NameKh nvarchar(50),
    @DistrictImage nvarchar(255) = NULL,
    @DistrictCode nvarchar(10) = NULL
)
AS
BEGIN
    UPDATE [dbo].[District]
  SET [ProvinceId] = @ProvinceId,
      [NameEn] = @NameEn,
      [NameKh] = @NameKh,
      [DistrictImage] = @DistrictImage,
      [DistrictCode] = @DistrictCode,
      [ModifiedAt] = GETDATE()
  WHERE [Id] = @Id;
END;