USE [master]
GO
/****** Object:  Database [EroiVsMostriDb]    Script Date: 17/06/2021 13:44:06 ******/
CREATE DATABASE [EroiVsMostriDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EroiVsMostriDb', FILENAME = N'C:\Users\Anna\EroiVsMostriDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EroiVsMostriDb_log', FILENAME = N'C:\Users\Anna\EroiVsMostriDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EroiVsMostriDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EroiVsMostriDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EroiVsMostriDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EroiVsMostriDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EroiVsMostriDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EroiVsMostriDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EroiVsMostriDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EroiVsMostriDb] SET  MULTI_USER 
GO
ALTER DATABASE [EroiVsMostriDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EroiVsMostriDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EroiVsMostriDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EroiVsMostriDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EroiVsMostriDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EroiVsMostriDb] SET QUERY_STORE = OFF
GO
USE [EroiVsMostriDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EroiVsMostriDb]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 17/06/2021 13:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[IdArma] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[CategoriaAppartenenza] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[IdArma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 17/06/2021 13:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[IdEroe] [int] IDENTITY(1,1) NOT NULL,
	[NomeEroe] [nvarchar](30) NOT NULL,
	[CategoriaEroe] [nvarchar](30) NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdLivello] [int] NOT NULL,
	[IdUtente] [int] NOT NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[IdEroe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livello]    Script Date: 17/06/2021 13:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello](
	[IdLivello] [int] IDENTITY(1,1) NOT NULL,
	[NumeroLivello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_Livello] PRIMARY KEY CLUSTERED 
(
	[IdLivello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 17/06/2021 13:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[IdMostro] [int] IDENTITY(1,1) NOT NULL,
	[NomeMostro] [nvarchar](30) NOT NULL,
	[CategoriaMostro] [nvarchar](30) NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdLivello] [int] NOT NULL,
 CONSTRAINT [PK_Mostro] PRIMARY KEY CLUSTERED 
(
	[IdMostro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 17/06/2021 13:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[IsAuthenticated] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (1, N'Alabarda', 15, N'Guerriero')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (2, N'Ascia', 8, N'Guerriero')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (3, N'Mazza', 5, N'Guerriero')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (4, N'Spada', 10, N'Guerriero')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (5, N'Spadone', 15, N'Guerriero')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (6, N'Arco e frecce', 8, N'Mago')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (7, N'Bacchetta', 5, N'Mago')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (8, N'Bastone magico', 10, N'Mago')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (9, N'Onda d''urto', 15, N'Mago')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (10, N'Pugnale', 5, N'Mago')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (11, N'Discorso noioso', 4, N'Cultista')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (12, N'Farneticazione', 7, N'Cultista')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (13, N'Imprecazione', 5, N'Cultista')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (14, N'Magia nera', 3, N'Cultista')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (15, N'Arco', 7, N'Orco')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (16, N'Clava', 5, N'Orco')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (17, N'Spada rotta', 3, N'Orco')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (18, N'Mazza chiodata', 10, N'Orco')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (19, N'Alabarda del drago', 30, N'Signore del male')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (20, N'Divinazione', 15, N'Signore del male')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (21, N'Fulmine', 10, N'Signore del male')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (22, N'Fulmine celeste', 15, N'Signore del male')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (23, N'Tempesta', 8, N'Signore del male')
INSERT [dbo].[Arma] ([IdArma], [Nome], [PuntiDanno], [CategoriaAppartenenza]) VALUES (24, N'Tempesta oscura', 15, N'Signore del male')
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [CategoriaEroe], [PuntiAccumulati], [IdArma], [IdLivello], [IdUtente]) VALUES (1, N'Attila', N'Guerriero', 0, 1, 1, 1)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [CategoriaEroe], [PuntiAccumulati], [IdArma], [IdLivello], [IdUtente]) VALUES (2, N'Merlino', N'Mago', 0, 6, 1, 1)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [CategoriaEroe], [PuntiAccumulati], [IdArma], [IdLivello], [IdUtente]) VALUES (3, N'Cesare', N'Guerriero', 0, 3, 1, 2)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [CategoriaEroe], [PuntiAccumulati], [IdArma], [IdLivello], [IdUtente]) VALUES (4, N'Bia', N'Mago', 0, 8, 1, 2)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Livello] ON 

INSERT [dbo].[Livello] ([IdLivello], [NumeroLivello], [PuntiVita]) VALUES (1, 1, 20)
INSERT [dbo].[Livello] ([IdLivello], [NumeroLivello], [PuntiVita]) VALUES (2, 2, 40)
INSERT [dbo].[Livello] ([IdLivello], [NumeroLivello], [PuntiVita]) VALUES (3, 3, 60)
INSERT [dbo].[Livello] ([IdLivello], [NumeroLivello], [PuntiVita]) VALUES (4, 4, 80)
INSERT [dbo].[Livello] ([IdLivello], [NumeroLivello], [PuntiVita]) VALUES (5, 5, 100)
SET IDENTITY_INSERT [dbo].[Livello] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [CategoriaMostro], [IdArma], [IdLivello]) VALUES (1, N'Hulk', N'Orco', 15, 2)
INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [CategoriaMostro], [IdArma], [IdLivello]) VALUES (2, N'Nero', N'Cultista', 11, 1)
INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [CategoriaMostro], [IdArma], [IdLivello]) VALUES (3, N'Lucifero', N'Signore del male', 23, 3)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
SET IDENTITY_INSERT [dbo].[Utente] ON 

INSERT [dbo].[Utente] ([IdUtente], [Username], [Password], [IsAuthenticated], [IsAdmin]) VALUES (1, N'Mario', N'1234', 0, 0)
INSERT [dbo].[Utente] ([IdUtente], [Username], [Password], [IsAuthenticated], [IsAdmin]) VALUES (2, N'Marco', N'1234', 0, 1)
INSERT [dbo].[Utente] ([IdUtente], [Username], [Password], [IsAuthenticated], [IsAdmin]) VALUES (3, N'Anna', N'1234', 1, 0)
SET IDENTITY_INSERT [dbo].[Utente] OFF
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([IdArma])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Arma]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Livello] FOREIGN KEY([IdLivello])
REFERENCES [dbo].[Livello] ([IdLivello])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Livello]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Utente] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utente] ([IdUtente])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Utente]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([IdArma])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Arma]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Livello] FOREIGN KEY([IdLivello])
REFERENCES [dbo].[Livello] ([IdLivello])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Livello]
GO
USE [master]
GO
ALTER DATABASE [EroiVsMostriDb] SET  READ_WRITE 
GO
