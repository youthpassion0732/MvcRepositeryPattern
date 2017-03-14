USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Delete_Product_By_Id]    Script Date: 06/09/2014 12:42:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Delete_Product_By_Id]

@ProductId int

AS
BEGIN

	Delete from Product Where Product.ProductId = @ProductId
	Delete from UserProduct Where UserProduct.ProductId = @ProductId

END

GO

