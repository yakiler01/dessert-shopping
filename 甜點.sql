USE [master]
GO
/****** Object:  Database [order-shopping]    Script Date: 2022/12/19 下午 02:05:11 ******/
CREATE DATABASE [order-shopping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'order_processing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\order-shopping.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'order_processing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\order-shopping_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [order-shopping] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [order-shopping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [order-shopping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [order-shopping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [order-shopping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [order-shopping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [order-shopping] SET ARITHABORT OFF 
GO
ALTER DATABASE [order-shopping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [order-shopping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [order-shopping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [order-shopping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [order-shopping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [order-shopping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [order-shopping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [order-shopping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [order-shopping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [order-shopping] SET  DISABLE_BROKER 
GO
ALTER DATABASE [order-shopping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [order-shopping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [order-shopping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [order-shopping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [order-shopping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [order-shopping] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [order-shopping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [order-shopping] SET RECOVERY FULL 
GO
ALTER DATABASE [order-shopping] SET  MULTI_USER 
GO
ALTER DATABASE [order-shopping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [order-shopping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [order-shopping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [order-shopping] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [order-shopping] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [order-shopping] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'order-shopping', N'ON'
GO
ALTER DATABASE [order-shopping] SET QUERY_STORE = OFF
GO
USE [order-shopping]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 2022/12/19 下午 02:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[user_phone] [nvarchar](10) NULL,
	[user_sum] [int] NULL,
	[user_time] [nvarchar](50) NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member]    Script Date: 2022/12/19 下午 02:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[account] [nvarchar](100) NULL,
 CONSTRAINT [PK_member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_cart]    Script Date: 2022/12/19 下午 02:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_cart](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](500) NULL,
	[product_quantity] [nvarchar](500) NULL,
	[product_price] [nvarchar](500) NULL,
	[product_sum] [int] NULL,
	[istakeaway] [bit] NULL,
	[isstate] [bit] NULL,
 CONSTRAINT [PK_order_cart_1] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 2022/12/19 下午 02:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[products_id] [int] IDENTITY(1,1) NOT NULL,
	[products_name] [nvarchar](100) NULL,
	[products_narvative] [nvarchar](500) NULL,
	[products_price] [int] NULL,
	[products_image] [nvarchar](100) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[products_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customers] ON 

INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (8, N'黃彥琳', N'0932905577', 2, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (9, N'江依俊', N'0939048257', 2, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (11, N'李睿琇', N'0923967855', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (12, N'陳振湖', N'0915160452', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (13, N'陳家瑩', N'0960075370', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (14, N'邱倫秋', N'0922884928', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (16, N'瞿素恬', N'0955892248', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (17, N'吳孟和', N'0918101823', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (18, N'王韋志', N'0931966032', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (19, N'林婉芳', N'0926408176', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (20, N'楊惠盈', N'0924804784', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (21, N'宋香惟', N'0971717291', 0, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (22, N'張玉昀', N'0912699752', 3, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (23, N'吳嘉婷', N'0914918304', 0, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (24, N'黃穎蓮', N'0910161614', 0, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (25, N'趙素貞', N'0935146992', 0, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (26, N'林肇芬', N'0961305665', 1, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (27, N'羅樂芝', N'0955668952', 2, N'2024121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (28, N'陳信勇', N'0972966984', 2, N'2022121615')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (30, N'許玉婷', N'0989040186', 1, N'2030111111')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (31, N'陳惠敏', N'0931944638', 4, N'2030111111')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (32, N'柯國偉', N'0986740106', 1, N'2030111111')
INSERT [dbo].[customers] ([user_id], [user_name], [user_phone], [user_sum], [user_time]) VALUES (33, N'123', N'123', 4, N'2022121915')
SET IDENTITY_INSERT [dbo].[customers] OFF
GO
SET IDENTITY_INSERT [dbo].[member] ON 

INSERT [dbo].[member] ([id], [name], [password], [account]) VALUES (1, N'賴俊廷', N'123456', N'yakiler')
INSERT [dbo].[member] ([id], [name], [password], [account]) VALUES (2, N'大中天', N'123', N'123')
SET IDENTITY_INSERT [dbo].[member] OFF
GO
SET IDENTITY_INSERT [dbo].[order_cart] ON 

INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (8, N'法國歌劇巧克力可頌,寇露蕾派捲,史多倫蛋糕', N'4,2,1', N'150,120,480', 7, 1, 1)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (9, N'史多倫蛋糕', N'2', N'480', 2, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (11, N'法式純巧克力蛋糕,法國歌劇巧克力可頌,寇露蕾派捲,史多倫蛋糕', N'2,2,4,4', N'620,150,120,480', 12, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (12, N'法國國王派,法式純巧克力蛋糕,寇露蕾派捲', N'1,1,1', N'980,620,120', 3, 0, 1)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (13, N'史多倫蛋糕,法國歌劇巧克力可頌,法國國王派,法式純巧克力蛋糕,寇露蕾派捲', N'2,1,1,1,1', N'480,150,980,620,120', 6, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (14, N'法國國王派', N'2', N'980', 2, 0, 1)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (16, N'史多倫蛋糕', N'3', N'480', 3, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (17, N'史多倫蛋糕,法式純巧克力蛋糕', N'1,1', N'480,620', 2, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (18, N'法國歌劇巧克力可頌,法式純巧克力蛋糕,法國國王派', N'1,1,3', N'150,620,980', 5, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (19, N'法國歌劇巧克力可頌', N'1', N'150', 1, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (20, N'史多倫蛋糕', N'3', N'480', 3, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (21, N'法國歌劇巧克力可頌', N'2', N'150', 2, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (22, N'史多倫蛋糕,法式純巧克力蛋糕', N'1,1', N'480,620', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (23, N'法式純巧克力蛋糕,法國國王派,法國歌劇巧克力可頌', N'2,2,2', N'620,980,150', 6, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (24, N'法式純巧克力蛋糕,法國國王派,法國歌劇巧克力可頌', N'2,2,2', N'620,980,150', 6, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (25, N'史多倫蛋糕,法式純巧克力蛋糕', N'2,1', N'480,620', 3, 0, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (26, N'法國歌劇巧克力可頌,法式純巧克力蛋糕', N'1,1', N'150,620', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (27, N'史多倫蛋糕', N'2', N'480', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (28, N'史多倫蛋糕', N'3', N'480', 3, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (30, N'史多倫蛋糕', N'2', N'480', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (31, N'', N'', N'', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (32, N'史多倫蛋糕', N'2', N'480', 2, 1, 0)
INSERT [dbo].[order_cart] ([user_id], [product_name], [product_quantity], [product_price], [product_sum], [istakeaway], [isstate]) VALUES (33, N'法國國王派', N'1', N'980', 1, 1, 0)
SET IDENTITY_INSERT [dbo].[order_cart] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([products_id], [products_name], [products_narvative], [products_price], [products_image]) VALUES (1, N'史多倫', N'入口前段為史多倫麵團獨特發酵層次中段帶出加了台灣純龍眼蜂蜜、法國Negrita深色蘭姆酒、日本梅乃宿柚子酒浸泡水果香氣為主調、尾端味覺帶出輕盈絲綢般日本柚子的清香感受。
不放香料、希望以果香主調加上發酵香氣、德國杏仁糕不同的層層感受來呈現！
絕對不會讓您失望！！', 480, NULL)
INSERT [dbo].[products] ([products_id], [products_name], [products_narvative], [products_price], [products_image]) VALUES (2, N'法國歌劇巧克力可頌', N'迷人的可頌層次，法國蒙太古AOP奶油特殊香氣、62٪薩馬那莊園巧克力
怎麼能錯過呢？！', 150, NULL)
INSERT [dbo].[products] ([products_id], [products_name], [products_narvative], [products_price], [products_image]) VALUES (3, N'法國國王派', N'國王派是法國傳統糕點，每年１月６日前後都會出
現它的蹤影，是慶祝新年的點心。國王派象徵著祝
福及幸運，藏在其中稱為“Feve”的小陶偶，誰拿到
誰就是當天的國王，一整年都會幸運順利。', 980, NULL)
INSERT [dbo].[products] ([products_id], [products_name], [products_narvative], [products_price], [products_image]) VALUES (4, N'法式純巧克力蛋糕
', N'法國歐貝拉63%巧克力、日本奶霜。

', 620, NULL)
INSERT [dbo].[products] ([products_id], [products_name], [products_narvative], [products_price], [products_image]) VALUES (5, N'寇露蕾派捲', N'寇露蕾派捲外殼有如千層派的酥脆口感，也是店裡的超人氣商品，點餐後主廚才會現場填充內餡，保持最完美的酥脆口感 !', 120, NULL)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
ALTER TABLE [dbo].[customers]  WITH CHECK ADD  CONSTRAINT [FK_customers_customers] FOREIGN KEY([user_id])
REFERENCES [dbo].[customers] ([user_id])
GO
ALTER TABLE [dbo].[customers] CHECK CONSTRAINT [FK_customers_customers]
GO
USE [master]
GO
ALTER DATABASE [order-shopping] SET  READ_WRITE 
GO
