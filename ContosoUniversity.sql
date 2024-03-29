USE [ContosoUniversity]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/06/2013 16:49:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[EnrollmentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [EnrollmentDate]) VALUES (1, N'Tibbetts', N'Donnie', CAST(0x0000A22C00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [EnrollmentDate]) VALUES (2, N'Guzman', N'Liza', CAST(0x00009FD700000000 AS DateTime))
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [EnrollmentDate]) VALUES (3, N'Catlett', N'Phil', CAST(0x00009F5300000000 AS DateTime))
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [EnrollmentDate]) VALUES (4, N'Palma', N'Ricardo', CAST(0x00006FC500000000 AS DateTime))
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [EnrollmentDate]) VALUES (5, N'Bolivar', N'Simon', CAST(0x00006A3200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[Course]    Script Date: 12/06/2013 16:49:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Credits] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([CourseID], [Title], [Credits]) VALUES (1, N'Economics', 3)
INSERT [dbo].[Course] ([CourseID], [Title], [Credits]) VALUES (2, N'Literature', 3)
INSERT [dbo].[Course] ([CourseID], [Title], [Credits]) VALUES (3, N'Chemistry', 4)
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  StoredProcedure [dbo].[uspListarEstudiante]    Script Date: 12/06/2013 16:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspListarEstudiante]
AS
BEGIN
	SELECT a.StudentID, a.LastName, a.FirstName, CONVERT(VARCHAR(10), a.EnrollmentDate, 103) AS EnrollmentDate FROM dbo.Student a (NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[uspInsertarEstudiante]    Script Date: 12/06/2013 16:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertarEstudiante]
@LastName			NVARCHAR(50),
@FirstName			NVARCHAR(50),
@EnrollmentDate		VARCHAR(8),
@StudentID			INT OUTPUT
AS
BEGIN
	INSERT INTO dbo.Student(LastName, FirstName, EnrollmentDate)
	VALUES(@LastName, @FirstName, @EnrollmentDate)

	SET @StudentID = @@IDENTITY
END
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 12/06/2013 16:49:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [decimal](3, 2) NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (1, CAST(2.00 AS Decimal(3, 2)), 1, 1)
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (2, CAST(3.50 AS Decimal(3, 2)), 1, 2)
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (3, CAST(4.00 AS Decimal(3, 2)), 2, 3)
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (4, CAST(1.80 AS Decimal(3, 2)), 2, 1)
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (5, CAST(3.20 AS Decimal(3, 2)), 3, 1)
INSERT [dbo].[Enrollment] ([EnrollmentID], [Grade], [CourseID], [StudentID]) VALUES (6, CAST(4.00 AS Decimal(3, 2)), 3, 2)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
/****** Object:  ForeignKey [FK_dbo.Enrollment_dbo.Course_CourseID]    Script Date: 12/06/2013 16:49:37 ******/
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID]
GO
/****** Object:  ForeignKey [FK_dbo.Enrollment_dbo.Student_StudentID]    Script Date: 12/06/2013 16:49:37 ******/
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Student_StudentID]
GO
