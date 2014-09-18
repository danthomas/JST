CREATE TABLE [Logging].[Exception]
(
  [ExceptionId] INT NOT NULL IDENTITY (1, 1)
, [Message] VARCHAR(MAX) NOT NULL
, [StackTrace] VARCHAR(MAX) NOT NULL
, [DateTime] DATETIME NOT NULL
, CONSTRAINT PK_Exception PRIMARY KEY CLUSTERED ( [ExceptionId] )
)
