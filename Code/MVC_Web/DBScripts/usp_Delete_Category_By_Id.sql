USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Delete_Category_By_Id]    Script Date: 06/09/2014 12:42:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Delete_Category_By_Id]

@CategoryId int

AS
BEGIN

	Delete from Category Where Category.CategoryId = @CategoryId

END

GO

