CREATE PROCEDURE [dbo].[District_GetAllDataProcedures]
AS
BEGIN
  SELECT 
    d.Id,
    d.ProvinceId,
    p.[NameEn] AS ProvinceName, 
    d.NameEn,
    d.NameKh,
    d.DistrictImage,
    d.DistrictCode,
    d.CreatedAt,
    d.ModifiedAt
  FROM [dbo].[District] d
  INNER JOIN [dbo].[Province] p ON d.[Id] = p.[Id];
END;