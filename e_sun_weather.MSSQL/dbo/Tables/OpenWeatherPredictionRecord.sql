CREATE TABLE [dbo].[OpenWeatherPredictionRecord](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ResourceID] [nvarchar](20) NOT NULL,
	[DataDescription] [nvarchar](30) NOT NULL,
	[Location] [int] NOT NULL,
	[Element] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[ParameterName] [nvarchar](20) NULL,
	[ParameterValue] [nvarchar](20) NULL,
	[ParameterUnit] [nvarchar](10) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK__Table__3214EC274C0C250D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


GO
CREATE NONCLUSTERED INDEX [IX_ResourceID]
    ON [dbo].[OpenWeatherPredictionRecord]([ResourceID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreateTime_EndTime]
    ON [dbo].[OpenWeatherPredictionRecord]([StartTime] ASC, [EndTime] ASC);

