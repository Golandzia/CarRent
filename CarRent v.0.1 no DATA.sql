USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 20.03.2023 23:56:22 ******/
CREATE DATABASE [CarRent]
 
USE [CarRent]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[First_name] [nvarchar](40) NOT NULL,
	[Second_name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Phone_number] [nvarchar](22) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Post] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[State_registration_plate] [nvarchar](10) NOT NULL,
	[Make] [int] NOT NULL,
	[Model] [int] NOT NULL,
	[Power] [int] NOT NULL,
	[Last_maintance] [date] NOT NULL,
	[Mileage] [int] NOT NULL,
	[Color] [int] NOT NULL,
	[Luxury_coefficient] [decimal](18, 0) NOT NULL,
	[Price_per_hour] [money] NOT NULL,
	[Price_per_day] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Make_of_car]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make_of_car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model_of_car]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model_of_car](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Make] [int] NOT NULL,
	[Model] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Car] [int] NOT NULL,
	[Renter] [int] NOT NULL,
	[Rent_type] [nvarchar](200) NOT NULL,
	[Agent] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Renter]    Script Date: 20.03.2023 23:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Passport_num] [nvarchar](30) NULL,
	[Country] [nvarchar](30) NOT NULL,
	[Driver_license_num] [nvarchar](30) NOT NULL,
	[Expirence_of_driving] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[Phone_number] [nvarchar](22) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [FK_Agent_Post] FOREIGN KEY([Post])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [FK_Agent_Post]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Color] FOREIGN KEY([Color])
REFERENCES [dbo].[Color] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Color]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Make_of_car] FOREIGN KEY([Make])
REFERENCES [dbo].[Make_of_car] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Make_of_car]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Model_of_car] FOREIGN KEY([Model])
REFERENCES [dbo].[Model_of_car] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Model_of_car]
GO
ALTER TABLE [dbo].[Model_of_car]  WITH CHECK ADD  CONSTRAINT [FK_Model_of_car_Make_of_car] FOREIGN KEY([Make])
REFERENCES [dbo].[Make_of_car] ([ID])
GO
ALTER TABLE [dbo].[Model_of_car] CHECK CONSTRAINT [FK_Model_of_car_Make_of_car]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Agent] FOREIGN KEY([Agent])
REFERENCES [dbo].[Agent] ([ID])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Agent]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Car] FOREIGN KEY([Car])
REFERENCES [dbo].[Car] ([ID])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Car]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Renter] FOREIGN KEY([Renter])
REFERENCES [dbo].[Renter] ([ID])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Renter]
GO
USE [master]
GO
ALTER DATABASE [CarRent] SET  READ_WRITE 
GO
