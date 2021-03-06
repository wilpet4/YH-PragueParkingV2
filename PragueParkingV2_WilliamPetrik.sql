USE [master]
GO
/****** Object:  Database [PragueParkingV2_WilliamPetrik]    Script Date: 2022-05-22 21:19:01 ******/
CREATE DATABASE [PragueParkingV2_WilliamPetrik]
GO
USE [PragueParkingV2_WilliamPetrik]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022-05-22 21:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garages]    Script Date: 2022-05-22 21:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garages](
	[GarageId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Garages] PRIMARY KEY CLUSTERED 
(
	[GarageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParkingSpots]    Script Date: 2022-05-22 21:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingSpots](
	[ParkingSpotId] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NOT NULL,
	[ParkingGarageId] [int] NOT NULL,
 CONSTRAINT [PK_ParkingSpots] PRIMARY KEY CLUSTERED 
(
	[ParkingSpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 2022-05-22 21:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[ReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[Registration] [nvarchar](max) NOT NULL,
	[ParkingSpotId] [int] NOT NULL,
	[Arrival] [datetime2](7) NOT NULL,
	[Departure] [datetime2](7) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 2022-05-22 21:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[Size] [tinyint] NOT NULL,
	[Registration] [nvarchar](max) NULL,
	[Arrival] [datetime2](7) NOT NULL,
	[ParkingSpotId] [int] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521200652_Initial', N'6.0.3')
GO
SET IDENTITY_INSERT [dbo].[Garages] ON 

INSERT [dbo].[Garages] ([GarageId]) VALUES (1)
SET IDENTITY_INSERT [dbo].[Garages] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingSpots] ON 

INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (1, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (2, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (3, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (4, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (5, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (6, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (7, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (8, 2, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (9, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (10, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (11, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (12, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (13, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (14, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (15, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (16, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (17, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (18, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (19, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (20, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (21, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (22, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (23, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (24, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (25, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (26, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (27, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (28, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (29, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (30, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (31, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (32, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (33, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (34, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (35, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (36, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (37, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (38, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (39, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (40, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (41, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (42, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (43, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (44, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (45, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (46, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (47, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (48, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (49, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (50, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (51, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (52, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (53, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (54, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (55, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (56, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (57, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (58, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (59, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (60, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (61, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (62, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (63, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (64, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (65, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (66, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (67, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (68, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (69, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (70, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (71, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (72, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (73, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (74, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (75, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (76, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (77, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (78, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (79, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (80, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (81, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (82, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (83, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (84, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (85, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (86, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (87, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (88, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (89, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (90, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (91, 4, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (92, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (93, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (94, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (95, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (96, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (97, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (98, 6, 1)
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (99, 6, 1)
GO
INSERT [dbo].[ParkingSpots] ([ParkingSpotId], [Size], [ParkingGarageId]) VALUES (100, 6, 1)
SET IDENTITY_INSERT [dbo].[ParkingSpots] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (1, 2, N'ABC123', CAST(N'2022-05-22T20:43:08.5970449' AS DateTime2), 1, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (2, 2, N'TestMC', CAST(N'2022-05-22T20:43:34.7008018' AS DateTime2), 2, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (3, 4, N'1A23456', CAST(N'2022-05-22T20:44:26.1600132' AS DateTime2), 9, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (4, 4, N'1AB3456', CAST(N'2022-05-22T20:44:46.9868940' AS DateTime2), 10, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (5, 4, N'3A6789', CAST(N'2022-05-22T20:45:08.2493147' AS DateTime2), 11, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (6, 4, N'4A23000', CAST(N'2022-05-22T20:45:35.2776305' AS DateTime2), 20, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (7, 4, N'2H27149', CAST(N'2022-05-22T20:45:47.1010958' AS DateTime2), 21, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (8, 4, N'DICTAT0R', CAST(N'2022-05-22T20:46:11.8978510' AS DateTime2), 22, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (9, 4, N'FTD770', CAST(N'2022-05-22T20:46:26.0250876' AS DateTime2), 24, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (10, 2, N'ALA40-11', CAST(N'2022-05-22T20:47:13.6932839' AS DateTime2), 100, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (11, 2, N'AX70-84', CAST(N'2022-05-22T20:47:25.4751887' AS DateTime2), 100, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (12, 2, N'AZ17-32', CAST(N'2022-05-22T20:47:34.9077609' AS DateTime2), 100, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (13, 2, N'DD00529', CAST(N'2022-05-22T20:48:12.6516934' AS DateTime2), 16, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (14, 4, N'017CD75', CAST(N'2022-05-22T20:48:44.3205761' AS DateTime2), 91, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (15, 4, N'RA75-31', CAST(N'2022-05-22T20:48:56.8726134' AS DateTime2), 92, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (16, 4, N'I!?{}[]()€$', CAST(N'2022-05-22T20:49:20.4270866' AS DateTime2), 93, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (17, 4, N'4B=9595', CAST(N'2022-05-22T20:49:43.6054475' AS DateTime2), 94, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (18, 2, N'02261-25', CAST(N'2022-05-22T20:50:12.5397232' AS DateTime2), 99, N'MC')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (19, 4, N'A6738E', CAST(N'2022-05-22T20:50:29.6928616' AS DateTime2), 99, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (20, 4, N'V7425', CAST(N'2022-05-22T20:50:39.7734868' AS DateTime2), 66, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (21, 4, N'EL106AC', CAST(N'2022-05-22T20:50:57.7885870' AS DateTime2), 34, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (22, 4, N'CARCAR', CAST(N'2022-05-22T20:51:06.7238632' AS DateTime2), 88, N'Car')
INSERT [dbo].[Vehicle] ([VehicleId], [Size], [Registration], [Arrival], [ParkingSpotId], [Discriminator]) VALUES (23, 4, N'vroomvroom', CAST(N'2022-05-22T20:51:18.7563385' AS DateTime2), 31, N'Car')
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
/****** Object:  Index [IX_ParkingSpots_ParkingGarageId]    Script Date: 2022-05-22 21:19:01 ******/
CREATE NONCLUSTERED INDEX [IX_ParkingSpots_ParkingGarageId] ON [dbo].[ParkingSpots]
(
	[ParkingGarageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_ParkingSpotId]    Script Date: 2022-05-22 21:19:01 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_ParkingSpotId] ON [dbo].[Vehicle]
(
	[ParkingSpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ParkingSpots]  WITH CHECK ADD  CONSTRAINT [FK_ParkingSpots_Garages_ParkingGarageId] FOREIGN KEY([ParkingGarageId])
REFERENCES [dbo].[Garages] ([GarageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParkingSpots] CHECK CONSTRAINT [FK_ParkingSpots_Garages_ParkingGarageId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_ParkingSpots_ParkingSpotId] FOREIGN KEY([ParkingSpotId])
REFERENCES [dbo].[ParkingSpots] ([ParkingSpotId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_ParkingSpots_ParkingSpotId]
GO
USE [master]
GO
ALTER DATABASE [PragueParkingV2_WilliamPetrik] SET  READ_WRITE 
GO
