USE [master]
GO
/****** Object:  Database [db_PedeRoca]    Script Date: 14/03/2024 21:52:01 ******/
CREATE DATABASE [db_PedeRoca]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_PedeRoca', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\db_PedeRoca.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_PedeRoca_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\db_PedeRoca_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_PedeRoca] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_PedeRoca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_PedeRoca] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_PedeRoca] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_PedeRoca] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_PedeRoca] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_PedeRoca] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_PedeRoca] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_PedeRoca] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_PedeRoca] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_PedeRoca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_PedeRoca] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_PedeRoca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_PedeRoca] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_PedeRoca] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_PedeRoca] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_PedeRoca] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_PedeRoca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_PedeRoca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_PedeRoca] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_PedeRoca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_PedeRoca] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_PedeRoca] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_PedeRoca] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_PedeRoca] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_PedeRoca] SET  MULTI_USER 
GO
ALTER DATABASE [db_PedeRoca] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_PedeRoca] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_PedeRoca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_PedeRoca] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_PedeRoca] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_PedeRoca] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_PedeRoca] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_PedeRoca] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_PedeRoca]
GO
/****** Object:  Table [dbo].[tb_banners]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_banners](
	[id_banner] [int] IDENTITY(1,1) NOT NULL,
	[imagem1] [varchar](200) NOT NULL,
	[imagem2] [varchar](200) NOT NULL,
	[imagem3] [varchar](200) NOT NULL,
	[url_banner] [varchar](500) NOT NULL,
	[descricao] [varchar](200) NOT NULL,
	[validade] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_banner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_carrinhoCompras]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_carrinhoCompras](
	[id_carrinhoCompra] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_carrinhoCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_compras]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_compras](
	[id_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_carrinhoCompra] [int] NOT NULL,
	[dataHoraCompra] [datetime] NOT NULL,
	[valorTotal] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_contatos]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_contatos](
	[id_contato] [int] IDENTITY(1,1) NOT NULL,
	[e_mail] [varchar](100) NOT NULL,
	[conteudo] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_contato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_favoritoProdutos]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_favoritoProdutos](
	[id_favoritoProduto] [int] IDENTITY(1,1) NOT NULL,
	[id_produto] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_favoritoProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_itensCarrinho]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_itensCarrinho](
	[id_itemCarrinho] [int] IDENTITY(1,1) NOT NULL,
	[id_produto] [int] NOT NULL,
	[id_carrinhoCompra] [int] NOT NULL,
	[quantidade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_itemCarrinho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_produtos]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_produtos](
	[id_produto] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[descricao] [varchar](150) NOT NULL,
	[imagem] [varchar](200) NOT NULL,
	[qtd_estoque] [int] NOT NULL,
	[preco_unitario] [decimal](18, 2) NOT NULL,
	[unidade] [int] NOT NULL,
	[tipo_produto] [int] NOT NULL,
	[ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuarios]    Script Date: 14/03/2024 21:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[cpf] [varchar](14) NOT NULL,
	[telefone] [varchar](15) NOT NULL,
	[data_nascimento] [date] NOT NULL,
	[e_maiL] [varchar](100) NOT NULL,
	[cep] [varchar](9) NOT NULL,
	[uf] [varchar](25) NOT NULL,
	[cidade] [varchar](50) NOT NULL,
	[logradouro] [varchar](200) NOT NULL,
	[bairro] [varchar](50) NOT NULL,
	[numero] [int] NOT NULL,
	[complemento] [varchar](200) NULL,
	[senha] [varchar](500) NOT NULL,
	[notific_WP] [bit] NOT NULL,
	[notific_SMS] [bit] NOT NULL,
	[notific_Email] [bit] NOT NULL,
	[ativo] [bit] NOT NULL,
	[nivel_acesso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_usuarios] ADD  DEFAULT ((2)) FOR [nivel_acesso]
GO
ALTER TABLE [dbo].[tb_carrinhoCompras]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tb_usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[tb_compras]  WITH CHECK ADD FOREIGN KEY([id_carrinhoCompra])
REFERENCES [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra])
GO
ALTER TABLE [dbo].[tb_compras]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tb_usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[tb_favoritoProdutos]  WITH CHECK ADD FOREIGN KEY([id_produto])
REFERENCES [dbo].[tb_produtos] ([id_produto])
GO
ALTER TABLE [dbo].[tb_favoritoProdutos]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[tb_usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[tb_itensCarrinho]  WITH CHECK ADD FOREIGN KEY([id_carrinhoCompra])
REFERENCES [dbo].[tb_carrinhoCompras] ([id_carrinhoCompra])
GO
ALTER TABLE [dbo].[tb_itensCarrinho]  WITH CHECK ADD FOREIGN KEY([id_produto])
REFERENCES [dbo].[tb_produtos] ([id_produto])
GO
USE [master]
GO
ALTER DATABASE [db_PedeRoca] SET  READ_WRITE 
GO
