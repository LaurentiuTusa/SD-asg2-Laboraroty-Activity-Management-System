USE [SD_asg2]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 12/04/2023 00:04:37  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lab_id] [int] NOT NULL,
	[student_id] [int] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labs]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject_id] [int] NOT NULL,
	[number] [int] NOT NULL,
	[date] [date] NOT NULL,
	[title] [varchar](20) NOT NULL,
	[curricula] [varchar](30) NOT NULL,
	[description] [varchar](60) NOT NULL,
	[asg_name] [varchar](30) NULL,
	[asd_dl] [date] NULL,
	[asg_description] [varchar](60) NULL,
 CONSTRAINT [PK_Labs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[group] [varchar](10) NOT NULL,
	[hobby] [varchar](40) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [varchar](30) NOT NULL,
	[teacher_id] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submisions]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submisions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[lab_id] [int] NOT NULL,
	[link] [varchar](50) NOT NULL,
	[comment] [varchar](30) NULL,
	[grade] [int] NULL,
 CONSTRAINT [PK_Submisions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[password] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 12/04/2023 00:04:38  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] [varchar](180) NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON 

INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (2, 4, 1)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (3, 4, 2)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (4, 4, 3)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (5, 2, 1)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (6, 2, 2)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (7, 2, 3)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (8, 3, 2)
INSERT [dbo].[Attendance] ([id], [lab_id], [student_id]) VALUES (10, 4, 4)
SET IDENTITY_INSERT [dbo].[Attendance] OFF
GO
SET IDENTITY_INSERT [dbo].[Labs] ON 

INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (2, 1, 1, CAST(N'2023-04-09' AS Date), N'Lab 1', N'Software Design', N'Introduction to UML', NULL, NULL, NULL)
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (3, 1, 2, CAST(N'2023-04-16' AS Date), N'Lab 2', N'Software Design', N'Use Cases and Scenarios', N'Assignment 1', CAST(N'2023-04-19' AS Date), N'Implement a UML Use Case Diagram')
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (4, 1, 3, CAST(N'2023-04-23' AS Date), N'Lab 3', N'Software Design', N'Class Diagrams', NULL, NULL, NULL)
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (5, 1, 4, CAST(N'2023-04-30' AS Date), N'Lab 4', N'Software Design', N'Object Diagrams', NULL, NULL, NULL)
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (6, 1, 5, CAST(N'2023-05-07' AS Date), N'Lab 5', N'Software Design', N'State Diagrams', N'Assignment 2', CAST(N'2023-05-09' AS Date), N'Implement a UML State Diagram')
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (7, 1, 6, CAST(N'2023-05-14' AS Date), N'Lab 6', N'Software Design', N'Activity Diagrams', NULL, NULL, NULL)
INSERT [dbo].[Labs] ([id], [subject_id], [number], [date], [title], [curricula], [description], [asg_name], [asd_dl], [asg_description]) VALUES (15, 1, 7, CAST(N'2023-05-19' AS Date), N'Lab 7', N'Software Design', N'MVC Design Pattern', N'Go climb some', CAST(N'0001-01-01' AS Date), N'Complete at least 5 problems')
SET IDENTITY_INSERT [dbo].[Labs] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([id], [name], [email], [password], [group], [hobby]) VALUES (1, N'Marin Sorin', N'mainsorin@yahoo.com', N'bXM=', N'30431', N'gym')
INSERT [dbo].[Student] ([id], [name], [email], [password], [group], [hobby]) VALUES (2, N'Alexandra Sicobean', N'alesicobean@yahoo.com', N'YWxl', N'30431', N'inot, ski')
INSERT [dbo].[Student] ([id], [name], [email], [password], [group], [hobby]) VALUES (3, N'Mihai Petre', N'mihaip@yahoo.com', N'bWloYWk=', N'30432', N'curse de masini')
INSERT [dbo].[Student] ([id], [name], [email], [password], [group], [hobby]) VALUES (4, N'Alex Honold', N'alexhonold@yahoo.com', N'YWxleA==', N'30431', N'climbing, free solo')
INSERT [dbo].[Student] ([id], [name], [email], [password], [group], [hobby]) VALUES (5, N'Lazy', N'qwe@yahoo.com', N'cXdl', N'30421', N'trad climbing')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([id], [subject], [teacher_id]) VALUES (1, N'Software Design', 1)
INSERT [dbo].[Subjects] ([id], [subject], [teacher_id]) VALUES (2, N'Climbing Technics', 2)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Submisions] ON 

INSERT [dbo].[Submisions] ([id], [student_id], [lab_id], [link], [comment], [grade]) VALUES (1, 2, 2, N'www.github.GoClimbNow', N'Take me to Skai', 10)
INSERT [dbo].[Submisions] ([id], [student_id], [lab_id], [link], [comment], [grade]) VALUES (2, 2, 15, N'www.github.GoClimbNow', N'I did it', 10)
INSERT [dbo].[Submisions] ([id], [student_id], [lab_id], [link], [comment], [grade]) VALUES (3, 2, 6, N'www.github.GoClimbNow', N'Time for a swim', 10)
INSERT [dbo].[Submisions] ([id], [student_id], [lab_id], [link], [comment], [grade]) VALUES (4, 4, 15, N'www.github.AlexHonold', N'Free Solo El Capitan', 10)
SET IDENTITY_INSERT [dbo].[Submisions] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([id], [name], [email], [password]) VALUES (1, N'Laurentiu Tusa', N'lautusa@yahoo.com', N'bGF1')
INSERT [dbo].[Teacher] ([id], [name], [email], [password]) VALUES (2, N'Alex Daniel', N'abc@yahoo.com', N'YWJj')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Tokens] ON 

INSERT [dbo].[Tokens] ([id], [token]) VALUES (3, N'FHDgOlvc8zYmlenVcdBWkFaIEJhb9WusOI/vymZZfOfurL32ly+4HnhseX925q/kqTGCH3Uyrx+WQE2ykxgxAjVIsN0PbTfbGJT0+DIHlvWW2flq1HgpEHd5LiXk72u4rPxLt8JU/EgmwDrrxGNyAa9QKLRNwzZa+LXQMvswT0k=')
SET IDENTITY_INSERT [dbo].[Tokens] OFF
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Labs] FOREIGN KEY([lab_id])
REFERENCES [dbo].[Labs] ([id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Labs]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Student] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Student]
GO
ALTER TABLE [dbo].[Labs]  WITH CHECK ADD  CONSTRAINT [FK_Labs_Subjects] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([id])
GO
ALTER TABLE [dbo].[Labs] CHECK CONSTRAINT [FK_Labs_Subjects]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Teacher]
GO
ALTER TABLE [dbo].[Submisions]  WITH CHECK ADD  CONSTRAINT [FK_Submisions_Labs] FOREIGN KEY([lab_id])
REFERENCES [dbo].[Labs] ([id])
GO
ALTER TABLE [dbo].[Submisions] CHECK CONSTRAINT [FK_Submisions_Labs]
GO
ALTER TABLE [dbo].[Submisions]  WITH CHECK ADD  CONSTRAINT [FK_Submisions_Student] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Submisions] CHECK CONSTRAINT [FK_Submisions_Student]
GO
