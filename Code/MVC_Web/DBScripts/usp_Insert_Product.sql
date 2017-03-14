USE [StoreDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_Insert_Product]    Script Date: 06/09/2014 12:43:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Insert_Product]

@CategoryId int,
@Name nvarchar(max),
@Price decimal(18,2),
@User_Id nvarchar(128)

AS
BEGIN

Declare @ProductId int = -1

INSERT INTO [StoreDB].[dbo].[Product]
           ([CategoryId]
           ,[Name]
           ,[Price])
     VALUES
           (@CategoryId
           ,@Name
           ,@Price)

Set @ProductId = @@Identity

	IF @ProductId > 0
	begin
		INSERT INTO [StoreDB].[dbo].[UserProduct]
				   ([ProductId]
				   ,[UserId])
			 VALUES
				   (@ProductId
				   ,@User_Id)
				   
	end
           
Select @ProductId as Id

END

GO

