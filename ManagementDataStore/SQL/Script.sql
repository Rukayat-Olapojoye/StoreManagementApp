USE [StoreManagementDataStore]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/15/2021 8:23:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [varchar](100) NOT NULL,
	[CustomerFirstName] [varchar](100) NOT NULL,
	[CustomerLastName] [varchar](100) NOT NULL,
	[CustomerEmail] [varchar](100) NOT NULL,
	[CustomerPassword] [varchar](50) NOT NULL,
	[ConfirmPassword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 8/15/2021 8:23:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[CustomerId] [varchar](100) NOT NULL,
	[StoreID] [varchar](100) NOT NULL,
	[StoreName] [varchar](100) NOT NULL,
	[StoreType] [varchar](50) NOT NULL,
	[Products] [int] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerEmail], [CustomerPassword], [ConfirmPassword]) VALUES (N'CUS-2021143103', N'Della', N'Adams', N'della@gmail.com', N'della@21', N'della@21')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerEmail], [CustomerPassword], [ConfirmPassword]) VALUES (N'CUS-20211437871', N'TOLA', N'Adegbite', N'tol@gmail.com', N'tol@123', N'tol@123')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFirstName], [CustomerLastName], [CustomerEmail], [CustomerPassword], [ConfirmPassword]) VALUES (N'CUS-2021154349', N'Dayo', N'Adams', N'dayo@gmail.com', N'dayo@21', N'dayo@21')
GO
INSERT [dbo].[Store] ([CustomerId], [StoreID], [StoreName], [StoreType], [Products]) VALUES (N'CUS-2021143103', N'STORE-KSK-1547944', N'DellaKiosk', N'Kiosk', 238)
INSERT [dbo].[Store] ([CustomerId], [StoreID], [StoreName], [StoreType], [Products]) VALUES (N'CUS-2021154349', N'STORE-SPMT-1519201', N'Dayo', N'Supermarket', 56)
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Store] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Customer_Store]
GO
