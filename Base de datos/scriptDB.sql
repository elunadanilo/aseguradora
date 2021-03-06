USE [master]
GO
/****** Object:  Database [DbAseguradora]    Script Date: 21/06/2021 22:24:45 ******/
CREATE DATABASE [DbAseguradora]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbAseguradora', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DbAseguradora.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbAseguradora_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DbAseguradora_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DbAseguradora] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbAseguradora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbAseguradora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbAseguradora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbAseguradora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbAseguradora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbAseguradora] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbAseguradora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbAseguradora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbAseguradora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbAseguradora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbAseguradora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbAseguradora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbAseguradora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbAseguradora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbAseguradora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbAseguradora] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbAseguradora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbAseguradora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbAseguradora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbAseguradora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbAseguradora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbAseguradora] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbAseguradora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbAseguradora] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbAseguradora] SET  MULTI_USER 
GO
ALTER DATABASE [DbAseguradora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbAseguradora] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbAseguradora] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbAseguradora] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbAseguradora] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbAseguradora] SET QUERY_STORE = OFF
GO
USE [DbAseguradora]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [DbAseguradora]
GO
/****** Object:  Table [dbo].[TblAseguradora]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAseguradora](
	[IdAseguradora] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Departamento] [char](2) NOT NULL,
	[Municipio] [char](2) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[NIT] [char](10) NOT NULL,
	[Telefono] [char](10) NULL,
 CONSTRAINT [PK_TblAseguradora] PRIMARY KEY CLUSTERED 
(
	[IdAseguradora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCliente]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [varchar](30) NOT NULL,
	[SegundoNombre] [varchar](30) NULL,
	[PrimerApellido] [varchar](30) NOT NULL,
	[SegundoApellido] [varchar](30) NULL,
	[ApellidoCasada] [varchar](30) NULL,
	[Departamento] [char](2) NOT NULL,
	[Municipio] [char](2) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[TelefonoSecundario] [varchar](50) NULL,
	[TelefonoCelular] [varchar](50) NULL,
	[NIT] [varchar](50) NULL,
	[DPI] [varchar](50) NOT NULL,
	[CorreoElectronico] [varchar](100) NULL,
	[FechaNacimiento] [date] NULL,
	[ProfesionUOficio] [varchar](150) NULL,
	[Activo] [bit] NOT NULL,
	[TieneUsuario] [int] NULL,
 CONSTRAINT [PK_TblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDepartamento]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDepartamento](
	[Departamento] [char](2) NOT NULL,
	[Nombre] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblFormaDePago]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFormaDePago](
	[IdFormaDePago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblFormaDePago] PRIMARY KEY CLUSTERED 
(
	[IdFormaDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMarca]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMarca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_TblMarca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMovimientos]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMovimientos](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdProductoCliente] [int] NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_TblMovimientos] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMunicipio]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMunicipio](
	[Departamento] [char](2) NOT NULL,
	[Municipio] [char](2) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPagina]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPagina](
	[IdPagina] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Controlador] [varchar](100) NOT NULL,
	[BHabilitado] [int] NOT NULL,
 CONSTRAINT [PK_TblPagina] PRIMARY KEY CLUSTERED 
(
	[IdPagina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblProducto]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblProducto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdAseguradora] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblProducto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblProductoCliente]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblProductoCliente](
	[IdProductoCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoProducto] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdFormaDePago] [int] NOT NULL,
	[DocumentoPoliza] [varchar](30) NOT NULL,
	[FechaInicial] [datetime] NOT NULL,
	[FechaFinal] [datetime] NULL,
	[ValorGeneral] [decimal](10, 2) NULL,
	[ValorPoliza] [decimal](10, 2) NOT NULL,
	[ValorActual] [decimal](10, 2) NOT NULL,
	[PrimaAnual] [decimal](10, 2) NOT NULL,
	[PrimaNeta] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_TblProductoCliente] PRIMARY KEY CLUSTERED 
(
	[IdProductoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRol]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[BHabilitado] [int] NOT NULL,
 CONSTRAINT [PK_TblRol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRolPagina]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRolPagina](
	[IdRolPagina] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdPagina] [int] NOT NULL,
	[BHabilitado] [int] NOT NULL,
 CONSTRAINT [PK_TblRolPagina] PRIMARY KEY CLUSTERED 
(
	[IdRolPagina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTipoProducto]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTipoProducto](
	[IdTipoProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TblTipoProducto] PRIMARY KEY CLUSTERED 
(
	[IdTipoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTipoVehiculo]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTipoVehiculo](
	[IdTipoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblTipoVehiculo] PRIMARY KEY CLUSTERED 
(
	[IdTipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUsuario]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUsuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[TipoUsuario] [char](1) NOT NULL,
	[Id] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_TblUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblVehiculo]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblVehiculo](
	[IdVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdTipoVehiculo] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[NumeroDePuertas] [tinyint] NOT NULL,
	[NumeroDeLlantas] [tinyint] NOT NULL,
	[NumeroDeAsientos] [tinyint] NOT NULL,
	[Motor] [decimal](4, 2) NOT NULL,
	[Cilindros] [tinyint] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblVehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblVehiculoCliente]    Script Date: 21/06/2021 22:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblVehiculoCliente](
	[IdVehiculoCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdVehiculo] [int] NOT NULL,
	[Documento] [int] NOT NULL,
	[Color] [varchar](30) NOT NULL,
	[VIN] [varchar](30) NOT NULL,
	[NumeroDePlaca] [char](10) NOT NULL,
	[Anio] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[IdProductoCliente] [int] NOT NULL,
 CONSTRAINT [PK_TblVehiculoCliente] PRIMARY KEY CLUSTERED 
(
	[IdVehiculoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblVehiculoCliente] ADD  CONSTRAINT [DF_TblVehiculoCliente_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[TblMovimientos]  WITH CHECK ADD  CONSTRAINT [FK_TblMovimientos_TblProductoCliente1] FOREIGN KEY([IdProductoCliente])
REFERENCES [dbo].[TblProductoCliente] ([IdProductoCliente])
GO
ALTER TABLE [dbo].[TblMovimientos] CHECK CONSTRAINT [FK_TblMovimientos_TblProductoCliente1]
GO
ALTER TABLE [dbo].[TblProducto]  WITH CHECK ADD  CONSTRAINT [FK_TblProducto_TblAseguradora] FOREIGN KEY([IdAseguradora])
REFERENCES [dbo].[TblAseguradora] ([IdAseguradora])
GO
ALTER TABLE [dbo].[TblProducto] CHECK CONSTRAINT [FK_TblProducto_TblAseguradora]
GO
ALTER TABLE [dbo].[TblProductoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblProductoCliente_TblCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TblCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TblProductoCliente] CHECK CONSTRAINT [FK_TblProductoCliente_TblCliente]
GO
ALTER TABLE [dbo].[TblProductoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblProductoCliente_TblFormaDePago] FOREIGN KEY([IdFormaDePago])
REFERENCES [dbo].[TblFormaDePago] ([IdFormaDePago])
GO
ALTER TABLE [dbo].[TblProductoCliente] CHECK CONSTRAINT [FK_TblProductoCliente_TblFormaDePago]
GO
ALTER TABLE [dbo].[TblProductoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblProductoCliente_TblTipoProducto] FOREIGN KEY([IdTipoProducto])
REFERENCES [dbo].[TblTipoProducto] ([IdTipoProducto])
GO
ALTER TABLE [dbo].[TblProductoCliente] CHECK CONSTRAINT [FK_TblProductoCliente_TblTipoProducto]
GO
ALTER TABLE [dbo].[TblTipoProducto]  WITH CHECK ADD  CONSTRAINT [FK_TblTipoProducto_TblProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[TblProducto] ([IdProducto])
GO
ALTER TABLE [dbo].[TblTipoProducto] CHECK CONSTRAINT [FK_TblTipoProducto_TblProducto]
GO
ALTER TABLE [dbo].[TblVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TblVehiculo_TblMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[TblMarca] ([IdMarca])
GO
ALTER TABLE [dbo].[TblVehiculo] CHECK CONSTRAINT [FK_TblVehiculo_TblMarca]
GO
ALTER TABLE [dbo].[TblVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_TblVehiculo_TblTipoVehiculo] FOREIGN KEY([IdTipoVehiculo])
REFERENCES [dbo].[TblTipoVehiculo] ([IdTipoVehiculo])
GO
ALTER TABLE [dbo].[TblVehiculo] CHECK CONSTRAINT [FK_TblVehiculo_TblTipoVehiculo]
GO
ALTER TABLE [dbo].[TblVehiculoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblVehiculoCliente_TblProductoCliente] FOREIGN KEY([IdProductoCliente])
REFERENCES [dbo].[TblProductoCliente] ([IdProductoCliente])
GO
ALTER TABLE [dbo].[TblVehiculoCliente] CHECK CONSTRAINT [FK_TblVehiculoCliente_TblProductoCliente]
GO
ALTER TABLE [dbo].[TblVehiculoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblVehiculoCliente_TblVehiculo1] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[TblVehiculo] ([IdVehiculo])
GO
ALTER TABLE [dbo].[TblVehiculoCliente] CHECK CONSTRAINT [FK_TblVehiculoCliente_TblVehiculo1]
GO
USE [master]
GO
ALTER DATABASE [DbAseguradora] SET  READ_WRITE 
GO
