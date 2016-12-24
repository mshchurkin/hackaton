
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/01/2016 12:19:54
-- Generated from EDMX file: \\mac\Home\Documents\Visual Studio 2013\Projects\hackaton\hackaton\Shipments.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Shipments];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CargoCargoAttribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CargoAttributeSet] DROP CONSTRAINT [FK_CargoCargoAttribute];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCargo_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCargo] DROP CONSTRAINT [FK_UserCargo_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCargo] DROP CONSTRAINT [FK_UserCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_CargoTransport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CargoSet] DROP CONSTRAINT [FK_CargoTransport];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CargoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CargoSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[TransportSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransportSet];
GO
IF OBJECT_ID(N'[dbo].[CargoAttributeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CargoAttributeSet];
GO
IF OBJECT_ID(N'[dbo].[UserCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCargo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CargoSet'
CREATE TABLE [dbo].[CargoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GeoLat] float  NOT NULL,
    [GeoLong] float  NOT NULL,
    [Transport_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [isCustomer] bit  NOT NULL
);
GO

-- Creating table 'TransportSet'
CREATE TABLE [dbo].[TransportSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [Target] nvarchar(max)  NOT NULL,
    [Mileage] int  NOT NULL
);
GO

-- Creating table 'CargoAttributeSet'
CREATE TABLE [dbo].[CargoAttributeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Attribute] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Cargo_Id] int  NOT NULL
);
GO

-- Creating table 'UserCargo'
CREATE TABLE [dbo].[UserCargo] (
    [User_Id] int  NOT NULL,
    [Cargo_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CargoSet'
ALTER TABLE [dbo].[CargoSet]
ADD CONSTRAINT [PK_CargoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransportSet'
ALTER TABLE [dbo].[TransportSet]
ADD CONSTRAINT [PK_TransportSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CargoAttributeSet'
ALTER TABLE [dbo].[CargoAttributeSet]
ADD CONSTRAINT [PK_CargoAttributeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Cargo_Id] in table 'UserCargo'
ALTER TABLE [dbo].[UserCargo]
ADD CONSTRAINT [PK_UserCargo]
    PRIMARY KEY CLUSTERED ([User_Id], [Cargo_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cargo_Id] in table 'CargoAttributeSet'
ALTER TABLE [dbo].[CargoAttributeSet]
ADD CONSTRAINT [FK_CargoCargoAttribute]
    FOREIGN KEY ([Cargo_Id])
    REFERENCES [dbo].[CargoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoCargoAttribute'
CREATE INDEX [IX_FK_CargoCargoAttribute]
ON [dbo].[CargoAttributeSet]
    ([Cargo_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserCargo'
ALTER TABLE [dbo].[UserCargo]
ADD CONSTRAINT [FK_UserCargo_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cargo_Id] in table 'UserCargo'
ALTER TABLE [dbo].[UserCargo]
ADD CONSTRAINT [FK_UserCargo_Cargo]
    FOREIGN KEY ([Cargo_Id])
    REFERENCES [dbo].[CargoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCargo_Cargo'
CREATE INDEX [IX_FK_UserCargo_Cargo]
ON [dbo].[UserCargo]
    ([Cargo_Id]);
GO

-- Creating foreign key on [Transport_Id] in table 'CargoSet'
ALTER TABLE [dbo].[CargoSet]
ADD CONSTRAINT [FK_CargoTransport]
    FOREIGN KEY ([Transport_Id])
    REFERENCES [dbo].[TransportSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoTransport'
CREATE INDEX [IX_FK_CargoTransport]
ON [dbo].[CargoSet]
    ([Transport_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------