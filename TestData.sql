USE [cftc-demo]
GO

INSERT INTO [dbo].[Books]
           ([Publisher]
           ,[Title]
           ,[AuthorLastName]
           ,[AuthorFirstName]
           ,[Price])
     VALUES
           ('Acme Book Publication'
           ,'Learn to Code: Tutorials for Laid Off Journalists'
           ,'Alphis'
           ,'Numeralis'
           ,42.99)
GO


USE [cftc-demo]
GO

INSERT INTO [dbo].[Books]
           ([Publisher]
           ,[Title]
           ,[AuthorLastName]
           ,[AuthorFirstName]
           ,[Price])
     VALUES
           ('Abacus Books, Inc.'
           ,'Counting by Hand: Abacus Operation'
           ,'Jon'
           ,'Sigma'
           ,14.99)
GO



INSERT INTO [dbo].[Books]
           ([Publisher]
           ,[Title]
           ,[AuthorLastName]
           ,[AuthorFirstName]
           ,[Price])
     VALUES
           ('Conventional Novelties, Inc.'
           ,'Coffee Table Book about Coffee Tables'
           ,'Jerry'
           ,'Seinfeld'
           ,28.99)
GO


INSERT INTO [dbo].[Books]
           ([Publisher]
           ,[Title]
           ,[AuthorLastName]
           ,[AuthorFirstName]
           ,[Price])
     VALUES
           ('Supply Chain Management Institute'
           ,'End-to-End Logistics: A Primer'
           ,'Fob'
           ,'Jefferson'
           ,110.99)
GO


UPDATE dbo.Books SET PublicationYear = 1988, PageCitationStart = 1, PageCitationEnd = 100, Volume=4, [URL] = 'https://www.google.com'

