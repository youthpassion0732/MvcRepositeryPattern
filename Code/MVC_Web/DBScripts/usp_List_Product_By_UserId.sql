USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_List_Product_By_UserId]    Script Date: 06/09/2014 12:43:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_List_Product_By_UserId]

@User_Id nvarchar(128)

AS
BEGIN

    Select * 
    From Product Inner Join UserProduct ON UserProduct.ProductId = Product.ProductId 
    Inner JOIN Category ON Category.CategoryId = Product.CategoryId     
    Where UserProduct.UserId = @User_Id

END

GO

