CREATE PROCEDURE [dbo].[District_DeleteDataProcedure]
(
  @Id INTEGER
)
AS
BEGIN
  DELETE FROM [dbo].[District]
  WHERE [Id] = @Id;
END;