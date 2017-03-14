USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Update_Category_By_Id]    Script Date: 06/09/2014 12:43:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Update_Category_By_Id]

@CategoryId int,
@Name nvarchar(max)

AS
BEGIN

	UPDATE [StoreDB].[dbo].[Category]
	   SET [Name] = @Name
	 WHERE CategoryId = @CategoryId

END

GO

