CREATE TABLE [dbo].[CustomerProfile] (
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [FirstName]  NVARCHAR (100)   NOT NULL,
    [LastName]   NVARCHAR (100)   NOT NULL,
    [Email]      NVARCHAR (255)   NOT NULL,
    [JoinDate]   DATE             NOT NULL,
    [StoreRefId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);


GO

