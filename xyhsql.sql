USE [EPSMS_Database]
GO
/****** Object:  Table [dbo].[Table_AttendanceData]    Script Date: 2019/1/11 10:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_AttendanceData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[AttendanceDate] [datetime] NULL,
	[Type] [varchar](50) NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_Table_AttendanceData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_BonusData]    Script Date: 2019/1/11 10:53:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_BonusData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[Bonus] [int] NULL,
	[Fine] [int] NULL,
	[BonusInTotal] [int] NULL,
 CONSTRAINT [PK_Table_BonusData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_PayData]    Script Date: 2019/1/11 10:53:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_PayData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[BasePay] [int] NULL,
	[RealPay] [int] NULL,
	[BonusInTotal] [int] NULL,
 CONSTRAINT [PK_Table_PayData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_RecordData]    Script Date: 2019/1/11 10:53:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_RecordData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[Position] [varchar](20) NULL,
	[Age] [varchar](20) NULL,
	[Sex] [varchar](20) NULL,
 CONSTRAINT [PK_Table_RecordData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_ReportData]    Script Date: 2019/1/11 10:53:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_ReportData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[PassWord] [varchar](20) NULL,
	[UserRight] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_UserData]    Script Date: 2019/1/11 10:53:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_UserData](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[PassWord] [varchar](20) NULL,
	[UserRight] [varchar](20) NULL,
	[IsDel] [bit] NULL,
 CONSTRAINT [PK_Table_UserData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Table_AttendanceData] ([ID], [Name], [AttendanceDate], [Type], [Remark]) VALUES (1001, N'xyh', CAST(N'2019-01-01T00:00:00.000' AS DateTime), N'迟到', N'生病')
INSERT [dbo].[Table_AttendanceData] ([ID], [Name], [AttendanceDate], [Type], [Remark]) VALUES (1002, N'fyl', CAST(N'2019-02-13T00:00:00.000' AS DateTime), N'请假', N'打游戏')
INSERT [dbo].[Table_AttendanceData] ([ID], [Name], [AttendanceDate], [Type], [Remark]) VALUES (1003, N'mys', CAST(N'2019-03-04T00:00:00.000' AS DateTime), N'迟到', N'累啦')
INSERT [dbo].[Table_AttendanceData] ([ID], [Name], [AttendanceDate], [Type], [Remark]) VALUES (1004, N'yb', CAST(N'2019-03-01T00:00:00.000' AS DateTime), N'迟到', N'玩')
INSERT [dbo].[Table_AttendanceData] ([ID], [Name], [AttendanceDate], [Type], [Remark]) VALUES (1005, N'fsa', CAST(N'2019-04-05T00:00:00.000' AS DateTime), N'早退', N'失踪')
INSERT [dbo].[Table_BonusData] ([ID], [Name], [Bonus], [Fine], [BonusInTotal]) VALUES (1001, N'xyhf', 100, 50, 50)
INSERT [dbo].[Table_BonusData] ([ID], [Name], [Bonus], [Fine], [BonusInTotal]) VALUES (1002, N'fds', 40, 60, -20)
INSERT [dbo].[Table_BonusData] ([ID], [Name], [Bonus], [Fine], [BonusInTotal]) VALUES (1003, N'mys', 17, 80, -63)
INSERT [dbo].[Table_BonusData] ([ID], [Name], [Bonus], [Fine], [BonusInTotal]) VALUES (1004, N'fsa', 100, 30, 70)
INSERT [dbo].[Table_BonusData] ([ID], [Name], [Bonus], [Fine], [BonusInTotal]) VALUES (1005, N'dfs', 100, 40, 60)
INSERT [dbo].[Table_PayData] ([ID], [Name], [BasePay], [RealPay], [BonusInTotal]) VALUES (1001, N'xyhf', 4000, 4100, 100)
INSERT [dbo].[Table_PayData] ([ID], [Name], [BasePay], [RealPay], [BonusInTotal]) VALUES (1002, N'fds', 4000, 4500, 500)
INSERT [dbo].[Table_PayData] ([ID], [Name], [BasePay], [RealPay], [BonusInTotal]) VALUES (1003, N'mys', 4000, 4300, 300)
INSERT [dbo].[Table_PayData] ([ID], [Name], [BasePay], [RealPay], [BonusInTotal]) VALUES (1004, N'fsa', 4000, 4400, 400)
INSERT [dbo].[Table_PayData] ([ID], [Name], [BasePay], [RealPay], [BonusInTotal]) VALUES (1005, N'dfs', 4000, 4500, 500)
INSERT [dbo].[Table_RecordData] ([ID], [Name], [Position], [Age], [Sex]) VALUES (1001, N'xyh', N'员工', N'10', N'男')
INSERT [dbo].[Table_RecordData] ([ID], [Name], [Position], [Age], [Sex]) VALUES (1002, N'fyl', N'员工', N'11', N'男')
INSERT [dbo].[Table_RecordData] ([ID], [Name], [Position], [Age], [Sex]) VALUES (1003, N'mys', N'员工', N'12', N'女')
INSERT [dbo].[Table_RecordData] ([ID], [Name], [Position], [Age], [Sex]) VALUES (1004, N'lds', N'总经理', N'7', N'男')
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1001, N'xyh', N'123', N'1', 0)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1002, N'fyl', N'1234', N'1', 0)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1003, N'mys', N'123', N'2', 0)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1004, NULL, NULL, NULL, NULL)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1005, NULL, NULL, NULL, NULL)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1006, NULL, NULL, NULL, NULL)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1007, NULL, NULL, NULL, NULL)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1008, NULL, NULL, NULL, NULL)
INSERT [dbo].[Table_UserData] ([ID], [Name], [PassWord], [UserRight], [IsDel]) VALUES (1009, N'fadf', N'123', N'3', 0)
