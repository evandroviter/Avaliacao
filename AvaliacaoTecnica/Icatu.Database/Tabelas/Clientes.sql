CREATE TABLE [dbo].[Clientes]
(
	[Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Nome]		VARCHAR (30) NOT NULL,
    [CPF]		VARCHAR (11) NOT NULL,
    [Idade]		INT NOT NULL,
    [Endereco]	INT NULL, 
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id] ASC)
)
