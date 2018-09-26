SELECT name FROM master.dbo.sysdatabases

DROP DATABASE strConn

select * from Clientes

select * from Produtoes

select * from Vendas








-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/20/2018 15:19:27
-- Generated from EDMX file: C:\Users\Pericles\Documents\WorkspaceVS\Aulas\SpeedBuy\SpeedBuy\ViewWPF\DBFirst\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet] DROP CONSTRAINT [FK_ClienteVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoItemVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_ProdutoItemVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_VendaItemVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemVendaSet] DROP CONSTRAINT [FK_VendaItemVenda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[VendaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendaSet];
GO
IF OBJECT_ID(N'[dbo].[ItemVendaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemVendaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Endereco] nvarchar(max)  NOT NULL,
    [Cpf] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProdutoSet'
CREATE TABLE [dbo].[ProdutoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Categoria] nvarchar(max)  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Preco] float  NOT NULL,
    [ItemVenda_Id] int  NOT NULL
);
GO

-- Creating table 'VendaSet'
CREATE TABLE [dbo].[VendaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
	[Cpf] nvarchar(max)  NOT NULL,
	[Codigo] nvarchar(max)  NOT NULL,
	[Qtd] nvarchar(max) NOT NULL,
    [TotalVenda] nvarchar(max)
);
GO

-- Creating table 'ItemVendaSet'
CREATE TABLE [dbo].[ItemVendaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VendaId] int  NOT NULL,
    [PrecoTotal] float  NOT NULL,
    [Quantidade] int  NOT NULL,
    [VendaItemVenda_ItemVenda_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [PK_ProdutoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [PK_VendaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemVendaSet'
ALTER TABLE [dbo].[ItemVendaSet]
ADD CONSTRAINT [PK_ItemVendaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------




-- Creating foreign key on [ItemVenda_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_ProdutoItemVenda]
    FOREIGN KEY ([ItemVenda_Id])
    REFERENCES [dbo].[ItemVendaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoItemVenda'
CREATE INDEX [IX_FK_ProdutoItemVenda]
ON [dbo].[ProdutoSet]
    ([ItemVenda_Id]);
GO

-- Creating foreign key on [VendaItemVenda_ItemVenda_Id] in table 'ItemVendaSet'
ALTER TABLE [dbo].[ItemVendaSet]
ADD CONSTRAINT [FK_VendaItemVenda]
    FOREIGN KEY ([VendaItemVenda_ItemVenda_Id])
    REFERENCES [dbo].[VendaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendaItemVenda'
CREATE INDEX [IX_FK_VendaItemVenda]
ON [dbo].[ItemVendaSet]
    ([VendaItemVenda_ItemVenda_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------