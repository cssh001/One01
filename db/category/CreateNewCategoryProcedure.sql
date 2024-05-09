ALTER PROC [dbo].[CreateNewCategoryProcedure](
    @CategoryName VARCHAR(200),
    @Image VARCHAR(200),
    @Description VARCHAR(200)
) 
AS
BEGIN 
    DECLARE @ExistingCategoryName VARCHAR(200)

    SELECT [@ExistingCategoryName] = [CategoryName] FROM [dbo].[Categories] 
    WHERE [CategoryName] = @CategoryName;

    IF @ExistingCategoryName IS NOT NULL
    BEGIN
        RAISERROR('Category already exists.', 16, 1)
        RETURN
    END
    ELSE 
    BEGIN
        INSERT INTO [dbo].[Categories] ([CategoryName], [Image], [Description], [CreatedAt], [ModifiedAt])
        VALUES (@CategoryName, @Image, @Description, GETDATE(), GETDATE());
    END
END;


