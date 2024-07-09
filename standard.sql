USE [master]
GO
/****** Object:  Database [BasicStandardsDB]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE DATABASE [BasicStandardsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BasicStandardsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BasicStandardsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BasicStandardsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BasicStandardsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BasicStandardsDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BasicStandardsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BasicStandardsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BasicStandardsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BasicStandardsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BasicStandardsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BasicStandardsDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BasicStandardsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BasicStandardsDB] SET  MULTI_USER 
GO
ALTER DATABASE [BasicStandardsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BasicStandardsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BasicStandardsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BasicStandardsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BasicStandardsDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BasicStandardsDB', N'ON'
GO
ALTER DATABASE [BasicStandardsDB] SET QUERY_STORE = OFF
GO
USE [BasicStandardsDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/9/2024 11:38:01 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainStandards]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainStandards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[TitleAr] [nvarchar](100) NULL,
	[Code] [nvarchar](3) NULL,
 CONSTRAINT [PK_MainStandards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ResultTypeId] [int] NOT NULL,
	[SubStandardId] [int] NOT NULL,
	[DescriptionAr] [nvarchar](max) NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultTypes]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NameAr] [nvarchar](max) NULL,
 CONSTRAINT [PK_ResultTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyName] [nvarchar](100) NULL,
	[KeyValue] [nvarchar](100) NULL,
	[KeyValueAr] [nvarchar](100) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubStandards]    Script Date: 7/9/2024 11:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubStandards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MainStandardId] [int] NOT NULL,
	[Code] [nvarchar](3) NULL,
	[DescriptionAr] [nvarchar](max) NULL,
	[ResultTypeId] [int] NOT NULL,
 CONSTRAINT [PK_SubStandards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240605134721_initial', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704102053_codeAdded', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704115656_removeCodeAr', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240707131822_someUpdates', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240707134752_resultTypeUpdates', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[MainStandards] ON 

INSERT [dbo].[MainStandards] ([Id], [Title], [TitleAr], [Code]) VALUES (8, N'Infrastructur', N'البنية التحتية', N'001')
INSERT [dbo].[MainStandards] ([Id], [Title], [TitleAr], [Code]) VALUES (1027, N'Radiation protection', N'الوقاية من الإشعاع', N'002')
INSERT [dbo].[MainStandards] ([Id], [Title], [TitleAr], [Code]) VALUES (1045, N'x-rays', N'أجهزة الأشعة', N'003')
INSERT [dbo].[MainStandards] ([Id], [Title], [TitleAr], [Code]) VALUES (1085, N'Medical device engineering', N'هندسة الأجهزة الطبية ', N'004')
INSERT [dbo].[MainStandards] ([Id], [Title], [TitleAr], [Code]) VALUES (2086, N'Internet networks and connection lines', N'شبكات الانترنت وخطوط الربط', N'005')
SET IDENTITY_INSERT [dbo].[MainStandards] OFF
GO
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([Id], [Description], [ResultTypeId], [SubStandardId], [DescriptionAr]) VALUES (1, N'yes founded', 1, 1026, N'اجل يوجد')
INSERT [dbo].[Results] ([Id], [Description], [ResultTypeId], [SubStandardId], [DescriptionAr]) VALUES (3, N'yes', 3, 1044, N'نعم')
SET IDENTITY_INSERT [dbo].[Results] OFF
GO
SET IDENTITY_INSERT [dbo].[ResultTypes] ON 

INSERT [dbo].[ResultTypes] ([Id], [Name], [NameAr]) VALUES (1, N'T or F', N'صح ام خطأ')
INSERT [dbo].[ResultTypes] ([Id], [Name], [NameAr]) VALUES (2, N'Persentage', N'نسبة مئوية')
INSERT [dbo].[ResultTypes] ([Id], [Name], [NameAr]) VALUES (3, N'Text', N'نص')
SET IDENTITY_INSERT [dbo].[ResultTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [KeyName], [KeyValue], [KeyValueAr]) VALUES (1, N'Logo', N'Logo.jpeg', N'Logo.jpeg')
INSERT [dbo].[Settings] ([Id], [KeyName], [KeyValue], [KeyValueAr]) VALUES (2, N'LogoTitle', N'General Department of Radiology', N'الإدارة العامة للأشعة')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[SubStandards] ON 

INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (1026, N'The presence of a detailed, sealed statement of the devices in all hospital departments that matches their actual presence according to the hospital’s custody books, including idle devices that have not yet been estimated, maintenance contracts, and performance levels.', 8, N'101', N' وجود بيان مفصل مختوم بالأجهزة في جميع أقسام المستشفى مطابق لتواجدها الفعلي وفقاً لدفاتر العهدة بالمستشفى  يتضمن الأجهزة العاطلة التي لم تكهن بعد وعقود الصيانة ومستوى الأداء ', 1)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (1041, N'Separate room', 8, N'102', N'غرفه منفصله', 2)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (1042, N'ventilation', 8, N'103', N'تهوية', 1)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (1044, N'The department is on the ground floor', 1045, N'301', N' القسم بالدور الأرضي ', 3)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (1045, N'There is an inventory list that includes all radiology equipment in the hospital', 1085, N'401', N'يوجد قائمه حصر تشمل جميع الاجهزه بالمستشفى الخاصه بالأشعة', 2)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (2046, N'There are Internet networks operating in the hospital', 2086, N'005', N'يوجد شبكات انترنت تعمل بالمستشفى', 1)
INSERT [dbo].[SubStandards] ([Id], [Description], [MainStandardId], [Code], [DescriptionAr], [ResultTypeId]) VALUES (2047, N'Disinfectants and cleaners are available in designated locations.', 1027, N'201', N'- 2- تتوافر المطهرات والمنظفات في الأماكن المحدده.', 3)
SET IDENTITY_INSERT [dbo].[SubStandards] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Results_ResultTypeId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_Results_ResultTypeId] ON [dbo].[Results]
(
	[ResultTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Results_SubStandardId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_Results_SubStandardId] ON [dbo].[Results]
(
	[SubStandardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubStandards_MainStandardId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubStandards_MainStandardId] ON [dbo].[SubStandards]
(
	[MainStandardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubStandards_ResultTypeId]    Script Date: 7/9/2024 11:38:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubStandards_ResultTypeId] ON [dbo].[SubStandards]
(
	[ResultTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Results] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Results] ADD  DEFAULT ((0)) FOR [SubStandardId]
GO
ALTER TABLE [dbo].[SubStandards] ADD  DEFAULT ((0)) FOR [ResultTypeId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_ResultTypes_ResultTypeId] FOREIGN KEY([ResultTypeId])
REFERENCES [dbo].[ResultTypes] ([Id])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_ResultTypes_ResultTypeId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_SubStandards_SubStandardId] FOREIGN KEY([SubStandardId])
REFERENCES [dbo].[SubStandards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_SubStandards_SubStandardId]
GO
ALTER TABLE [dbo].[SubStandards]  WITH CHECK ADD  CONSTRAINT [FK_SubStandards_MainStandards_MainStandardId] FOREIGN KEY([MainStandardId])
REFERENCES [dbo].[MainStandards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubStandards] CHECK CONSTRAINT [FK_SubStandards_MainStandards_MainStandardId]
GO
ALTER TABLE [dbo].[SubStandards]  WITH CHECK ADD  CONSTRAINT [FK_SubStandards_ResultTypes_ResultTypeId] FOREIGN KEY([ResultTypeId])
REFERENCES [dbo].[ResultTypes] ([Id])
GO
ALTER TABLE [dbo].[SubStandards] CHECK CONSTRAINT [FK_SubStandards_ResultTypes_ResultTypeId]
GO
USE [master]
GO
ALTER DATABASE [BasicStandardsDB] SET  READ_WRITE 
GO
