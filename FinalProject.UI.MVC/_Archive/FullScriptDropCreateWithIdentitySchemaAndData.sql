/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.5026)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
ALTER TABLE [dbo].[Reservations] DROP CONSTRAINT IF EXISTS [FK_Reservations_OwnerAssets]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
ALTER TABLE [dbo].[Reservations] DROP CONSTRAINT IF EXISTS [FK_Reservations_Locations]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OwnerAssets]') AND type in (N'U'))
ALTER TABLE [dbo].[OwnerAssets] DROP CONSTRAINT IF EXISTS [FK_OwnerAssets_UserDetails]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[UserDetails]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[Reservations]
GO
/****** Object:  Table [dbo].[OwnerAssets]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[OwnerAssets]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[Locations]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/13/2021 10:56:19 AM ******/
DROP TABLE IF EXISTS [dbo].[__MigrationHistory]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locations](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [char](2) NOT NULL,
	[ZipCode] [char](5) NOT NULL,
	[ReservationLimit] [tinyint] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OwnerAssets]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OwnerAssets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OwnerAssets](
	[OwnerAssetId] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [varchar](50) NOT NULL,
	[OwnerId] [nvarchar](128) NOT NULL,
	[AssetPhoto] [varchar](50) NULL,
	[SpecialNotes] [varchar](300) NULL,
	[IsActive] [bit] NOT NULL,
	[DateAdded] [date] NOT NULL,
 CONSTRAINT [PK_OwnerAssets] PRIMARY KEY CLUSTERED 
(
	[OwnerAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reservations](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[OwnerAssetId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ReservationDate] [date] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 1/13/2021 10:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserDetails](
	[UserId] [nvarchar](128) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202101042105404_InitialCreate', N'FinalProject.UI.MVC.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE3B6127E2F70FE83A0A7738AAC954B77B127B0B7489DB80DCEE68275B2386F0B5AA21D9D9528AD44A5090EFACBFAD09FD4BFD0A144DD78D1C5566CA758606191C36F86C321391C0EF3E7EF7F8C7F7CF23DE31147B11B908979343A340D4CECC071C96A622674F9E6BDF9E3877F7C37BE70FC27E3734E77C2E8A0258927E603A5E1A965C5F603F6513CF25D3B0AE260494776E05BC809ACE3C3C37F5B474716060813B00C63FC2921D4F571FA019FD380D838A409F2AE02077B312F879A798A6A5C231FC721B2F1C49CB90479B751F03F6CD3D1FDE5E8EAF37494B5328D33CF4520D11C7B4BD3408404145190F7F43EC6731A0564350FA1007977CF2106BA25F262CCFB715A9277EDD2E131EB925536CCA1EC24A681DF13F0E884EBC8129BAFA569B3D02168F102B44D9F59AF534D4ECC4B07A7459F020F1420323C9D7A11239E9857058BB338BCC67494371C6590B308E07E0DA2AFA32AE281D1B9DD416153C7A343F6EFC098261E4D223C2138A111F20E8CDB64E1B9F67FF0F35DF01593C9C9D16279F2FEED3BE49CBCFB019FBCADF614FA0A74B50228026B097104B2E165D17FD3B0EAED2CB161D1ACD226D30AD8124C0FD3B8424F1F3159D1079838C7EF4D63E63E61272FE1C6754F5C984DD08846097C5E279E87161E2EEAAD469EECFF06AEC76FDF0DC2F51A3DBAAB74E805FE30712298579FB097D6C60F6E984DAFDA787FE164B328F0D977DDBEB2DA2FF320896CD699404B7287A215A675E9C65669BC9D4C9A410D6FD639EAFE9B369354366F2529EBD03A332167B1EDD990CBFBB27C3B5BDC5918C2E0A5A6C534D26470FA4D6B24A01C180ADAD2948EBA9A12812EFE9D57C60B1FB9DE004B63072EE09D2CDDC8C7452F7F0AC01011E92DF32D8A6358199C5F50FCD0203AFC1C40F439B693080C764E911FBE38B7DB8780E0EBC45FB079B03D5E830DCDDDAFC10CD934882E086BB531DEC7C0FE1A24F48238E788E27B6AE780ECF3CEF5BB030C22CE996DE3389E813163671A80F39D035E127A72DC1B8E2D54BB764DA61E727DB56F222CA95F72D2D23F5153483E8A864CE5A73489FA3158B9A49BA839A95ED48CA255544ED6575406D64D524EA9173425689533A31ACCF34B476878D72F85DD7FDF6FB3CD5BB71654D438871512FF8C098E6019736E11A53822E50874593776E12CA4C3C798BEF8DE9472FA8CBC6468566BCD867411187E36A4B0FB3F1B5231A1F8D1759857D2E1409413037C277AF559AB7DCE09926D7B3AD4BAB96DE6DB590374D3E52C8E03DB4D67812214C6031975F9C18733DAA31A596FC4C808740C0CDD655B1E9440DF4CD1A86EC839F630C5C6999D850AA728B69123AB113AE4F4102CDF511582951192BA70DF4B3CC1D271C41A2176088A61A6BA84CAD3C225B61B22AF554B42CB8E5B18EB7BC143AC39C721268C61AB26BA305707449800051F6150DA3434B62A16D76C881AAF5537E66D2E6C39EE529C622B36D9E23B6BEC92FB6F2F6298CD1ADB827136ABA48B00DAE0DE2E0C949F55BA1A807870D93703154E4C1A03E52ED5560CB4AEB11D18685D25AFCE40B3236AD7F117CEABFB669EF583F2F6B7F54675EDC0366BFAD833D3CC7C4F6843A1058E64F33C5FB04AFC4415873390939FCF62EEEA8A26C2C0E798D64336A5BFABF443AD6610D1889A004B436B01E5D782129034A17A0897C7F21AA5E35E440FD83CEED608CBD77E01B662033276F57AB442A8BF44158DB3D3E9A3E859610D9291773A2C54701406212E5EF58E77508A2E2E2B2BA68B2FDCC71BAE748C0F4683825A3C578D92F2CE0CAEA5DC34DBB5A472C8FAB8641B6949709F345ACA3B33B896B88DB62B49E114F4700B3652517D0B1F68B2E5918E62B729EAC656963DC50BC69626CD6A7C85C2D025AB4ADA152F31E659CED5F4CDBC7F12929F615876ACC8452AA42D38D120422B2CD4026B9074E646313D47142D108BF34C1D5F2253EEAD9AE53F6759DD3EE541CCF7819C9AFDCE5A345CE6D7F65CD929E15833E8A9CF3C9B349CAEB003757383A5C3210F458A08FE34F0129FE81D2D7DEBEC1EAFDA3E2B9111C69620BFE448495A93DCDDFA10741A2079720C3C58853FB3FE80E921746ACFBDD1AAE2751EAA1E250F5855517441AC9D0DA0CEB1596BD044DFB1FF98B522BCCC3CE3092B55005ED413A392F3208155EABAA3D6D352AA98F59AEE8842EE491552A8EA216535C3A42664B5622D3C8D46D514DD39C839255574B9B63BB222BBA40AADA85E035B21B358D71D5591805205565477C72EB351C4C5748F7732ED8966E3AD2C3BFC6EB69769305E66651C662BACDCF157812AC53DB1F82DBE04C6CBF7D2AAB427C08DAD2A8B7D6C66551A0CFD4A54BB25AF2F448D57FB7ACCDAD5776DB16FBAFAD7E3F5B3DD17B510E920289214DC8B03A170F01BF34358FB231CE95496919846AE46D8E89F638AFD112318CDBF7953CFC56C59CF09AE10719738A659BA87797C78742CBCDFD99FB734561C3B9EE210AB7B50531FB32D646E914714D90F2892F32836786F52824A21EA4BE2E0A789F9FFB4D5691AED60BFD2E203E332BE27EEB7042AEEA2041BBFC979A1C3E4DF7778F15108FADBAB784AD15DE597FFFD92353D306E22984EA7C6A1A0E87586BFFEC0A2973459D30DA459FBD9C5EB9D6DB5370C4A5461B6ACFF6461E1D2419E2BE452FED3474FFFEA2B9AF249C246888A670743E10DA242DDB38275B0B44F0A1CF8A4E993827E9D553F31584734EDF30297F407131F17745F86F2963BDC871407A76D2C49A99E5B93B337CAD4DCF5DE24E5706F34D1E53CED1E7083E6626FE6A2BCB21CE7C1B64E450AF360D8BBB4FB17CF5BDE9754E5D269DF6D86F23693921B2E9AFE56B9C87B903DA7C806DA7DC6F1B66D4D1709DEF3B4CD7E79C57B666C7C9BDF7DF6F0B68D4D1720DE7363EB9523BC67B6B6ABFD73C796D6790BDD79C6AF9CBCA4B9D1514591DB327AB3903B1CFF17011841E651660F31D529644DE9AF2D0C4B123D537DEE9AC8589A38125F89A2996DBFBEF20DBFB1B39CA699AD26E3B389375FFF1B79739A66DE9A3CCA5DE4222B331955F9E12DEB58535AD56BCA3DAEF5A425D5BDCD676DBC9E7F4DA9C68328A5367B34B7CBAF27B37810950C39757A6412CB17C5B07756FEA623ECDFB1BB2A21D85F7824D8AEED9A05CD255906F9E62D48949308119A2B4C91035BEA5944DD25B22954B30074FA923C0DEAB16B9005762EC94D42C3844297B1BFF06A012FE60434F14FD3A5EB328F6F42F6150FD10510D36581FB1BF253E27A4E21F74C1113D24030EF82877BD9585216F65D3D1748D701E908C4D557384577D80F3D008B6FC81C3DE2756403F3FB8857C87E2E23803A90F681A8AB7D7CEEA25584FC986394EDE1136CD8F19F3EFC05C1361F83DA540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5e2819e7-1c50-4805-acab-0ac100d6bf52', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9b0cc958-8e52-4c8f-941a-da69cac3be7e', N'Employee')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cb107745-55c5-4a8e-82d2-b9e8a48d481b', N'Owner')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d641efc-3773-41db-852f-22104bcbb9fc', N'5e2819e7-1c50-4805-acab-0ac100d6bf52')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f94ef3a2-538a-4c5a-822d-62b5a8427755', N'5e2819e7-1c50-4805-acab-0ac100d6bf52')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'93198fdb-bb24-45e0-a47c-ce2ec140b328', N'9b0cc958-8e52-4c8f-941a-da69cac3be7e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f94ef3a2-538a-4c5a-822d-62b5a8427755', N'cb107745-55c5-4a8e-82d2-b9e8a48d481b')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d641efc-3773-41db-852f-22104bcbb9fc', N'admin@finalproject.com', 0, N'AJ4eGy25Wo8f1KEQuXtBNOTlsnJsOsbdWwYoo1K2aq+nMbz1DhPqeeeQG7xQE+AFMQ==', N'3252f78d-5caf-444e-9503-cf511ed3b3b8', NULL, 0, 0, NULL, 1, 0, N'admin@finalproject.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'93198fdb-bb24-45e0-a47c-ce2ec140b328', N'employee@employee.com', 0, N'ALamrRkMtVhHU4yLlcY1EWjh8E6haBZRc2ThZazyddGiMqNNHG7fPgiC7nPb9C5pZg==', N'b3913a86-4ffa-4ac1-a93d-c9a18874daee', NULL, 0, 0, NULL, 1, 0, N'employee@employee.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f94ef3a2-538a-4c5a-822d-62b5a8427755', N'owner@owneremail.com', 0, N'ANMwsm56FMAAg4dQXCOzV5z6xEHT4CemqWvCps1kWpBw9Tqbk+lm+bWNzsKByGcblg==', N'4d6cc891-1b28-4da5-9a16-9d1cfbc0cdd4', NULL, 0, 0, NULL, 1, 0, N'owner@owneremail.com')
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationId], [LocationName], [Address], [City], [State], [ZipCode], [ReservationLimit]) VALUES (1, N'MiamiBeach', N'12345 W AAAA', N'Miami', N'FL', N'32004', 26)
INSERT [dbo].[Locations] ([LocationId], [LocationName], [Address], [City], [State], [ZipCode], [ReservationLimit]) VALUES (2, N'ThePlaza', N'678910', N'New York', N'NY', N'45005', 30)
INSERT [dbo].[Locations] ([LocationId], [LocationName], [Address], [City], [State], [ZipCode], [ReservationLimit]) VALUES (4, N'RandomHotel', N'578902 E MMM', N'Los Angeles', N'CA', N'12004', 25)
INSERT [dbo].[Locations] ([LocationId], [LocationName], [Address], [City], [State], [ZipCode], [ReservationLimit]) VALUES (5, N'MariottWaterfront', N'Random Address', N'Seattle', N'WA', N'50040', 15)
INSERT [dbo].[Locations] ([LocationId], [LocationName], [Address], [City], [State], [ZipCode], [ReservationLimit]) VALUES (6, N'HotelPhillips', N'106 W 12th St.', N'Kansas City', N'KS', N'64105', 40)
SET IDENTITY_INSERT [dbo].[Locations] OFF
SET IDENTITY_INSERT [dbo].[OwnerAssets] ON 

