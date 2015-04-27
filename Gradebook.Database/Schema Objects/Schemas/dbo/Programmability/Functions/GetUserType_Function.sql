CREATE FUNCTION [dbo].[GetUserType_Function]
(
	@email nvarchar(254)
)
RETURNS TABLE AS RETURN
(
	SELECT [UserType]
	FROM [dbo].[User]
	WHERE [Email] = @email
)
