USE [RequestIt]
GO
/****** Object:  Table [dbo].[CompoundProducts]    Script Date: 08/06/2017 00:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompoundProducts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[compoundProductId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_CompoundProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 08/06/2017 00:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[salePrice] [decimal](19, 2) NOT NULL,
	[costPrice] [decimal](19, 2) NOT NULL,
	[isCompound] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Requests]    Script Date: 08/06/2017 00:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeName] [varchar](50) NOT NULL,
	[requestDate] [datetime] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestsItems]    Script Date: 08/06/2017 00:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestsItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[requestId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_RequestsItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CompoundProducts]  WITH CHECK ADD  CONSTRAINT [FK_CompoundProducts_Compounds] FOREIGN KEY([compoundProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[CompoundProducts] CHECK CONSTRAINT [FK_CompoundProducts_Compounds]
GO
ALTER TABLE [dbo].[CompoundProducts]  WITH CHECK ADD  CONSTRAINT [FK_CompoundProducts_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[CompoundProducts] CHECK CONSTRAINT [FK_CompoundProducts_Products]
GO
ALTER TABLE [dbo].[RequestsItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestsItems_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[RequestsItems] CHECK CONSTRAINT [FK_RequestsItems_Products]
GO
ALTER TABLE [dbo].[RequestsItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestsItems_Requests] FOREIGN KEY([requestId])
REFERENCES [dbo].[Requests] ([id])
GO
ALTER TABLE [dbo].[RequestsItems] CHECK CONSTRAINT [FK_RequestsItems_Requests]
GO
