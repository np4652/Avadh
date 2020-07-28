USE [SchoolErp]
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 08-07-2020 19:48:30 ******/
DROP PROCEDURE [dbo].[Registration]
GO
/****** Object:  Table [dbo].[VedioDetail]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[VedioDetail]
GO
/****** Object:  Table [dbo].[UsersLogin]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[UsersLogin]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[SummeryDetails]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[SummeryDetails]
GO
/****** Object:  Table [dbo].[SubjectMaster]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[SubjectMaster]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[RoleMaster]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 08-07-2020 19:48:30 ******/
DROP TABLE [dbo].[Persons]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persons](
	[Personid] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[Age] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Personid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubjectMaster]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubjectMaster](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](50) NULL,
 CONSTRAINT [PK_SubjectMaster] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SummeryDetails]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SummeryDetails](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[loginTime] [varchar](50) NULL,
	[logoutTime] [varchar](50) NULL,
 CONSTRAINT [PK_SummeryDetails] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[RegId] [int] IDENTITY(2020001,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Father_Name] [varchar](50) NULL,
	[Mother_Name] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[Class] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[DOB] [varchar](50) NULL,
	[LastSchool] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsersLogin]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsersLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_UserPasswordDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VedioDetail]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VedioDetail](
	[vedioId] [int] IDENTITY(1,1) NOT NULL,
	[vedioName] [varchar](350) NULL,
	[vedioForClass] [varchar](50) NULL,
	[VedioTittle] [varchar](250) NULL,
	[vedioUrl] [varchar](350) NULL,
	[Subject] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[vedioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 

GO
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (2, N'Teacher')
GO
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (3, N'Student')
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[SubjectMaster] ON 

GO
INSERT [dbo].[SubjectMaster] ([SubjectId], [SubjectName]) VALUES (1, N'Maths')
GO
INSERT [dbo].[SubjectMaster] ([SubjectId], [SubjectName]) VALUES (2, N'Hindi')
GO
INSERT [dbo].[SubjectMaster] ([SubjectId], [SubjectName]) VALUES (3, N'Science')
GO
INSERT [dbo].[SubjectMaster] ([SubjectId], [SubjectName]) VALUES (4, N'English')
GO
SET IDENTITY_INSERT [dbo].[SubjectMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[SummeryDetails] ON 

GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (1, 2020015, N'16 June 2020 05:35:19 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (2, 2020015, N'16 June 2020 05:37:26 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (3, 2020015, N'17 June 2020 05:51:29 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (4, 2020015, N'17 June 2020 05:57:01 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (5, 2020015, N'17 June 2020 05:59:57 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (6, 2020015, N'17 June 2020 06:23:52 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (7, 2020015, N'17 June 2020 06:30:06 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (8, 2020015, N'17 June 2020 06:35:38 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (9, 2020015, N'17 June 2020 06:38:57 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (10, 2020015, N'17 June 2020 06:43:59 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (11, 2020015, N'17 June 2020 06:48:47 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (12, 2020015, N'17 June 2020 06:52:26 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (13, 2020015, N'17 June 2020 07:20:06 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (14, 2020015, N'17 June 2020 07:51:40 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (15, 2020015, N'17 June 2020 08:16:56 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (16, 2020015, N'17 June 2020 08:40:55 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (17, 2020015, N'17 June 2020 09:10:02 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (18, 2020015, N'19 June 2020 01:02:27 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (19, 2020015, N'19 June 2020 01:57:44 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (20, 2020015, N'19 June 2020 02:04:17 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (21, 2020010, N'19 June 2020 03:20:44 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (22, 2020010, N'19 June 2020 03:20:59 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (23, 2020010, N'19 June 2020 03:21:52 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (24, 2020010, N'19 June 2020 03:22:24 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (25, 2020010, N'19 June 2020 03:31:09 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (26, 2020017, N'19 June 2020 03:38:36 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (27, 2020015, N'19 June 2020 03:46:38 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (28, 2020015, N'19 June 2020 03:49:37 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (29, 2020017, N'19 June 2020 03:51:19 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (30, 2020017, N'19 June 2020 03:59:30 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (31, 2020019, N'19 June 2020 08:12:55 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (32, 2020020, N'19 June 2020 08:22:39 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (33, 2020015, N'19 June 2020 08:26:11 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (34, 2020015, N'19 June 2020 08:35:00 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (35, 2020015, N'19 June 2020 09:17:34 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (36, 2020015, N'19 June 2020 09:20:21 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (37, 2020020, N'19 June 2020 09:22:17 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (38, 2020020, N'19 June 2020 09:55:04 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (39, 2020020, N'19 June 2020 09:56:25 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (40, 2020020, N'19 June 2020 10:09:48 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (41, 2020020, N'19 June 2020 10:46:32 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (42, 2020020, N'19 June 2020 10:53:36 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (43, 2020020, N'19 June 2020 11:05:38 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (44, 2020020, N'19 June 2020 11:05:48 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (45, 2020020, N'19 June 2020 11:05:48 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (46, 2020020, N'19 June 2020 11:05:48 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (47, 2020020, N'19 June 2020 11:05:49 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (48, 2020020, N'19 June 2020 11:12:42 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (49, 2020020, N'19 June 2020 11:16:26 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (50, 2020020, N'19 June 2020 11:28:54 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (51, 2020020, N'19 June 2020 11:43:34 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (52, 2020020, N'20 June 2020 11:04:08 AM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (53, 2020020, N'20 June 2020 11:53:07 AM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (54, 2020020, N'20 June 2020 12:16:23 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (55, 2020020, N'20 June 2020 12:24:34 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (56, 2020020, N'20 June 2020 12:34:07 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (57, 2020020, N'20 June 2020 12:45:04 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (58, 2020020, N'20 June 2020 12:48:11 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (59, 2020020, N'20 June 2020 12:50:32 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (60, 2020019, N'20 June 2020 01:03:47 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (61, 2020020, N'20 June 2020 01:11:49 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (62, 2020015, N'20 June 2020 01:16:20 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (63, 2020020, N'20 June 2020 01:17:04 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (64, 2020020, N'21 June 2020 11:15:23 AM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (65, 2020020, N'21 June 2020 12:12:34 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (66, 2020020, N'21 June 2020 12:24:41 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (67, 2020020, N'21 June 2020 07:08:59 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (68, 2020020, N'21 June 2020 07:08:59 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (69, 2020020, N'21 June 2020 07:23:58 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (70, 2020020, N'21 June 2020 07:39:42 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (71, 2020020, N'21 June 2020 07:39:43 PM', NULL)
GO
INSERT [dbo].[SummeryDetails] ([LoginId], [UserId], [loginTime], [logoutTime]) VALUES (72, 2020020, N'21 June 2020 07:39:44 PM', NULL)
GO
SET IDENTITY_INSERT [dbo].[SummeryDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020003, N'Amit', N'ff', N'mm', N'9936301548', N'amit@avadh.in', N'Admin', N'', N'', N'01/07/1990', N'', N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020004, N'Amit Singh', N'ff', N'mm', N'9936301548', N'amit@gmail.com', N'Student', N'10', N'', N'07/02/2020', N'', N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020005, N'Ajay', N'FF', N'MM', N'9936301548', N'ajay@gmail.com', N'Teacher', N'', N'', N'07/05/2020', N'', N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020006, N'Ajay', N'FF', N'MM', N'9936301548', N'ajay@gmail.com', N'Teacher', N'', N'', N'07/05/2020', N'', N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020007, N'Ajay', N'FF', N'MM', N'9936301548', N'ajay@gmail.com', N'Teacher', N'', N'', N'07/05/2020', N'', N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020008, N'Amit Singh', N'ff', N'mm', N'9936301548', N'amit@gmail.com', N'Admin', NULL, NULL, N'07/07/2020', NULL, N'Active')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020009, N'Amit Singh', N'fffffffff', N'mmmmmmmmmmm', N'9936301548', N'amitSingh@gmail.com', N'Student', N'PreNur', NULL, N'07/07/2020', NULL, N'Deactivate')
GO
INSERT [dbo].[Users] ([RegId], [Name], [Father_Name], [Mother_Name], [Phone], [Email], [Role], [Class], [Address], [DOB], [LastSchool], [Status]) VALUES (2020010, N'Amit', N'fff', N'mm', N'9936301548', N'am@gmail.com', N'Student', N'2', NULL, N'07/07/2020', NULL, N'Active')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UsersLogin] ON 

GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (1, 2020003, N'123')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (2, 2020004, N'123')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (3, 2020005, N'123')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (4, 2020006, N'123')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (5, 2020007, N'123')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (6, 2020008, N'123456789')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (7, 2020009, N'123456789')
GO
INSERT [dbo].[UsersLogin] ([ID], [RegId], [Password]) VALUES (8, 2020010, N'123456789')
GO
SET IDENTITY_INSERT [dbo].[UsersLogin] OFF
GO
SET IDENTITY_INSERT [dbo].[VedioDetail] ON 

GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (1, N'physices', N'2', N'about lences', N'https://www.youtube.com/embed/tgbNymZ7vqY', N'3')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (2, N'maths', N'2', N'airthmatices', N'https://www.youtube.com/embed/tgbNymZ7vqY', N'3')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (3, N'english', N'2', N'transleation', N'www.youtube.com/embed/tgbNymZ7vqY', N'3')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (4, N'English', N'2', N'EnglishClass2', N'https://youtu.be/xHY-wV2WRxs', N'3')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (5, N'Add and subtract', N'2', N'add Ans subtract chapter NO1', N'https://youtu.be/1jCqMKdBE5c', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (6, N'science', N'2', N'multply for class 2 chapter2', N'https://youtu.be/ybTCQ6rCfqs', N'4')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (7, N'yesting', N'2', N'testing for class 2', N'https://youtu.be/ybTCQ6rCfqs', N'2')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (8, N'asdfasf', N'2', N'testing2', N'https://youtu.be/1jCqMKdBE5c', N'2')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (9, N'asdfasf', N'2', N'testing2', N'https://youtu.be/1jCqMKdBE5c', N'2')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (10, N'zdfsvxbxb', N'2', N'claabfjasgifuhgaksnclz', N'https://youtu.be/xHY-wV2WRxs', N'2')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (11, N'testing for pdf', N'2', N'testingof pdf', N'/Uploads/1926079242_PRIMARY (1).pdf', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (12, N'againtest', N'2', N'againtest', N'/Uploads/shaktimaan.pdf', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (13, N'afasfsaf', N'2', N'asfasf', N'/Uploads/test.pdf', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (14, N'', N'', N'', N'', N'')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (15, N'aaa', N'8', N'111', N'111', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (16, N'aa', N'7', N'qqq', N'qqq', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (17, N'test', N'2', N'test', N'/Content/PDF/aaa.jpg', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (18, N'test3', N'10', N'test3', N'test3', N'')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (19, N'test4', N'10', N'test4', N'test4', N'')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (20, N'test4', N'10', N'test4', N'test4', N'')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (21, N'test5', N'10', N'test5', N'test5', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (22, N'ABC', N'PreNur', N'13231', N'ABC.pdf', N'1')
GO
INSERT [dbo].[VedioDetail] ([vedioId], [vedioName], [vedioForClass], [VedioTittle], [vedioUrl], [Subject]) VALUES (23, N'ABCD', N'PreNur', N'ABCD', N'ABCD', N'1')
GO
SET IDENTITY_INSERT [dbo].[VedioDetail] OFF
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 08-07-2020 19:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Registration]
						@Name nvarchar(80),
						@Father_Name nvarchar(80),
						@Mother_Name nvarchar(80),
						@Phone varchar(10), 
						@Email varchar(80),
						@Role varchar(50),
						@Class varchar(50),
						@Address nvarchar(160),
						@DOB varchar(30),
						@LastSchool nvarchar(160),
						@Status varchar(30),
						@Password varchar(30)
AS
Begin
	Declare @ID int
	insert into  [SchoolErp].[dbo].[Users] ([Name],[Father_Name],[Mother_Name] ,[Phone],[Email],[Role],[Class],[Address],[DOB],[LastSchool],[Status]) 
	values (@Name,@Father_Name,@Mother_Name,@Phone, @Email,@Role,@Class,@Address,@DOB,@LastSchool,@Status);
	--select @ID = SCOPE_IDENTITY()
    insert into  [SchoolErp].[dbo].[UsersLogin] ([RegId],[Password]) values(SCOPE_IDENTITY(),@Password);
    Select 1 StatusCode,'Register successfully' Status
End
GO
USE [master]
GO
ALTER DATABASE [SchoolErp] SET  READ_WRITE 
GO
