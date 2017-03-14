USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Get_Product_By_Id]    Script Date: 06/09/2014 12:42:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Get_Product_By_Id]

@ProductId int

AS
BEGIN

	Select Product.*, Category.Name as CategoryName 
	From Product Inner Join Category ON Category.CategoryId = Product.CategoryId
	Where Product.ProductId = @ProductId

END

GO

