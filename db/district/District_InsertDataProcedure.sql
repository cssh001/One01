CREATE OR ALTER PROCEDURE [dbo].[District_InsertDataProcedure]
(
  @ProvinceId int,
  @NameEn nvarchar(50),
  @NameKh nvarchar(50),
  @DistrictImage nvarchar(255),
  @DistrictCode nvarchar(10)
)
AS
BEGIN
  INSERT INTO [dbo].[District] ([ProvinceId], [NameEn], [NameKh], [DistrictImage], [DistrictCode], [CreatedAt], [ModifiedAt])
  VALUES (@ProvinceId, @NameEn, @NameKh, @DistrictImage, @DistrictCode, GETDATE(), GETDATE());
END;



EXEC dbo.District_InsertDataProcedure 
  @ProvinceId = 10,
  @NameEn = 'Phnom Penh Thmey',
  @NameKh = 'ភ្នំព Penh ថ្មئي',
  @DistrictImage = 'path/to/image.jpg',
  @DistrictCode = 'PP001'


