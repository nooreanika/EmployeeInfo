USE [master]
GO
/****** Object:  Database [Employee]    Script Date: 5/13/2015 5:31:45 PM ******/
CREATE DATABASE [Employee]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employee', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Employee.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Employee_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Employee_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Employee] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employee].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employee] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employee] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employee] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employee] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employee] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employee] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employee] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Employee] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employee] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employee] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employee] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employee] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employee] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employee] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employee] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employee] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employee] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employee] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employee] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employee] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employee] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employee] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employee] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employee] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Employee] SET  MULTI_USER 
GO
ALTER DATABASE [Employee] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employee] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employee] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employee] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Employee]
GO
/****** Object:  Table [dbo].[tb_employee]    Script Date: 5/13/2015 5:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](150) NULL,
	[Email] [varchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
 CONSTRAINT [PK_tb_employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tb_employee] ON 

INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (1, N'muna', N'dhaka', N'noor@gmail', 12000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (2, N'anika', N'Khulna', N'muna@gmail,com', 50000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (3, N'titli', N'saver', N'ani@gmail.com', 4500)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (4, N'tonni', N'mirpur', N'noor@gmail.com', 12500)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (6, N'', N'sdfgdfg', N'', 1200)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (8, N'Topon ', N'khulna', N'muna@gmail.com', 20000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (9, N'muna', N'sdff', N'sakib@gmail.com', 12000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (10, N'tuli', N'Mirpur', N'tuli@gmail,com', 10000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (11, N'Sahara', N'Mirpur', N'sahara@gmail.com', 20000)
INSERT [dbo].[tb_employee] ([Id], [Name], [Address], [Email], [Salary]) VALUES (12, N'Sharmin', N'Dhaka', N'sarmin@ojoo.com', 12000)
SET IDENTITY_INSERT [dbo].[tb_employee] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tb_employee]    Script Date: 5/13/2015 5:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tb_employee] ON [dbo].[tb_employee]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tb_employee_1]    Script Date: 5/13/2015 5:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_tb_employee_1] ON [dbo].[tb_employee]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Employee] SET  READ_WRITE 
GO
