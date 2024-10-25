USE [master]
GO
/****** Object:  Database [Program]    Script Date: 27.09.2024 19:13:30 ******/
CREATE DATABASE [Program]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Program', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL\MSSQL\DATA\Program.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Program_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL\MSSQL\DATA\Program_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Program] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Program].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Program] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Program] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Program] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Program] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Program] SET ARITHABORT OFF 
GO
ALTER DATABASE [Program] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Program] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Program] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Program] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Program] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Program] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Program] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Program] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Program] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Program] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Program] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Program] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Program] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Program] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Program] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Program] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Program] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Program] SET RECOVERY FULL 
GO
ALTER DATABASE [Program] SET  MULTI_USER 
GO
ALTER DATABASE [Program] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Program] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Program] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Program] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Program] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Program] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Program', N'ON'
GO
ALTER DATABASE [Program] SET QUERY_STORE = OFF
GO
USE [Program]
GO
/****** Object:  Table [dbo].[Вид]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вид](
	[Код_вида] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NULL,
 CONSTRAINT [PK_Вид] PRIMARY KEY CLUSTERED 
(
	[Код_вида] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Доп_материал]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Доп_материал](
	[Код_доп] [int] IDENTITY(1,1) NOT NULL,
	[Код_материала] [int] NULL,
	[Количество] [nvarchar](50) NULL,
 CONSTRAINT [PK_Доп_материал] PRIMARY KEY CLUSTERED 
(
	[Код_доп] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заявка1]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заявка1](
	[Код_заявки] [int] IDENTITY(1,1) NOT NULL,
	[Дата] [date] NULL,
	[Код_оргтехники] [int] NULL,
	[Описание] [nvarchar](200) NULL,
	[Код_пользователя] [int] NULL,
	[ФИО_клиента] [nvarchar](150) NULL,
	[Телефон] [nvarchar](11) NULL,
	[Код_статуса] [int] NULL,
	[Код_мастера] [int] NULL,
	[Номер_заявки] [nvarchar](50) NULL,
	[Комментарий] [nvarchar](200) NULL,
 CONSTRAINT [PK_Заявка1] PRIMARY KEY CLUSTERED 
(
	[Код_заявки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Материал]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Материал](
	[Код_материала] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NULL,
 CONSTRAINT [PK_Материал] PRIMARY KEY CLUSTERED 
(
	[Код_материала] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Оргтехника]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Оргтехника](
	[Код_оргтехники] [int] IDENTITY(1,1) NOT NULL,
	[Модель] [nvarchar](50) NULL,
	[Код_вида] [int] NULL,
 CONSTRAINT [PK_Оргтехника] PRIMARY KEY CLUSTERED 
(
	[Код_оргтехники] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Отчёт]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Отчёт](
	[Код_отчёта] [int] IDENTITY(1,1) NOT NULL,
	[Количество_гот_заяврок] [nvarchar](50) NULL,
	[Время_выполнения] [nvarchar](50) NULL,
	[Код_заявки] [int] NULL,
	[Код_доп] [int] NULL,
 CONSTRAINT [PK_Отчёт] PRIMARY KEY CLUSTERED 
(
	[Код_отчёта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователь]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователь](
	[Код_пользователя] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [nvarchar](50) NULL,
	[Пароль] [nvarchar](50) NULL,
	[Код_типа_пользователя] [int] NULL,
	[ФИО] [nvarchar](150) NULL,
	[Телефон] [nvarchar](50) NULL,
 CONSTRAINT [PK_Пользователь] PRIMARY KEY CLUSTERED 
(
	[Код_пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Статус]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Статус](
	[Код_статуса] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](100) NULL,
 CONSTRAINT [PK_Статус] PRIMARY KEY CLUSTERED 
(
	[Код_статуса] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Тип_пользователя]    Script Date: 27.09.2024 19:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Тип_пользователя](
	[Код_типа_пользователя] [int] IDENTITY(1,1) NOT NULL,
	[Должность] [nvarchar](50) NULL,
 CONSTRAINT [PK_Тип_пользователя] PRIMARY KEY CLUSTERED 
(
	[Код_типа_пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Вид] ON 
GO
INSERT [dbo].[Вид] ([Код_вида], [Наименование]) VALUES (1, N'Принтер')
GO
INSERT [dbo].[Вид] ([Код_вида], [Наименование]) VALUES (2, N'Ноутбук')
GO
INSERT [dbo].[Вид] ([Код_вида], [Наименование]) VALUES (3, N'Телефон')
GO
SET IDENTITY_INSERT [dbo].[Вид] OFF
GO
SET IDENTITY_INSERT [dbo].[Доп_материал] ON 
GO
INSERT [dbo].[Доп_материал] ([Код_доп], [Код_материала], [Количество]) VALUES (1, 1, N'1')
GO
SET IDENTITY_INSERT [dbo].[Доп_материал] OFF
GO
SET IDENTITY_INSERT [dbo].[Заявка1] ON 
GO
INSERT [dbo].[Заявка1] ([Код_заявки], [Дата], [Код_оргтехники], [Описание], [Код_пользователя], [ФИО_клиента], [Телефон], [Код_статуса], [Код_мастера], [Номер_заявки], [Комментарий]) VALUES (1, CAST(N'2024-09-21' AS Date), 1, N'Сломался принтер, причины неизвестны!', 1, N'Суслов Д.В.', N'89569857844', 1, 3, N'6461', N'Будет сделанно!')
GO
INSERT [dbo].[Заявка1] ([Код_заявки], [Дата], [Код_оргтехники], [Описание], [Код_пользователя], [ФИО_клиента], [Телефон], [Код_статуса], [Код_мастера], [Номер_заявки], [Комментарий]) VALUES (2, CAST(N'2024-09-21' AS Date), 2, N'Не работает.', 1, N'Рыгалов Б.Л.', N'89067654534', 3, 3, N'3410', NULL)
GO
INSERT [dbo].[Заявка1] ([Код_заявки], [Дата], [Код_оргтехники], [Описание], [Код_пользователя], [ФИО_клиента], [Телефон], [Код_статуса], [Код_мастера], [Номер_заявки], [Комментарий]) VALUES (3, CAST(N'2024-09-25' AS Date), 3, N'Разбито стекло.', 2, N'Григорьев Семён Викторович', N'89219567849', 3, 3, N'2578', N'Все хорошо')
GO
INSERT [dbo].[Заявка1] ([Код_заявки], [Дата], [Код_оргтехники], [Описание], [Код_пользователя], [ФИО_клиента], [Телефон], [Код_статуса], [Код_мастера], [Номер_заявки], [Комментарий]) VALUES (4, CAST(N'2024-09-25' AS Date), 4, N'Не принимает краску.', 2, N'Григорьев Семён Викторович', N'89219567849', NULL, NULL, N'2641', NULL)
GO
INSERT [dbo].[Заявка1] ([Код_заявки], [Дата], [Код_оргтехники], [Описание], [Код_пользователя], [ФИО_клиента], [Телефон], [Код_статуса], [Код_мастера], [Номер_заявки], [Комментарий]) VALUES (5, CAST(N'2024-09-27' AS Date), 5, N'Нет питания.', 2, N'Григорьев Семён Викторович', N'89219567849', NULL, NULL, N'3353', NULL)
GO
SET IDENTITY_INSERT [dbo].[Заявка1] OFF
GO
SET IDENTITY_INSERT [dbo].[Материал] ON 
GO
INSERT [dbo].[Материал] ([Код_материала], [Наименование]) VALUES (1, N'Материнская плата')
GO
INSERT [dbo].[Материал] ([Код_материала], [Наименование]) VALUES (2, N'Стекло')
GO
INSERT [dbo].[Материал] ([Код_материала], [Наименование]) VALUES (3, N'Болт')
GO
INSERT [dbo].[Материал] ([Код_материала], [Наименование]) VALUES (4, N'Батарея')
GO
INSERT [dbo].[Материал] ([Код_материала], [Наименование]) VALUES (5, N'Лазер')
GO
SET IDENTITY_INSERT [dbo].[Материал] OFF
GO
SET IDENTITY_INSERT [dbo].[Оргтехника] ON 
GO
INSERT [dbo].[Оргтехника] ([Код_оргтехники], [Модель], [Код_вида]) VALUES (1, N'SLX-4000', 1)
GO
INSERT [dbo].[Оргтехника] ([Код_оргтехники], [Модель], [Код_вида]) VALUES (2, N'KLJf834', 2)
GO
INSERT [dbo].[Оргтехника] ([Код_оргтехники], [Модель], [Код_вида]) VALUES (3, N'Honor 9X', 3)
GO
INSERT [dbo].[Оргтехника] ([Код_оргтехники], [Модель], [Код_вида]) VALUES (4, N'SLT-1467', 1)
GO
INSERT [dbo].[Оргтехника] ([Код_оргтехники], [Модель], [Код_вида]) VALUES (5, N'Lenovo', 2)
GO
SET IDENTITY_INSERT [dbo].[Оргтехника] OFF
GO
SET IDENTITY_INSERT [dbo].[Отчёт] ON 
GO
INSERT [dbo].[Отчёт] ([Код_отчёта], [Количество_гот_заяврок], [Время_выполнения], [Код_заявки], [Код_доп]) VALUES (1, N'2', N'106 Мин.', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Отчёт] OFF
GO
SET IDENTITY_INSERT [dbo].[Пользователь] ON 
GO
INSERT [dbo].[Пользователь] ([Код_пользователя], [Логин], [Пароль], [Код_типа_пользователя], [ФИО], [Телефон]) VALUES (1, N'login1', N'login1', 1, N'Носов Иван Михайлович', N'89210563128')
GO
INSERT [dbo].[Пользователь] ([Код_пользователя], [Логин], [Пароль], [Код_типа_пользователя], [ФИО], [Телефон]) VALUES (2, N'klient', N'klient', 3, N'Григорьев Семён Викторович', N'89219567849')
GO
INSERT [dbo].[Пользователь] ([Код_пользователя], [Логин], [Пароль], [Код_типа_пользователя], [ФИО], [Телефон]) VALUES (3, N'master', N'master', 2, N'Никифоров Иван Дмитриевич', N'89210673849')
GO
INSERT [dbo].[Пользователь] ([Код_пользователя], [Логин], [Пароль], [Код_типа_пользователя], [ФИО], [Телефон]) VALUES (4, N'login12', N'pass12', 3, N'Сорокин Дмитрий Ильич', N'89219567841')
GO
SET IDENTITY_INSERT [dbo].[Пользователь] OFF
GO
SET IDENTITY_INSERT [dbo].[Статус] ON 
GO
INSERT [dbo].[Статус] ([Код_статуса], [Наименование]) VALUES (1, N'Новая заявка')
GO
INSERT [dbo].[Статус] ([Код_статуса], [Наименование]) VALUES (2, N'В процессе ремонта')
GO
INSERT [dbo].[Статус] ([Код_статуса], [Наименование]) VALUES (3, N'Завершена')
GO
SET IDENTITY_INSERT [dbo].[Статус] OFF
GO
SET IDENTITY_INSERT [dbo].[Тип_пользователя] ON 
GO
INSERT [dbo].[Тип_пользователя] ([Код_типа_пользователя], [Должность]) VALUES (1, N'Менеджер')
GO
INSERT [dbo].[Тип_пользователя] ([Код_типа_пользователя], [Должность]) VALUES (2, N'Мастер')
GO
INSERT [dbo].[Тип_пользователя] ([Код_типа_пользователя], [Должность]) VALUES (3, N'Клиент')
GO
SET IDENTITY_INSERT [dbo].[Тип_пользователя] OFF
GO
ALTER TABLE [dbo].[Доп_материал]  WITH CHECK ADD  CONSTRAINT [FK_Доп_материал_Материал] FOREIGN KEY([Код_материала])
REFERENCES [dbo].[Материал] ([Код_материала])
GO
ALTER TABLE [dbo].[Доп_материал] CHECK CONSTRAINT [FK_Доп_материал_Материал]
GO
ALTER TABLE [dbo].[Заявка1]  WITH CHECK ADD  CONSTRAINT [FK_Заявка1_Оргтехника] FOREIGN KEY([Код_оргтехники])
REFERENCES [dbo].[Оргтехника] ([Код_оргтехники])
GO
ALTER TABLE [dbo].[Заявка1] CHECK CONSTRAINT [FK_Заявка1_Оргтехника]
GO
ALTER TABLE [dbo].[Заявка1]  WITH CHECK ADD  CONSTRAINT [FK_Заявка1_Пользователь] FOREIGN KEY([Код_пользователя])
REFERENCES [dbo].[Пользователь] ([Код_пользователя])
GO
ALTER TABLE [dbo].[Заявка1] CHECK CONSTRAINT [FK_Заявка1_Пользователь]
GO
ALTER TABLE [dbo].[Заявка1]  WITH CHECK ADD  CONSTRAINT [FK_Заявка1_Статус] FOREIGN KEY([Код_статуса])
REFERENCES [dbo].[Статус] ([Код_статуса])
GO
ALTER TABLE [dbo].[Заявка1] CHECK CONSTRAINT [FK_Заявка1_Статус]
GO
ALTER TABLE [dbo].[Оргтехника]  WITH CHECK ADD  CONSTRAINT [FK_Оргтехника_Вид] FOREIGN KEY([Код_вида])
REFERENCES [dbo].[Вид] ([Код_вида])
GO
ALTER TABLE [dbo].[Оргтехника] CHECK CONSTRAINT [FK_Оргтехника_Вид]
GO
ALTER TABLE [dbo].[Отчёт]  WITH CHECK ADD  CONSTRAINT [FK_Отчёт_Доп_материал] FOREIGN KEY([Код_доп])
REFERENCES [dbo].[Доп_материал] ([Код_доп])
GO
ALTER TABLE [dbo].[Отчёт] CHECK CONSTRAINT [FK_Отчёт_Доп_материал]
GO
ALTER TABLE [dbo].[Отчёт]  WITH CHECK ADD  CONSTRAINT [FK_Отчёт_Заявка1] FOREIGN KEY([Код_заявки])
REFERENCES [dbo].[Заявка1] ([Код_заявки])
GO
ALTER TABLE [dbo].[Отчёт] CHECK CONSTRAINT [FK_Отчёт_Заявка1]
GO
ALTER TABLE [dbo].[Пользователь]  WITH CHECK ADD  CONSTRAINT [FK_Пользователь_Тип_пользователя] FOREIGN KEY([Код_типа_пользователя])
REFERENCES [dbo].[Тип_пользователя] ([Код_типа_пользователя])
GO
ALTER TABLE [dbo].[Пользователь] CHECK CONSTRAINT [FK_Пользователь_Тип_пользователя]
GO
USE [master]
GO
ALTER DATABASE [Program] SET  READ_WRITE 
GO
