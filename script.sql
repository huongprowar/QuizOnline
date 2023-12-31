USE [master]
GO
/****** Object:  Database [QuizOnline]    Script Date: 11/13/2023 1:07:35 AM ******/
CREATE DATABASE [QuizOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuizOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QuizOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuizOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QuizOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuizOnline] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuizOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuizOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuizOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuizOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuizOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuizOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuizOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuizOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuizOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuizOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuizOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuizOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuizOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuizOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuizOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuizOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuizOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuizOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [QuizOnline] SET  MULTI_USER 
GO
ALTER DATABASE [QuizOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuizOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuizOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuizOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuizOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuizOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuizOnline', N'ON'
GO
ALTER DATABASE [QuizOnline] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuizOnline] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuizOnline]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[AnswerContent] [nvarchar](50) NULL,
	[IsCorrect] [bit] NULL,
	[QuestionId] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[QuestionContent] [nvarchar](50) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultDetail]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultDetail](
	[ResultId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
 CONSTRAINT [PK_ResultDetail] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC,
	[QuestionId] ASC,
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[TestCode] [varchar](50) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/13/2023 1:07:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (1, N'OOP is a design pattern', 0, 1)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (2, N'OOP is a structure', 1, 1)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (3, N'OOP is hard', 0, 1)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (4, N'C#', 1, 2)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (5, N'Ass', 0, 2)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (6, N'C', 0, 2)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (7, N'Is database', 1, 3)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (8, N'Is nothing', 0, 3)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (9, N'Is a programming', 0, 3)
INSERT [dbo].[Answer] ([AnswerId], [AnswerContent], [IsCorrect], [QuestionId]) VALUES (10, N'HTML', 0, 2)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionId], [TestId], [QuestionContent]) VALUES (1, 1, N'What is OOP?')
INSERT [dbo].[Question] ([QuestionId], [TestId], [QuestionContent]) VALUES (2, 1, N'Which is OOP program ?')
INSERT [dbo].[Question] ([QuestionId], [TestId], [QuestionContent]) VALUES (3, 1, N'What is SQL')
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (1, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (2, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (3, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (4, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (5, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (6, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (7, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (8, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (9, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (11, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (12, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (13, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (14, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (15, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (16, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (17, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (18, 1, 1)
INSERT [dbo].[Result] ([ResultId], [TestId], [UserId]) VALUES (55, 1, 2)
SET IDENTITY_INSERT [dbo].[Result] OFF
GO
INSERT [dbo].[ResultDetail] ([ResultId], [QuestionId], [AnswerId]) VALUES (55, 1, 2)
INSERT [dbo].[ResultDetail] ([ResultId], [QuestionId], [AnswerId]) VALUES (55, 2, 4)
INSERT [dbo].[ResultDetail] ([ResultId], [QuestionId], [AnswerId]) VALUES (55, 3, 7)
GO
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([TestId], [CourseId], [TestCode]) VALUES (1, NULL, N'PRN231_TEST')
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (1, N'nam', N'nam', N'nam', N'nam', 0)
INSERT [dbo].[User] ([UserId], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (2, N'namnhhe163297', N'1', N'ngo hai', N'nam', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Test]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Test]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_User]
GO
ALTER TABLE [dbo].[ResultDetail]  WITH CHECK ADD  CONSTRAINT [FK_ResultDetail_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[ResultDetail] CHECK CONSTRAINT [FK_ResultDetail_Question]
GO
ALTER TABLE [dbo].[ResultDetail]  WITH CHECK ADD  CONSTRAINT [FK_ResultDetail_Result] FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO
ALTER TABLE [dbo].[ResultDetail] CHECK CONSTRAINT [FK_ResultDetail_Result]
GO
USE [master]
GO
ALTER DATABASE [QuizOnline] SET  READ_WRITE 
GO
