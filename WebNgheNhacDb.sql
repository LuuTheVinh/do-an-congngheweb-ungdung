USE [master]
GO
/****** Object:  Database [WebNgheNhacDb1]    Script Date: 10/17/2015 11:30:59 AM ******/
CREATE DATABASE [WebNgheNhacDb1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebNgheNhacDb1', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.JAMESWOLPERT\MSSQL\DATA\WebNgheNhacDb1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebNgheNhacDb1_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.JAMESWOLPERT\MSSQL\DATA\WebNgheNhacDb1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebNgheNhacDb1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebNgheNhacDb1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebNgheNhacDb1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebNgheNhacDb1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebNgheNhacDb1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebNgheNhacDb1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebNgheNhacDb1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebNgheNhacDb1] SET  MULTI_USER 
GO
ALTER DATABASE [WebNgheNhacDb1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebNgheNhacDb1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebNgheNhacDb1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebNgheNhacDb1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WebNgheNhacDb1] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WebNgheNhacDb1]
GO
/****** Object:  Table [dbo].[AccountInfo]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountInfo](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](16) NOT NULL,
	[PhoneNumber] [nchar](16) NOT NULL,
	[Email] [nchar](128) NOT NULL,
	[Birthday] [smalldatetime] NOT NULL,
	[IdentifyCard] [nchar](16) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Thumbnail] [nchar](256) NOT NULL,
 CONSTRAINT [PK_AccountInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Album]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [int] NOT NULL,
	[Tittle] [nvarchar](32) NOT NULL,
	[ParentId] [int] NOT NULL CONSTRAINT [DF_Album_ParentId]  DEFAULT ((0)),
	[Level] [int] NOT NULL CONSTRAINT [DF_Album_Level]  DEFAULT ((1)),
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlbumProduct]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumProduct](
	[Id] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_AlbumProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artist]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[Id] [int] NOT NULL,
	[Tittle] [nvarchar](32) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Level] [int] NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArtistProduct]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistProduct](
	[Id] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[StageName] [nvarchar](128) NOT NULL,
	[RealName] [nvarchar](128) NOT NULL,
	[BirthDay] [smalldatetime] NOT NULL,
	[Gender] [nvarchar](32) NOT NULL,
	[Country] [nvarchar](128) NOT NULL,
	[Specialization] [nvarchar](128) NOT NULL,
	[GroupId] [int] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Thumbnail] [nchar](256) NOT NULL,
 CONSTRAINT [PK_ArtistProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[AlbumProductId] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Desciption] [nvarchar](max) NOT NULL,
	[CreateDate] [smalldatetime] NOT NULL,
	[ModifiedDate] [smalldatetime] NOT NULL,
	[Views] [int] NOT NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[ArtistProductId] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Category] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[URL] [nchar](256) NOT NULL,
	[Thumbnail] [nchar](256) NOT NULL,
	[Views] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[AccountInfoId] [int] NOT NULL,
	[UserName] [nchar](32) NOT NULL,
	[Password] [nchar](32) NOT NULL,
	[SecQuest1] [nvarchar](256) NOT NULL,
	[SecAnswer1] [nvarchar](256) NOT NULL,
	[SecQuest2] [nvarchar](256) NOT NULL,
	[SecAnswer2] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserArtist]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserArtist](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ArtistProductId] [int] NOT NULL,
 CONSTRAINT [PK_UserArtist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserComment]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComment](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CommentText] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLike]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLike](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_UserLike] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Video]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[Id] [int] NOT NULL,
	[Tittle] [nvarchar](32) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Level] [int] NOT NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VideoProduct]    Script Date: 10/17/2015 11:31:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoProduct](
	[Id] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_VideoProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_FirstName]  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Gender]  DEFAULT ('') FOR [Gender]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_PhoneNumber]  DEFAULT ('') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Birthday]  DEFAULT (((1)/(1))/(1900)) FOR [Birthday]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_IdentifyCard]  DEFAULT ('') FOR [IdentifyCard]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[AccountInfo] ADD  CONSTRAINT [DF_AccountInfo_Thumbnail]  DEFAULT ('') FOR [Thumbnail]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF_Artist_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF_Artist_Level]  DEFAULT ((1)) FOR [Level]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_StageName]  DEFAULT ('') FOR [StageName]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_RealName]  DEFAULT ('') FOR [RealName]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_BirthDay]  DEFAULT (((1)/(1))/(1900)) FOR [BirthDay]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_Country]  DEFAULT ('') FOR [Country]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_Specialization]  DEFAULT ('') FOR [Specialization]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[ArtistProduct] ADD  CONSTRAINT [DF_ArtistProduct_Thumbnail]  DEFAULT ('') FOR [Thumbnail]
GO
ALTER TABLE [dbo].[Playlist] ADD  CONSTRAINT [DF_Playlist_Desciption]  DEFAULT ('') FOR [Desciption]
GO
ALTER TABLE [dbo].[Playlist] ADD  CONSTRAINT [DF_Playlist_CreateDate]  DEFAULT (((1)/(1))/(1900)) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Playlist] ADD  CONSTRAINT [DF_Playlist_ModifiedDate]  DEFAULT (((1)/(1))/(1900)) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Playlist] ADD  CONSTRAINT [DF_Playlist_Views]  DEFAULT ((0)) FOR [Views]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_URL]  DEFAULT ('') FOR [URL]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Thumbnail]  DEFAULT ('') FOR [Thumbnail]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Views]  DEFAULT ((0)) FOR [Views]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecQuest1]  DEFAULT ('') FOR [SecQuest1]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecAnswer1]  DEFAULT ('') FOR [SecAnswer1]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecQuest2]  DEFAULT ('') FOR [SecQuest2]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecAnswer2]  DEFAULT ('') FOR [SecAnswer2]
GO
ALTER TABLE [dbo].[Video] ADD  CONSTRAINT [DF_Video_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[Video] ADD  CONSTRAINT [DF_Video_Level]  DEFAULT ((1)) FOR [Level]
GO
ALTER TABLE [dbo].[AlbumProduct]  WITH CHECK ADD  CONSTRAINT [FK_AlbumProduct_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[AlbumProduct] CHECK CONSTRAINT [FK_AlbumProduct_Album]
GO
ALTER TABLE [dbo].[AlbumProduct]  WITH CHECK ADD  CONSTRAINT [FK_AlbumProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[AlbumProduct] CHECK CONSTRAINT [FK_AlbumProduct_Product]
GO
ALTER TABLE [dbo].[ArtistProduct]  WITH CHECK ADD  CONSTRAINT [FK_ArtistProduct_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([Id])
GO
ALTER TABLE [dbo].[ArtistProduct] CHECK CONSTRAINT [FK_ArtistProduct_Artist]
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD  CONSTRAINT [FK_Playlist_AlbumProduct] FOREIGN KEY([AlbumProductId])
REFERENCES [dbo].[AlbumProduct] ([Id])
GO
ALTER TABLE [dbo].[Playlist] CHECK CONSTRAINT [FK_Playlist_AlbumProduct]
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD  CONSTRAINT [FK_Playlist_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Playlist] CHECK CONSTRAINT [FK_Playlist_User]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ArtistProduct] FOREIGN KEY([ArtistProductId])
REFERENCES [dbo].[ArtistProduct] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ArtistProduct]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_AccountInfo] FOREIGN KEY([AccountInfoId])
REFERENCES [dbo].[AccountInfo] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_AccountInfo]
GO
ALTER TABLE [dbo].[UserArtist]  WITH CHECK ADD  CONSTRAINT [FK_UserArtist_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserArtist] CHECK CONSTRAINT [FK_UserArtist_User]
GO
ALTER TABLE [dbo].[UserArtist]  WITH CHECK ADD  CONSTRAINT [FK_UserArtist_UserArtist] FOREIGN KEY([ArtistProductId])
REFERENCES [dbo].[ArtistProduct] ([Id])
GO
ALTER TABLE [dbo].[UserArtist] CHECK CONSTRAINT [FK_UserArtist_UserArtist]
GO
ALTER TABLE [dbo].[UserComment]  WITH CHECK ADD  CONSTRAINT [FK_UserComment_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[UserComment] CHECK CONSTRAINT [FK_UserComment_Product]
GO
ALTER TABLE [dbo].[UserComment]  WITH CHECK ADD  CONSTRAINT [FK_UserComment_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserComment] CHECK CONSTRAINT [FK_UserComment_User]
GO
ALTER TABLE [dbo].[UserLike]  WITH CHECK ADD  CONSTRAINT [FK_UserLike_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[UserLike] CHECK CONSTRAINT [FK_UserLike_Product]
GO
ALTER TABLE [dbo].[UserLike]  WITH CHECK ADD  CONSTRAINT [FK_UserLike_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserLike] CHECK CONSTRAINT [FK_UserLike_User]
GO
ALTER TABLE [dbo].[VideoProduct]  WITH CHECK ADD  CONSTRAINT [FK_VideoProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[VideoProduct] CHECK CONSTRAINT [FK_VideoProduct_Product]
GO
ALTER TABLE [dbo].[VideoProduct]  WITH CHECK ADD  CONSTRAINT [FK_VideoProduct_Video] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Video] ([Id])
GO
ALTER TABLE [dbo].[VideoProduct] CHECK CONSTRAINT [FK_VideoProduct_Video]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nghệ danh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'StageName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tên thật' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày sinh, hoặc ngày thành lập đối với band' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'BirthDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Giới tính, hoặc band' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quốc gia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'Country'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chuyên môn, ví dụ như: sáng tác, nhạc cụ, múa, hát..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'Specialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nhóm tham gia nếu là thành viên nhóm. Là Id của một Artist kiểu band' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Thông tin thêm về Artist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArtistProduct', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loại Product, ví dụ: Nhạc, Video, ...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'Category'
GO
USE [master]
GO
ALTER DATABASE [WebNgheNhacDb1] SET  READ_WRITE 
GO
