CREATE TABLE [dbo].[FeedBack](
	[FeedBackId] [int] IDENTITY(1,1) NOT NULL,
	[FeedBackCategoryId] [int] NULL,
	[UserId] [int] NULL,
	[ProductId] [int] NULL,
	[FeedBackDesc] [nvarchar](max) NULL,
	[FeedBackIndex] [float] NULL,
	[StarRating] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedBackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([FeedBackCategoryId])
REFERENCES [dbo].[FeedBackCategory] ([CategoryId])
GO

ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
