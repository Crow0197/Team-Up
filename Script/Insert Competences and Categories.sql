GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [Typology], [Color]) VALUES (1, N'Arte', N'primary')
GO
INSERT [dbo].[Categories] ([CategoryID], [Typology], [Color]) VALUES (2, N'Tecnino', N'secondary')
GO
INSERT [dbo].[Categories] ([CategoryID], [Typology], [Color]) VALUES (3, N'Musica', N'success')
GO
INSERT [dbo].[Categories] ([CategoryID], [Typology], [Color]) VALUES (4, N'Informatica', N'danger')
GO
INSERT [dbo].[Categories] ([CategoryID], [Typology], [Color]) VALUES (5, N'Storia', N'warning')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Competences] ON 
GO
INSERT [dbo].[Competences] ([CompetenceID], [typology], [Color]) VALUES (1, N'Compositore', N'primary')
GO
INSERT [dbo].[Competences] ([CompetenceID], [typology], [Color]) VALUES (2, N'Competene IT', N'warning')
GO
INSERT [dbo].[Competences] ([CompetenceID], [typology], [Color]) VALUES (3, N'Disegno Tecnino', N'danger')
GO
INSERT [dbo].[Competences] ([CompetenceID], [typology], [Color]) VALUES (4, N'Disegno', N'success')
GO
INSERT [dbo].[Competences] ([CompetenceID], [typology], [Color]) VALUES (5, N'Programmazione', N'secondary')
GO
SET IDENTITY_INSERT [dbo].[Competences] OFF
GO
