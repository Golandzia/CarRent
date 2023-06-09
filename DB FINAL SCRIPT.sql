USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 19.04.2023 13:38:09 ******/
CREATE DATABASE [CarRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRent', FILENAME = N'D:\SQLServer\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CarRent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRent_log', FILENAME = N'D:\SQLServer\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CarRent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CarRent] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRent] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CarRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRent] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRent] SET  MULTI_USER 
GO
ALTER DATABASE [CarRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRent] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRent] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarRent] SET QUERY_STORE = ON
GO
ALTER DATABASE [CarRent] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CarRent]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 19.04.2023 13:38:09 ******/
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
/****** Object:  Table [dbo].[Car]    Script Date: 19.04.2023 13:38:09 ******/
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
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car_status]    Script Date: 19.04.2023 13:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car_status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 19.04.2023 13:38:09 ******/
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
/****** Object:  Table [dbo].[Make_of_car]    Script Date: 19.04.2023 13:38:09 ******/
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
/****** Object:  Table [dbo].[Model_of_car]    Script Date: 19.04.2023 13:38:09 ******/
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
/****** Object:  Table [dbo].[Post]    Script Date: 19.04.2023 13:38:09 ******/
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
/****** Object:  Table [dbo].[Rent]    Script Date: 19.04.2023 13:38:09 ******/
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
	[Rent_type] [int] NOT NULL,
	[Agent] [int] NOT NULL,
	[Extention] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent_type]    Script Date: 19.04.2023 13:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent_type](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Renter]    Script Date: 19.04.2023 13:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First_name] [nvarchar](40) NOT NULL,
	[Second_name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
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
SET IDENTITY_INSERT [dbo].[Agent] ON 

INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (5, N'SteveMaddon111', N'424242', N'Steve', N'Maddon', N'Jr.', N'79999999999', N'steve@bk.ru', 2)
INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (6, N'DmitrySetchenov', N'Pass123', N'Dmitry', N'Setchenov', N'Mihailovich', N'78888888888', N'Sechenov@bk.ru', 2)
INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (7, N'ArcadyPetrov', N'Qwe123', N'Arcady', N'Petrov', N'Evgenievich', N'79652354853', N'DBMaster@bk.ru', 3)
INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (8, N'EgorNechaev', N'Goal19', N'Egor', N'Nechaev', N'Vladimirovich', N'79904652578', N'Nechaev@bk.ru', 4)
INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (9, N'GeorgeSmith', N'Hola90', N'George', N'Smith', N'', N'74523676589', N'George1111111@bk.ru', 1)
INSERT [dbo].[Agent] ([ID], [Login], [Password], [First_name], [Second_name], [Patronymic], [Phone_number], [Email], [Post]) VALUES (10, N'1', N'1', N'1', N'1', N'1', N'1', N'1', 2)
SET IDENTITY_INSERT [dbo].[Agent] OFF
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (1, N'O365BC123', 1, 1, 450, CAST(N'2023-03-15' AS Date), 40000, 1, CAST(75 AS Decimal(18, 0)), 12000.0000, 99800.0000, 1)
INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (4, N'O033BC23', 2, 2, 608, CAST(N'2023-03-17' AS Date), 20000, 2, CAST(81 AS Decimal(18, 0)), 14000.0000, 125000.0000, 1)
INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (5, N'O044BC123', 4, 4, 424, CAST(N'2022-02-10' AS Date), 60000, 3, CAST(56 AS Decimal(18, 0)), 10000.0000, 60000.0000, 3)
INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (6, N'O016BC777', 5, 5, 800, CAST(N'2023-02-20' AS Date), 3000, 4, CAST(95 AS Decimal(18, 0)), 36000.0000, 250000.0000, 2)
INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (7, N'O016BC77', 5, 7, 740, CAST(N'2023-02-20' AS Date), 8000, 4, CAST(95 AS Decimal(18, 0)), 36000.0000, 255000.0000, 2)
INSERT [dbo].[Car] ([ID], [State_registration_plate], [Make], [Model], [Power], [Last_maintance], [Mileage], [Color], [Luxury_coefficient], [Price_per_hour], [Price_per_day], [Status]) VALUES (9, N'O785BC123', 6, 6, 150, CAST(N'2023-01-10' AS Date), 98000, 4, CAST(15 AS Decimal(18, 0)), 5000.0000, 25000.0000, 1)
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[Car_status] ON 

INSERT [dbo].[Car_status] ([ID], [Value]) VALUES (1, N'Ready for rent')
INSERT [dbo].[Car_status] ([ID], [Value]) VALUES (2, N'In rent')
INSERT [dbo].[Car_status] ([ID], [Value]) VALUES (3, N'Need maintenance')
INSERT [dbo].[Car_status] ([ID], [Value]) VALUES (4, N'In maintance')
INSERT [dbo].[Car_status] ([ID], [Value]) VALUES (5, N'Not ready')
SET IDENTITY_INSERT [dbo].[Car_status] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([ID], [Value]) VALUES (1, N'Red')
INSERT [dbo].[Color] ([ID], [Value]) VALUES (2, N'British Racing Green')
INSERT [dbo].[Color] ([ID], [Value]) VALUES (3, N'Carbonized Grey')
INSERT [dbo].[Color] ([ID], [Value]) VALUES (4, N'Ferrari Red')
INSERT [dbo].[Color] ([ID], [Value]) VALUES (7, N'Metiorit gray')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Make_of_car] ON 

INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (1, N'Alpha-Romeo')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (2, N'Aston-Martin')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (4, N'Ford')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (5, N'Ferrari')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (6, N'Mitsubishi')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (7, N'Cadilac')
INSERT [dbo].[Make_of_car] ([ID], [Make]) VALUES (9, N'Rolls-Royce')
SET IDENTITY_INSERT [dbo].[Make_of_car] OFF
GO
SET IDENTITY_INSERT [dbo].[Model_of_car] ON 

INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (1, 1, N'8C')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (2, 2, N'DB11')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (3, 2, N'Vantage')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (4, 4, N'Bronco')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (5, 5, N'812 Superfast')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (6, 6, N'Lancer EVO 10 FINAL EDITION')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (7, 5, N'F12 Berlenetta')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (9, 7, N'Escalade 2022')
INSERT [dbo].[Model_of_car] ([ID], [Make], [Model]) VALUES (10, 9, N'Culinan')
SET IDENTITY_INSERT [dbo].[Model_of_car] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [Value]) VALUES (1, N'Trainee')
INSERT [dbo].[Post] ([ID], [Value]) VALUES (2, N'Senior agent')
INSERT [dbo].[Post] ([ID], [Value]) VALUES (3, N'Agent seller')
INSERT [dbo].[Post] ([ID], [Value]) VALUES (4, N'Junior agent')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Rent] ON 

INSERT [dbo].[Rent] ([ID], [Start], [End], [Car], [Renter], [Rent_type], [Agent], [Extention]) VALUES (6, CAST(N'2023-04-10T11:25:00.000' AS DateTime), CAST(N'2023-04-10T17:25:00.000' AS DateTime), 1, 23, 2, 5, NULL)
INSERT [dbo].[Rent] ([ID], [Start], [End], [Car], [Renter], [Rent_type], [Agent], [Extention]) VALUES (7, CAST(N'2023-04-10T19:25:00.000' AS DateTime), CAST(N'2023-04-10T20:25:00.000' AS DateTime), 5, 7, 2, 5, NULL)
SET IDENTITY_INSERT [dbo].[Rent] OFF
GO
SET IDENTITY_INSERT [dbo].[Rent_type] ON 

INSERT [dbo].[Rent_type] ([ID], [Value]) VALUES (1, N'Per day')
INSERT [dbo].[Rent_type] ([ID], [Value]) VALUES (2, N'Per hour')
SET IDENTITY_INSERT [dbo].[Rent_type] OFF
GO
SET IDENTITY_INSERT [dbo].[Renter] ON 

INSERT [dbo].[Renter] ([ID], [First_name], [Second_name], [Patronymic], [Passport_num], [Country], [Driver_license_num], [Expirence_of_driving], [Age], [Phone_number], [Email]) VALUES (1, N'Igor', N'Melnikov', N'Sergeevich', N'56 45 869523', N'Russia', N'01 05 6589', 15, 35, N'+75685233212', N'Igorrr16@mail.ru')
INSERT [dbo].[Renter] ([ID], [First_name], [Second_name], [Patronymic], [Passport_num], [Country], [Driver_license_num], [Expirence_of_driving], [Age], [Phone_number], [Email]) VALUES (5, N'Oleg', N'Sibirov', N'Vladimirovich', N'40 25 658941', N'Russia', N'05 05 3645', 5, 30, N'+74582153521', N'')
INSERT [dbo].[Renter] ([ID], [First_name], [Second_name], [Patronymic], [Passport_num], [Country], [Driver_license_num], [Expirence_of_driving], [Age], [Phone_number], [Email]) VALUES (6, N'Grigoriy', N'Ismailov', N'Nikitovich', N'25 15 125463', N'Russia', N'25 65 3478', 10, 40, N'+75234587632', N'Ismailov@gmail.com')
INSERT [dbo].[Renter] ([ID], [First_name], [Second_name], [Patronymic], [Passport_num], [Country], [Driver_license_num], [Expirence_of_driving], [Age], [Phone_number], [Email]) VALUES (7, N'Ekaterina', N'Sidorova', N'Arcadievna', N'24 24 547856', N'Russia', N'01 32 5698', 3, 23, N'+79604374589', N'Fanymail@mail.ru')
INSERT [dbo].[Renter] ([ID], [First_name], [Second_name], [Patronymic], [Passport_num], [Country], [Driver_license_num], [Expirence_of_driving], [Age], [Phone_number], [Email]) VALUES (23, N'Anna', N'Melnikova', N'Vasilievna', N'08 09 123213', N'Russia', N'09 08 1234', 2, 21, N'+79653091205', N'AAM@gmail.com')
SET IDENTITY_INSERT [dbo].[Renter] OFF
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [FK_Agent_Post] FOREIGN KEY([Post])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [FK_Agent_Post]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Car_status] FOREIGN KEY([Status])
REFERENCES [dbo].[Car_status] ([ID])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Car_status]
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
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Rent_type] FOREIGN KEY([Rent_type])
REFERENCES [dbo].[Rent_type] ([ID])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Rent_type]
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
