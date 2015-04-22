USE [KonnectNow]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Cat_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cat_Name] [nvarchar](50) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Cat_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([Cat_Id], [Cat_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(1 AS Numeric(18, 0)), N'Mobile & Accesories', 1, CAST(0x0000A47000EB98E7 AS DateTime), CAST(0x0000A47000EB98E7 AS DateTime))
INSERT [dbo].[Category] ([Cat_Id], [Cat_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(2 AS Numeric(18, 0)), N'Movies', 1, CAST(0x0000A47000EBC8A4 AS DateTime), CAST(0x0000A47000EBC8A4 AS DateTime))
INSERT [dbo].[Category] ([Cat_Id], [Cat_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(3 AS Numeric(18, 0)), N'News', 1, CAST(0x0000A47000EBED54 AS DateTime), CAST(0x0000A47000EBED54 AS DateTime))
INSERT [dbo].[Category] ([Cat_Id], [Cat_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(9 AS Numeric(18, 0)), N'Test1', 1, CAST(0x0000A476001CDEA5 AS DateTime), CAST(0x0000A476001CDEA5 AS DateTime))
INSERT [dbo].[Category] ([Cat_Id], [Cat_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(11 AS Numeric(18, 0)), N'Test2', 1, CAST(0x0000A476001E38B5 AS DateTime), CAST(0x0000A476001E38B5 AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Logs]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Country_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Country_Name] [varchar](50) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Country_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON
INSERT [dbo].[Country] ([Country_Id], [Country_Name], [Is_Active], [Created_On], [Modified_On]) VALUES (CAST(1 AS Numeric(18, 0)), N'India', 1, CAST(0x0000A47D00032CBE AS DateTime), CAST(0x0000A47D00032CBE AS DateTime))
SET IDENTITY_INSERT [dbo].[Country] OFF
/****** Object:  Table [dbo].[Validation]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Validation](
	[Validation_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Mobile_No] [varchar](20) NOT NULL,
	[Validation_Code] [nvarchar](10) NOT NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Validation_Code] PRIMARY KEY CLUSTERED 
(
	[Validation_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Validation] ON
INSERT [dbo].[Validation] ([Validation_Id], [Mobile_No], [Validation_Code], [Start_Date], [End_Date]) VALUES (CAST(1 AS Numeric(18, 0)), N'9912064674', N'747827', CAST(0x0000A47D0026FB60 AS DateTime), CAST(0x0000A47E0026FB90 AS DateTime))
SET IDENTITY_INSERT [dbo].[Validation] OFF
/****** Object:  Table [dbo].[User]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[User_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[Mobile_No] [varchar](20) NOT NULL,
	[Device_Id] [varchar](100) NOT NULL,
	[Country_Id] [numeric](18, 0) NOT NULL,
	[Profile_Pic] [varbinary](max) NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([User_Id], [First_Name], [Last_Name], [Mobile_No], [Device_Id], [Country_Id], [Profile_Pic], [Created_On], [Modified_On], [Longitude], [Latitude]) VALUES (CAST(8 AS Numeric(18, 0)), N'Venkat Ramana', N'Naredla', N'9912064674', N'abcd1234', CAST(1 AS Numeric(18, 0)), 0x4040, CAST(0x0000A47D001801FB AS DateTime), CAST(0x0000A47D001801FB AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[State]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[State_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[State_Name] [varchar](50) NOT NULL,
	[Country_Id] [numeric](18, 0) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[State_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seller](
	[Company_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Company_Name] [nvarchar](100) NOT NULL,
	[User_Id] [numeric](18, 0) NOT NULL,
	[Phone_Number] [nvarchar](20) NOT NULL,
	[Email_Id] [nvarchar](250) NOT NULL,
	[Website_Url] [nvarchar](50) NULL,
	[Location_Point] [nvarchar](150) NULL,
	[PanCard_No] [varchar](15) NULL,
	[Description] [nvarchar](250) NULL,
	[Auto_Reponse] [nvarchar](250) NULL,
	[Response_Status] [bit] NULL,
	[Key_Words] [nvarchar](500) NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Company_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Seller] ON
INSERT [dbo].[Seller] ([Company_Id], [Company_Name], [User_Id], [Phone_Number], [Email_Id], [Website_Url], [Location_Point], [PanCard_No], [Description], [Auto_Reponse], [Response_Status], [Key_Words], [Created_On], [Modified_On]) VALUES (CAST(1 AS Numeric(18, 0)), N'sample string 1', CAST(8 AS Numeric(18, 0)), N'9912064674', N'abc@gmail.com', N'sample string 4', N'sample string 5', N'sample string 6', N'sample string 7', N'sample string 8', 1, N'sample string 10', CAST(0x0000A47E002F2AE7 AS DateTime), CAST(0x0000A47E002F2AE7 AS DateTime))
SET IDENTITY_INSERT [dbo].[Seller] OFF
/****** Object:  Table [dbo].[City]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[City_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[City_Name] [varchar](50) NOT NULL,
	[State_Id] [numeric](18, 0) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[City_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Location_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Location_Name] [varchar](150) NOT NULL,
	[City_Id] [numeric](18, 0) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Location_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Query]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Query](
	[Query_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[User_Id] [numeric](18, 0) NOT NULL,
	[Query_Text] [ntext] NOT NULL,
	[Location_Id] [numeric](18, 0) NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Updated_On] [datetime] NOT NULL,
	[Cat_Id] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[Query_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 04/18/2015 15:03:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Message_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Query_Id] [numeric](18, 0) NOT NULL,
	[From_User_Id] [numeric](18, 0) NOT NULL,
	[To_User_Id] [numeric](18, 0) NOT NULL,
	[Message] [ntext] NOT NULL,
	[Is_Read] [bit] NOT NULL,
	[Sent_On] [datetime] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Message_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_Category_Is_Active]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  Default [DF_Category_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_Category_Modified_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Modified_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_Logs_Date]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_Country_Is_Active]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  Default [DF_Country_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_Country_Modified_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Modified_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_User_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_User_Updated_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Updated_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [Constraint_Longitude]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [Constraint_Longitude]  DEFAULT ((0)) FOR [Longitude]
GO
/****** Object:  Default [Constraint_Latitude]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [Constraint_Latitude]  DEFAULT ((0)) FOR [Latitude]
GO
/****** Object:  Default [DF_State_Is_Active]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  Default [DF_State_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_State_Modified_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Modified_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_Seller_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_Table_1_Updated_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Table_1_Updated_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_City_Is_Active]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  Default [DF_City_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_City_Modified_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Modified_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_Location_Is_Active]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  Default [DF_Location_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_Location_Modified_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Modified_On]  DEFAULT (getdate()) FOR [Modified_On]
GO
/****** Object:  Default [DF_Query_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Query] ADD  CONSTRAINT [DF_Query_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
/****** Object:  Default [DF_Query_Updated_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Query] ADD  CONSTRAINT [DF_Query_Updated_On]  DEFAULT (getdate()) FOR [Updated_On]
GO
/****** Object:  Default [DF_Message_Is_Read]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_Is_Read]  DEFAULT ((1)) FOR [Is_Read]
GO
/****** Object:  Default [DF_Message_Created_On]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_Created_On]  DEFAULT (getdate()) FOR [Sent_On]
GO
/****** Object:  ForeignKey [USER_COUNTRY_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [USER_COUNTRY_FK] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Country_Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [USER_COUNTRY_FK]
GO
/****** Object:  ForeignKey [STATE_COUNTRY_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [STATE_COUNTRY_FK] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Country_Id])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [STATE_COUNTRY_FK]
GO
/****** Object:  ForeignKey [Seller_User_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Seller]  WITH CHECK ADD  CONSTRAINT [Seller_User_FK] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([User_Id])
GO
ALTER TABLE [dbo].[Seller] CHECK CONSTRAINT [Seller_User_FK]
GO
/****** Object:  ForeignKey [CITY_STATE_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [CITY_STATE_FK] FOREIGN KEY([State_Id])
REFERENCES [dbo].[State] ([State_Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [CITY_STATE_FK]
GO
/****** Object:  ForeignKey [LOCATION_CITY_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [LOCATION_CITY_FK] FOREIGN KEY([City_Id])
REFERENCES [dbo].[City] ([City_Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [LOCATION_CITY_FK]
GO
/****** Object:  ForeignKey [QUERY_CATEGORY_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Query]  WITH CHECK ADD  CONSTRAINT [QUERY_CATEGORY_FK] FOREIGN KEY([Cat_Id])
REFERENCES [dbo].[Category] ([Cat_Id])
GO
ALTER TABLE [dbo].[Query] CHECK CONSTRAINT [QUERY_CATEGORY_FK]
GO
/****** Object:  ForeignKey [QUERY_LOCATION_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Query]  WITH CHECK ADD  CONSTRAINT [QUERY_LOCATION_FK] FOREIGN KEY([Location_Id])
REFERENCES [dbo].[Location] ([Location_Id])
GO
ALTER TABLE [dbo].[Query] CHECK CONSTRAINT [QUERY_LOCATION_FK]
GO
/****** Object:  ForeignKey [QUERY_USER_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Query]  WITH CHECK ADD  CONSTRAINT [QUERY_USER_FK] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([User_Id])
GO
ALTER TABLE [dbo].[Query] CHECK CONSTRAINT [QUERY_USER_FK]
GO
/****** Object:  ForeignKey [MESSAGE_QUERY_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [MESSAGE_QUERY_FK] FOREIGN KEY([Query_Id])
REFERENCES [dbo].[Query] ([Query_Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [MESSAGE_QUERY_FK]
GO
/****** Object:  ForeignKey [MESSAGE_TOUSER_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [MESSAGE_TOUSER_FK] FOREIGN KEY([To_User_Id])
REFERENCES [dbo].[User] ([User_Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [MESSAGE_TOUSER_FK]
GO
/****** Object:  ForeignKey [MESSAGE_USER_FK]    Script Date: 04/18/2015 15:03:16 ******/
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [MESSAGE_USER_FK] FOREIGN KEY([From_User_Id])
REFERENCES [dbo].[User] ([User_Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [MESSAGE_USER_FK]
GO
----------------------------------------------------------------------------------------------------------------------------------------------

/****** New scripts ******/

ALTER TABLE LOCATION ADD Longitude float not null,Latitude float not null
GO

ALTER TABLE [dbo].[LOCATION] ADD  CONSTRAINT [Constraint_Location_Longitude]  DEFAULT ((0)) FOR [Longitude]
GO

ALTER TABLE [dbo].[LOCATION] ADD  CONSTRAINT [Constraint_Location_Latitude]  DEFAULT ((0)) FOR [Latitude]
GO