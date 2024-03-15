CREATE TABLE [dbo].[User] (
    [UserId]    INT          IDENTITY (1, 1) NOT NULL,
    [UserEmail] VARCHAR (50) NOT NULL,
    [UserPass]  VARCHAR (50) NOT NULL,
    [UserName]  VARCHAR (50) NOT NULL,
    [UserType]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);



CREATE TABLE [dbo].[Customer] (
    [UserId]   INT      NOT NULL,
    [Reg_Date] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


CREATE TABLE [dbo].[Admin] (
    [UserId]  INT          NOT NULL,
    [Surname] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

CREATE TABLE [dbo].[Address] (
    [AddressId]    INT           IDENTITY (1, 1) NOT NULL,
    [AddressLine1] VARCHAR (MAX) NOT NULL,
    [AddressLine2] VARCHAR (MAX) NULL,
    [City]         VARCHAR (100) NOT NULL,
    [Province]     VARCHAR (50)  NOT NULL,
    [PostalCode]   VARCHAR (4)   NOT NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC)
);

CREATE TABLE [dbo].[Cust_addr] (
    [UserId]    INT NOT NULL,
    [AddressId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [AddressId] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Customer] ([UserId])
);

CREATE TABLE [dbo].[Brand] (
    [BrandId]   INT          IDENTITY (1, 1) NOT NULL,
    [BrandName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Category] (
    [CategoryId]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

CREATE TABLE [dbo].[Product] (
    [ProductId]  INT           IDENTITY (1, 1) NOT NULL,
    [ProName]    VARCHAR (50)  NOT NULL,
    [ProPrice]   MONEY         NOT NULL,
    [ProDescr]   VARCHAR (MAX) NOT NULL,
    [CategoryId] INT           NOT NULL,
    [BrandId]    INT           NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([BrandId])
);

CREATE TABLE [dbo].[InvoiceLine] (
    [InvoiceId] INT IDENTITY (1, 1) NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    [VAT]       INT NOT NULL,
    [Discount]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

CREATE TABLE [dbo].[Invoice] (
    [InvoiceId] INT   NOT NULL,
    [UserId]    INT   NOT NULL,
    [Total]     MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC, [UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Customer] ([UserId]),
    FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[InvoiceLine] ([InvoiceId])
);