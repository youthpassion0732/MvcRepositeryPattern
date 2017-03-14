USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Insert_Category]    Script Date: 06/09/2014 12:43:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Insert_Category]

@Name nvarchar(max)

AS
BEGIN

Insert Into Category
            (Name)
     Values (@Name)
     
     
     Select @@Identity as Id

END

GO

