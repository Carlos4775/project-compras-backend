USE [master]
GO
/****** Object:  Database [ComprasDB]    Script Date: 4/14/2021 9:35:45 PM ******/
CREATE DATABASE [ComprasDB]
 CONTAINMENT = NONE 

GO
ALTER DATABASE [ComprasDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComprasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComprasDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComprasDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComprasDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComprasDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComprasDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComprasDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComprasDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComprasDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComprasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComprasDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComprasDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComprasDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComprasDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComprasDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComprasDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComprasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComprasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComprasDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComprasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComprasDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComprasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComprasDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComprasDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ComprasDB] SET  MULTI_USER 
GO
ALTER DATABASE [ComprasDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComprasDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComprasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComprasDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ComprasDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ComprasDB', N'ON'
GO
ALTER DATABASE [ComprasDB] SET QUERY_STORE = OFF
GO
USE [ComprasDB]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 4/14/2021 9:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Id_Articulo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Id_Unidad_Medida] [int] NOT NULL,
	[Existencia] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[Id_Articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 4/14/2021 9:35:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[Id_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Compra]    Script Date: 4/14/2021 9:35:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Compra](
	[Id_Orden_Compra] [int] IDENTITY(1,1) NOT NULL,
	[No_Orden] [int] NOT NULL,
	[Fecha_Orden] [date] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Id_Articulo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Id_Unidad_Medida] [int] NOT NULL,
	[Costo_Unitario] [decimal](18, 2) NOT NULL,
	[Id_Proveedor] [int] NOT NULL,
	[Id_Departamento] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Id_Asiento] [int] NULL,
 CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	[Id_Orden_Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 4/14/2021 9:35:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Cedula_RNC] [varchar](50) NOT NULL,
	[Nombre_Comercial] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidades_Medidas]    Script Date: 4/14/2021 9:35:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades_Medidas](
	[Id_Unidad_Medida] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[Id_Unidad_Medida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([Id_Articulo], [Descripcion], [Marca], [Id_Unidad_Medida], [Existencia], [Estado]) VALUES (1, N'Monitor', N'Dell', 2, 4, 1)
INSERT [dbo].[Articulos] ([Id_Articulo], [Descripcion], [Marca], [Id_Unidad_Medida], [Existencia], [Estado]) VALUES (3, N'Silla ergonomic', N'Horizon', 2, 3, 1)
INSERT [dbo].[Articulos] ([Id_Articulo], [Descripcion], [Marca], [Id_Unidad_Medida], [Existencia], [Estado]) VALUES (4, N'Resma papel de 1000', N'Abby', 2, 5, 1)
INSERT [dbo].[Articulos] ([Id_Articulo], [Descripcion], [Marca], [Id_Unidad_Medida], [Existencia], [Estado]) VALUES (5, N'Mesa ejecutiva', N'Omar', 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([Id_Departamento], [Nombre], [Estado]) VALUES (1, N'TI', 1)
INSERT [dbo].[Departamentos] ([Id_Departamento], [Nombre], [Estado]) VALUES (2, N'Contabilidad', 1)
INSERT [dbo].[Departamentos] ([Id_Departamento], [Nombre], [Estado]) VALUES (3, N'Mercadeo', 1)
INSERT [dbo].[Departamentos] ([Id_Departamento], [Nombre], [Estado]) VALUES (4, N'Recursos Humanos', 1)
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
SET IDENTITY_INSERT [dbo].[Orden_Compra] ON 

INSERT [dbo].[Orden_Compra] ([Id_Orden_Compra], [No_Orden], [Fecha_Orden], [Estado], [Id_Articulo], [Cantidad], [Id_Unidad_Medida], [Costo_Unitario], [Id_Proveedor], [Id_Departamento], [Monto], [Id_Asiento]) VALUES (7, 1, CAST(N'2021-01-25' AS Date), 1, 1, 5, 2, CAST(2000.00 AS Decimal(18, 2)), 1, 1, CAST(10000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Orden_Compra] ([Id_Orden_Compra], [No_Orden], [Fecha_Orden], [Estado], [Id_Articulo], [Cantidad], [Id_Unidad_Medida], [Costo_Unitario], [Id_Proveedor], [Id_Departamento], [Monto], [Id_Asiento]) VALUES (9, 2, CAST(N'2021-02-10' AS Date), 1, 3, 3, 2, CAST(3000.00 AS Decimal(18, 2)), 2, 2, CAST(9000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orden_Compra] ([Id_Orden_Compra], [No_Orden], [Fecha_Orden], [Estado], [Id_Articulo], [Cantidad], [Id_Unidad_Medida], [Costo_Unitario], [Id_Proveedor], [Id_Departamento], [Monto], [Id_Asiento]) VALUES (11, 3, CAST(N'2021-03-12' AS Date), 1, 4, 2, 2, CAST(2500.00 AS Decimal(18, 2)), 5, 3, CAST(5000.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Orden_Compra] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([Id_Proveedor], [Cedula_RNC], [Nombre_Comercial], [Estado]) VALUES (1, N'00114905656', N'Grass Leon', 1)
INSERT [dbo].[Proveedores] ([Id_Proveedor], [Cedula_RNC], [Nombre_Comercial], [Estado]) VALUES (2, N'00110032102', N'Bau Pi Industriales', 1)
INSERT [dbo].[Proveedores] ([Id_Proveedor], [Cedula_RNC], [Nombre_Comercial], [Estado]) VALUES (5, N'00100000001', N'Toribio SRL', 0)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
SET IDENTITY_INSERT [dbo].[Unidades_Medidas] ON 

INSERT [dbo].[Unidades_Medidas] ([Id_Unidad_Medida], [Descripcion], [Estado]) VALUES (1, N'Libra', 1)
INSERT [dbo].[Unidades_Medidas] ([Id_Unidad_Medida], [Descripcion], [Estado]) VALUES (2, N'Unidad', 1)
INSERT [dbo].[Unidades_Medidas] ([Id_Unidad_Medida], [Descripcion], [Estado]) VALUES (3, N'Tonelada', 1)
INSERT [dbo].[Unidades_Medidas] ([Id_Unidad_Medida], [Descripcion], [Estado]) VALUES (4, N'Onzas', 1)
SET IDENTITY_INSERT [dbo].[Unidades_Medidas] OFF
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulos_Unidades_Medidas] FOREIGN KEY([Id_Unidad_Medida])
REFERENCES [dbo].[Unidades_Medidas] ([Id_Unidad_Medida])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulos_Unidades_Medidas]
GO
ALTER TABLE [dbo].[Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Compra_Articulos] FOREIGN KEY([Id_Articulo])
REFERENCES [dbo].[Articulos] ([Id_Articulo])
GO
ALTER TABLE [dbo].[Orden_Compra] CHECK CONSTRAINT [FK_Orden_Compra_Articulos]
GO
ALTER TABLE [dbo].[Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Compra_Departamentos] FOREIGN KEY([Id_Departamento])
REFERENCES [dbo].[Departamentos] ([Id_Departamento])
GO
ALTER TABLE [dbo].[Orden_Compra] CHECK CONSTRAINT [FK_Orden_Compra_Departamentos]
GO
ALTER TABLE [dbo].[Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Compra_Proveedores] FOREIGN KEY([Id_Proveedor])
REFERENCES [dbo].[Proveedores] ([Id_Proveedor])
GO
ALTER TABLE [dbo].[Orden_Compra] CHECK CONSTRAINT [FK_Orden_Compra_Proveedores]
GO
ALTER TABLE [dbo].[Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Compra_Unidades_Medidas] FOREIGN KEY([Id_Unidad_Medida])
REFERENCES [dbo].[Unidades_Medidas] ([Id_Unidad_Medida])
GO
ALTER TABLE [dbo].[Orden_Compra] CHECK CONSTRAINT [FK_Orden_Compra_Unidades_Medidas]
GO
USE [master]
GO
ALTER DATABASE [ComprasDB] SET  READ_WRITE 
GO
