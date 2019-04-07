CREATE TABLE [dbo].[ProductQuestions](
	[questionId] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[questionDescription] [varchar](max) NOT NULL,
	[questionType] [varchar](30) NOT NULL,
	[FeedBackCategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[questionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