INSERT [dbo].[OwnerAssets] ([OwnerAssetId], [AssetName], [OwnerId], [AssetPhoto], [SpecialNotes], [IsActive], [DateAdded]) VALUES (3, N'Hilton', N'MackJones', N'5c5d9e58-5833-41f9-821c-6ec913870597.jpg', N'Standard Hotel Package for most Employees.', 1, CAST(N'2010-09-24' AS Date))
INSERT [dbo].[OwnerAssets] ([OwnerAssetId], [AssetName], [OwnerId], [AssetPhoto], [SpecialNotes], [IsActive], [DateAdded]) VALUES (4, N'Radison', N'JohnSmith', N'3686f39d-a1f9-4a0c-b364-b4cc2863d9f5.jpg', N'Old Standard Package for Employees. Now Defunct.', 0, CAST(N'1999-11-03' AS Date))
INSERT [dbo].[OwnerAssets] ([OwnerAssetId], [AssetName], [OwnerId], [AssetPhoto], [SpecialNotes], [IsActive], [DateAdded]) VALUES (5, N'Holiday Inn', N'RichardBrown', N'45c8f3f7-58fd-4218-ac10-7d87a11847a9.jpg', N'Premium Package for Employees.', 1, CAST(N'2014-02-09' AS Date))
INSERT [dbo].[OwnerAssets] ([OwnerAssetId], [AssetName], [OwnerId], [AssetPhoto], [SpecialNotes], [IsActive], [DateAdded]) VALUES (6, N'Sheraton', N'BobbyBarrows', N'da4f15ca-b9f5-4ece-88fd-3db0a3fe12de.jpg', N'Standard Package for Management.', 1, CAST(N'2020-04-25' AS Date))
INSERT [dbo].[OwnerAssets] ([OwnerAssetId], [AssetName], [OwnerId], [AssetPhoto], [SpecialNotes], [IsActive], [DateAdded]) VALUES (7, N'Crest Hotels', N'TravisTouchdown', N'419baa20-af12-4ab3-acef-7dff55eec34e.jpg', N'Old Standard Package for Management. Now Defunct.', 0, CAST(N'1995-10-01' AS Date))
SET IDENTITY_INSERT [dbo].[OwnerAssets] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ReservationId], [OwnerAssetId], [LocationId], [ReservationDate]) VALUES (4, 3, 1, CAST(N'2020-09-24' AS Date))
INSERT [dbo].[Reservations] ([ReservationId], [OwnerAssetId], [LocationId], [ReservationDate]) VALUES (5, 4, 2, CAST(N'2020-10-01' AS Date))
INSERT [dbo].[Reservations] ([ReservationId], [OwnerAssetId], [LocationId], [ReservationDate]) VALUES (6, 5, 4, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[Reservations] ([ReservationId], [OwnerAssetId], [LocationId], [ReservationDate]) VALUES (7, 6, 5, CAST(N'2020-01-30' AS Date))
INSERT [dbo].[Reservations] ([ReservationId], [OwnerAssetId], [LocationId], [ReservationDate]) VALUES (8, 7, 6, CAST(N'2020-03-28' AS Date))
SET IDENTITY_INSERT [dbo].[Reservations] OFF
INSERT [dbo].[UserDetails] ([UserId], [FirstName], [LastName]) VALUES (N'BobbyBarrows', N'Bobby
', N'Barrows
')
INSERT [dbo].[UserDetails] ([UserId], [FirstName], [LastName]) VALUES (N'JohnSmith', N'John
', N'Smith
')
INSERT [dbo].[UserDetails] ([UserId], [FirstName], [LastName]) VALUES (N'MackJones', N'Mack
', N'Jones
')
INSERT [dbo].[UserDetails] ([UserId], [FirstName], [LastName]) VALUES (N'RichardBrown', N'Richard
', N'Brown
')
INSERT [dbo].[UserDetails] ([UserId], [FirstName], [LastName]) VALUES (N'TravisTouchdown', N'Travis
', N'Touchdown
')
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OwnerAssets_UserDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[OwnerAssets]'))
ALTER TABLE [dbo].[OwnerAssets]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAssets_UserDetails] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[UserDetails] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OwnerAssets_UserDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[OwnerAssets]'))
ALTER TABLE [dbo].[OwnerAssets] CHECK CONSTRAINT [FK_OwnerAssets_UserDetails]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_Locations]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_Locations]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Locations]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_OwnerAssets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_OwnerAssets] FOREIGN KEY([OwnerAssetId])
REFERENCES [dbo].[OwnerAssets] ([OwnerAssetId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_OwnerAssets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_OwnerAssets]
GO
