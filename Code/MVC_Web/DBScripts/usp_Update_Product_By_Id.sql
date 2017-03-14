USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Update_Product_By_Id]    Script Date: 06/09/2014 12:43:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Update_Product_By_Id]

@ProductId int,
@CategoryId int,
@Name nvarchar(max),
@Price decimal(18,2)

AS
BEGIN

   UPDATE [StoreDB].[dbo].[Product]
   SET [CategoryId] = @CategoryId
      ,[Name] = @Name
      ,[Price] = @Price
 WHERE ProductId = @ProductId

END

GO

