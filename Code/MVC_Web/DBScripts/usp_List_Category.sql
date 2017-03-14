USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_List_Category]    Script Date: 06/09/2014 12:43:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_List_Category]

AS
BEGIN

	SELECT * from category

END

GO

