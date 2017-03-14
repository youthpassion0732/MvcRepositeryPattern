USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_List_Product]    Script Date: 06/09/2014 12:43:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_List_Product]

AS
BEGIN

	SELECT * From Product

END

GO

