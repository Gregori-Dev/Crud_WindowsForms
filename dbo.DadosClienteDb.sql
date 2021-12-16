CREATE TABLE [dbo].[DadosClienteDb] (
    [IdCliente]    INT   NOT NULL IDENTITY,
    [NomeCliente]  VARCHAR (50) NOT NULL,
    [IdadeCliente] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DadosClienteDb] PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

