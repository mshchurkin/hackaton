
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2016 14:05:32
-- Generated from EDMX file: \\mac\Home\Documents\Visual Studio 2013\Projects\hackaton\hackaton\Models\Shipments.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CargoSet'
CREATE TABLE [dbo].[CargoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
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

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoTransport'
CREATE INDEX [IX_FK_CargoTransport]
ON [dbo].[CargoSet]
    ([Transport_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------