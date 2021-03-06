USE [master]
GO
/****** Object:  Database [CalogoOnline]    Script Date: 14/07/2022 1:51:39 ******/
CREATE DATABASE [CalogoOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CalogoOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CalogoOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CalogoOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CalogoOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CalogoOnline] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CalogoOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CalogoOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CalogoOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CalogoOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CalogoOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CalogoOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [CalogoOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CalogoOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CalogoOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CalogoOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CalogoOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CalogoOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CalogoOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CalogoOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CalogoOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CalogoOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CalogoOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CalogoOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CalogoOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CalogoOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CalogoOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CalogoOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CalogoOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CalogoOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CalogoOnline] SET  MULTI_USER 
GO
ALTER DATABASE [CalogoOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CalogoOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CalogoOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CalogoOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CalogoOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CalogoOnline] SET QUERY_STORE = OFF
GO
USE [CalogoOnline]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [varchar](60) NOT NULL,
	[categoryDescription] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[productName] [varchar](60) NOT NULL,
	[productPrice] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[_password] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([categoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Categories]
GO
/****** Object:  StoredProcedure [dbo].[deleteCategory]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Delete*/
CREATE PROCEDURE [dbo].[deleteCategory]
@id INT
AS
DELETE FROM Categories WHERE categoryId=@id
GO
/****** Object:  StoredProcedure [dbo].[deleteProduct]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Delete*/
CREATE PROCEDURE [dbo].[deleteProduct]
@id INT
AS
DELETE FROM Product WHERE productId=@id
GO
/****** Object:  StoredProcedure [dbo].[deleteUsers]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Delete*/
CREATE PROCEDURE [dbo].[deleteUsers]

@id INT

AS
DELETE FROM Users WHERE Id=@id
GO
/****** Object:  StoredProcedure [dbo].[editCategoriesId]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editCategoriesId]
@id INT
AS
SELECT * FROM Categories WHERE categoryId = @id
GO
/****** Object:  StoredProcedure [dbo].[editCategory]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Edit*/
CREATE PROCEDURE [dbo].[editCategory]
@categoryName VARCHAR(60),
@categoryDescription VARCHAR(100),
@id INT
AS
UPDATE Categories SET categoryName = @categoryName, categoryDescription = @categoryDescription WHERE categoryId = @id
GO
/****** Object:  StoredProcedure [dbo].[editProduct]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editProduct]
@productName VARCHAR(60),
@productPrice INT, 
@categoryId INT,
@id INT
AS
UPDATE Product SET productName = @productName , productPrice = @productPrice,categoryId =@categoryId WHERE productId  = @id 
GO
/****** Object:  StoredProcedure [dbo].[editProductId]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editProductId]
@id INT
AS
SELECT * FROM Product WHERE productId = @id
GO
/****** Object:  StoredProcedure [dbo].[editUsers]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Edit*/
CREATE PROCEDURE [dbo].[editUsers]

@email VARCHAR (100),
@_password VARCHAR (60),
@id INT

AS
UPDATE Users SET email = @email, _password = @_password WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[editUsersId]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editUsersId]
@id INT
AS
SELECT * FROM Users WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[insertCategory]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Insert*/
CREATE PROCEDURE [dbo].[insertCategory]
@categoryName VARCHAR(60),
@categoryDescription VARCHAR(100)
AS
INSERT INTO Categories VALUES(@categoryName,@categoryDescription)
GO
/****** Object:  StoredProcedure [dbo].[insertProduct]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Insert*/
CREATE PROCEDURE [dbo].[insertProduct]
@productName VARCHAR(60),
@productPrice INT, 
@categoryId INT  
AS
INSERT INTO Product VALUES(@productName,@productPrice,@categoryId)
GO
/****** Object:  StoredProcedure [dbo].[insertUsers]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertUsers]

@email VARCHAR (100),
@_password VARCHAR (60)

AS
INSERT INTO Users VALUES (@email,@_password)
GO
/****** Object:  StoredProcedure [dbo].[showCategories]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Categories*/

/*list*/
CREATE PROCEDURE [dbo].[showCategories]
AS
SELECT * FROM Categories
GO
/****** Object:  StoredProcedure [dbo].[showProduct]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Product*/

/*list*/
CREATE PROCEDURE [dbo].[showProduct]
AS
SELECT * FROM Product
GO
/****** Object:  StoredProcedure [dbo].[showUsers]    Script Date: 14/07/2022 1:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[showUsers]
AS
SELECT * FROM Users
GO
USE [master]
GO
ALTER DATABASE [CalogoOnline] SET  READ_WRITE 
GO
