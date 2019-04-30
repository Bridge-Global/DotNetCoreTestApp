
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestDetails]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestDetails](
	[SlNo] [bigint] IDENTITY(1,1) NOT NULL,
	[AthleteId] [nvarchar](450) NULL,
	[DistanceOrTime] [real] NOT NULL,
	[TestHeaderId] [int] NOT NULL,
 CONSTRAINT [PK_TestDetails] PRIMARY KEY CLUSTERED 
(
	[SlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestHeaders]    Script Date: 30-04-2019 07:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestHeaders](
	[TestHeaderId] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [datetime2](7) NOT NULL,
	[TestType] [int] NOT NULL,
 CONSTRAINT [PK_TestHeaders] PRIMARY KEY CLUSTERED 
(
	[TestHeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'365f3d95-ee4e-4456-9ae5-674b65b02512', N'Athlete', N'ATHLETE', N'b4deb4d9-acef-4879-91e1-3cc10e9bc58c')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'365f3d95-ee4e-4456-9ae5-674b65b32356', N'Coach', N'COACH', N'b4deb4d9-acef-1279-91e1-8cc19e9bc62v')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02f60c9f-338e-4198-a7ea-7e86522d0dec', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c50088c17eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c50088c86eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c80023c51eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c80088c51eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c81223c51eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c81223c65eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c84423c65eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c84423c78eaa', N'365f3d95-ee4e-4456-9ae5-674b65b02512')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f729e56b-59e7-47d3-b162-a90a78a36d84', N'365f3d95-ee4e-4456-9ae5-674b65b32356')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'02f60c9f-338e-4198-a7ea-7e86522d0dec', N'DELICIA.LEDONNE@coachathlete.com', N'DELICIA.LEDONNE@COACHATHLETE.COM', N'DELICIA.LEDONNE@coachathlete.com', N'DELICIA.LEDONNE@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEGnDF3issbKzz1Vmb/yG5VmsEEe/ucIsoG8hbE+ApFd5wFAEhDhqQctopw1tjyKO1w==', N'AWLA3NBE5NIQJFCQF7XZ3XZXHGQEXXML', N'd9cc2307-1495-4648-b514-83463e4c66b2', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c50088c17eaa', N'MAGEN.FAYE@coachathlete.com', N'MAGEN.FAYE@COACHATHLETE.COM', N'MAGEN.FAYE@coachathlete.com', N'MAGEN.FAYE@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c50088c86eaa', N'QUEEN.JACOBI@coachathlete.com', N'QUEEN.JACOBI@COACHATHLETE.COM', N'QUEEN.JACOBI@coachathlete.com', N'QUEEN.JACOBI@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c80023c51eaa', N'MARC.VOTH@coachathlete.com', N'MARC.VOTH@COACHATHLETE.COM', N'MARC.VOTH@coachathlete.com', N'MARC.VOTH@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c80088c51eaa', N'CAMILLE.GRANTHAM@coachathlete.com', N'CAMILLE.GRANTHAM@COACHATHLETE.COM', N'CAMILLE.GRANTHAM@coachathlete.com', N'CAMILLE.GRANTHAM@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c81223c51eaa', N'RANDY.RONDON@coachathlete.com', N'RANDY.RONDON@COACHATHLETE.COM', N'RANDY.RONDON@coachathlete.com', N'RANDY.RONDON@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c81223c65eaa', N'DELORA.SAVILLE@coachathlete.com', N'DELORA.SAVILLE@COACHATHLETE.COM', N'DELORA.SAVILLE@coachathlete.com', N'DELORA.SAVILLE@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c84423c65eaa', N'ROSARIO.REUBEN@coachathlete.com', N'ROSARIO.REUBEN@COACHATHLETE.COM', N'ROSARIO.REUBEN@coachathlete.com', N'ROSARIO.REUBEN@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c2d09ce7-8cb1-4a2a-8767-c84423c78eaa', N'LULA.UHLMAN@coachathlete.com', N'LULA.UHLMAN@COACHATHLETE.COM', N'LULA.UHLMAN@coachathlete.com', N'LULA.UHLMAN@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEF3MGilJhM4B++kUrL3TM3BrYWJ3nYyrwQGX8O9nRn/sNVdxxarlcsWxvbl7eebnAQ==', N'3ZZBT5ZUNJGS62U2LQ6WXBDAETZXBFWN', N'4c362ac8-48fe-4772-880e-b25b52dc007e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f729e56b-59e7-47d3-b162-a90a78a36d84', N'MITCHEL.FAUSTO@coachathlete.com', N'MITCHEL.FAUSTO@COACHATHLETE.COM', N'MITCHEL.FAUSTO@coachathlete.com', N'MITCHEL.FAUSTO@COACHATHLETE.COM', 0, N'AQAAAAEAACcQAAAAEJ7fBIprIv+GboSUBAOo5zO+fw++U6Rv+gTHLiW/5Fj2uZDPWE7RJ/MiZ3xF2kPYUA==', N'SY53TTT6MFNM5AY4PSFV5EG527IBIVZ2', N'7c5daabb-d253-4ec8-8165-33fb3a369e22', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[TestDetails] ON 
GO
INSERT [dbo].[TestDetails] ([SlNo], [AthleteId], [DistanceOrTime], [TestHeaderId]) VALUES (1, NULL, 12, 2)
GO
INSERT [dbo].[TestDetails] ([SlNo], [AthleteId], [DistanceOrTime], [TestHeaderId]) VALUES (2, NULL, 11, 2)
GO
INSERT [dbo].[TestDetails] ([SlNo], [AthleteId], [DistanceOrTime], [TestHeaderId]) VALUES (3, NULL, 12, 2)
GO
SET IDENTITY_INSERT [dbo].[TestDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TestHeaders] ON 
GO
INSERT [dbo].[TestHeaders] ([TestHeaderId], [TestDate], [TestType]) VALUES (2, CAST(N'2019-04-06T10:01:00.0000000' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[TestHeaders] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[TestDetails]  WITH CHECK ADD  CONSTRAINT [FK_TestDetails_AspNetUsers_AthleteId] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[TestDetails] CHECK CONSTRAINT [FK_TestDetails_AspNetUsers_AthleteId]
GO
ALTER TABLE [dbo].[TestDetails]  WITH CHECK ADD  CONSTRAINT [FK_TestDetails_TestHeaders_TestHeaderId] FOREIGN KEY([TestHeaderId])
REFERENCES [dbo].[TestHeaders] ([TestHeaderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestDetails] CHECK CONSTRAINT [FK_TestDetails_TestHeaders_TestHeaderId]
GO
