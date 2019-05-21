CREATE TABLE [dbo].[Enderecos]
(
	[Id]            INT          IDENTITY (1, 1) NOT NULL,
	[ClienteId]		INT NOT NULL,
    [Logradouro]	VARCHAR (50) NOT NULL,
    [Bairro]        VARCHAR (40) NOT NULL,
	[Cidade]        VARCHAR (40) NOT NULL,
	[Estado]        VARCHAR (40) NOT NULL,    
    CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enderecos_Clientes] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id]) ON DELETE CASCADE    
)
