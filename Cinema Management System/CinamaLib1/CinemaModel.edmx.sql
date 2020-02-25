
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2020 20:35:55
-- Generated from EDMX file: C:\Users\I2CM Developer\Desktop\Cinema - BackUp13-mit User\Cinema\CinamaLib1\CinemaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MovieScheduleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleItems] DROP CONSTRAINT [FK_MovieScheduleItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleItemTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_ScheduleItemTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMovie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movies] DROP CONSTRAINT [FK_UserMovie];
GO
IF OBJECT_ID(N'[dbo].[FK_UserScheduleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleItems] DROP CONSTRAINT [FK_UserScheduleItem];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_UserTicket];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[ScheduleItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleItems];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[Seats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seats];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Director] nvarchar(max)  NULL,
    [Actor] nvarchar(max)  NULL,
    [MovieType] nvarchar(max)  NULL,
    [Poster] nvarchar(max)  NULL,
    [FullPrice] float  NOT NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'ScheduleItems'
CREATE TABLE [dbo].[ScheduleItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Time] datetime  NOT NULL,
    [MovieItemId] int  NOT NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL,
    [TicketType] nvarchar(max)  NOT NULL,
    [Discount] float  NULL,
    [Coupon] nvarchar(max)  NULL,
    [ScheduleItemId] int  NOT NULL,
    [SeatItemId] int  NOT NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'Seats'
CREATE TABLE [dbo].[Seats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SeatNum] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [EmployeeNum] nvarchar(max)  NULL,
    [IsAdmin] bit  NOT NULL,
    [Telefon] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduleItems'
ALTER TABLE [dbo].[ScheduleItems]
ADD CONSTRAINT [PK_ScheduleItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Seats'
ALTER TABLE [dbo].[Seats]
ADD CONSTRAINT [PK_Seats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MovieItemId] in table 'ScheduleItems'
ALTER TABLE [dbo].[ScheduleItems]
ADD CONSTRAINT [FK_MovieScheduleItem]
    FOREIGN KEY ([MovieItemId])
    REFERENCES [dbo].[Movies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieScheduleItem'
CREATE INDEX [IX_FK_MovieScheduleItem]
ON [dbo].[ScheduleItems]
    ([MovieItemId]);
GO

-- Creating foreign key on [ScheduleItemId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_ScheduleItemTicket]
    FOREIGN KEY ([ScheduleItemId])
    REFERENCES [dbo].[ScheduleItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleItemTicket'
CREATE INDEX [IX_FK_ScheduleItemTicket]
ON [dbo].[Tickets]
    ([ScheduleItemId]);
GO

-- Creating foreign key on [SeatItemId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketSeat]
    FOREIGN KEY ([SeatItemId])
    REFERENCES [dbo].[Seats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketSeat'
CREATE INDEX [IX_FK_TicketSeat]
ON [dbo].[Tickets]
    ([SeatItemId]);
GO

-- Creating foreign key on [UserId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [FK_UserMovie]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMovie'
CREATE INDEX [IX_FK_UserMovie]
ON [dbo].[Movies]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ScheduleItems'
ALTER TABLE [dbo].[ScheduleItems]
ADD CONSTRAINT [FK_UserScheduleItem]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserScheduleItem'
CREATE INDEX [IX_FK_UserScheduleItem]
ON [dbo].[ScheduleItems]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_UserTicket]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket'
CREATE INDEX [IX_FK_UserTicket]
ON [dbo].[Tickets]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------