CREATE TABLE [dbo].[Reports](
	[RDOCID] [int] IDENTITY(1,1) NOT NULL,
	[RptName] [nvarchar](100)  NULL ,
	[Rpt_Byte_Array] [NVARCHAR](max) NULL,
	[Create_date] [datetime] NOT NULL,
	[Update_date] [datetime]  NULL,
	[DB_Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[RDOCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

