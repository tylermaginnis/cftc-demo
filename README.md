# cftc-demo
cftc-demo

# Schematic

USE [cftc-demo]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 2/28/2022 4:55:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[Publisher] [VARCHAR](255) NULL,
	[Title] [VARCHAR](255) NULL,
	[AuthorLastName] [VARCHAR](255) NULL,
	[AuthorFirstName] [VARCHAR](255) NULL,
	[Price] [DECIMAL](18, 2) NULL,
	[PublicationYear] [INT] NULL,
	[PageCitationStart] [INT] NULL,
	[PageCitationEnd] [INT] NULL,
	[Volume] [INT] NULL,
	[URL] [VARCHAR](255) NULL
) ON [PRIMARY]
GO


# Stored Procedure [sp_SelectBooks]

USE [cftc-demo]
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectBooks]    Script Date: 2/28/2022 4:55:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectBooks]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID]
		  ,[Publisher]
		  ,[Title]
		  ,[AuthorLastName]
		  ,[AuthorFirstName]
		  ,[Price]
		  ,[PublicationYear]
		  ,[PageCitationStart]
		  ,[PageCitationEnd]
		  ,[Volume]
		  ,[URL]
	  FROM [dbo].[Books]
  END
GO

# Stored Procedure [sp_SelectBooks_SortInDb_ByAuthorTitle]



USE [cftc-demo]
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectBooks_SortInDb_ByAuthorTitle]    Script Date: 2/28/2022 4:55:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectBooks_SortInDb_ByAuthorTitle]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID]
		  ,[Publisher]
		  ,[Title]
		  ,[AuthorLastName]
		  ,[AuthorFirstName]
		  ,[Price]
		  ,[PublicationYear]
		  ,[PageCitationStart]
		  ,[PageCitationEnd]
		  ,[Volume]
		  ,[URL]
	  FROM [dbo].[Books]
	  ORDER BY AuthorLastName, AuthorFirstName, Title
  END
GO

# Stored Procedure [sp_SelectBooks_SortInDb_ByPublisherAuthorTitle]

USE [cftc-demo]
GO

/****** Object:  StoredProcedure [dbo].[sp_SelectBooks_SortInDb_ByPublisherAuthorTitle]    Script Date: 2/28/2022 4:56:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectBooks_SortInDb_ByPublisherAuthorTitle]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID]
		  ,[Publisher]
		  ,[Title]
		  ,[AuthorLastName]
		  ,[AuthorFirstName]
		  ,[Price]
		  ,[PublicationYear]
		  ,[PageCitationStart]
		  ,[PageCitationEnd]
		  ,[Volume]
		  ,[URL]
	  FROM [dbo].[Books]
	  ORDER BY Publisher, AuthorLastName, AuthorFirstName, Title
  END
GO




