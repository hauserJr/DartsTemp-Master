USE [DartTemp]
GO
/****** Object:  Table [dbo].[SysAccount]    Script Date: 2018/7/24 下午 11:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserAccount] [nvarchar](50) NULL,
	[UserPwd] [nvarchar](50) NULL,
 CONSTRAINT [PK_SysAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp]    Script Date: 2018/7/24 下午 11:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TempA] [nvarchar](50) NULL,
	[TempB] [nvarchar](50) NULL,
 CONSTRAINT [PK_Temp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
