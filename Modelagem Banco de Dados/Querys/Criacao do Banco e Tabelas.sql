CREATE DATABASE pimads4
GO

USE pimads4
GO

CREATE TABLE Usuario (
	idUsuario INT PRIMARY KEY IDENTITY(1,1),
	tipoUsuario VARCHAR(6) not null,
	dsLogin VARCHAR(50) not null,
	senha VARCHAR(40) not null,
	tipoStatus VARCHAR(1) not null
)
GO

CREATE TABLE Cliente (
	idCliente INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) not null,
	cpf VARCHAR(15) not null,
	dtNascimento DATETIME not null,
	estadoCivil VARCHAR(10) not null,
	rg VARCHAR(12),
	dsObs VARCHAR(200),
	razaoSocial VARCHAR(120),
	tipoStatus VARCHAR(1) not null,
	email VARCHAR(100),
	tipo VARCHAR(10) not null
)
GO

CREATE TABLE Fabricante (
	idFabricante INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) not null
)
GO

CREATE TABLE Unidade(
	idUnidade INT PRIMARY KEY IDENTITY(1,1),
	dsUnidade varchar(4) not null
)	

CREATE TABLE Estado (
	idEstado INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(40) not null,
	sigla VARCHAR(2) not null,
	codIbge VARCHAR(7) not null	
)
GO

CREATE TABLE Cidade (
	idCidade INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(40) not null,
	codIbge VARCHAR(7) not null,
	fk_idEstado_estado INT
)
ALTER TABLE Cidade ADD FOREIGN KEY(fk_idEstado_estado) REFERENCES Estado (idEstado)
GO

CREATE TABLE Produto (
	idProduto INT PRIMARY KEY IDENTITY(1,1),
	codAlter VARCHAR(12),
	dsProduto VARCHAR(100) not null,
	valorEntrada FLOAT not null,
	fk_idFabricante_fabricante INT,
	fk_idUnidade_unidade INT
)
ALTER TABLE Produto ADD FOREIGN KEY(fk_idFabricante_fabricante) REFERENCES Fabricante(idFabricante)
ALTER TABLE Produto ADD FOREIGN KEY(fk_idUnidade_unidade) REFERENCES Unidade(idUnidade)
GO

CREATE TABLE MovEstoque (
	idMovimentacao INT PRIMARY KEY IDENTITY(1,1),
	dtMov DATETIME not null,
	quantidade INT not null,
	operacao INT not null,
	Obs VARCHAR(200),
	fk_idProduto_produto INT,
	fk_idUsuario_usuario INT
)
ALTER TABLE MovEstoque ADD FOREIGN KEY(fk_idProduto_produto) REFERENCES Produto(idProduto)
ALTER TABLE MovEstoque ADD FOREIGN KEY(fk_idUsuario_usuario) REFERENCES Usuario(idUsuario)
GO

CREATE TABLE Pedido (
	idPedido INT PRIMARY KEY IDENTITY(1,1),
	numPedido INT not null,
	formaPagamento VARCHAR(12) not null,
	tipoStatus VARCHAR(10) not null,
	dtDigitacao DATETIME not null,
	valorTotal FLOAT,
	fk_idCliente_cliente INT,
	fk_idUsuario_usuario INT
)
ALTER TABLE Pedido ADD FOREIGN KEY(fk_idCliente_cliente) REFERENCES Cliente(idCliente)
ALTER TABLE Pedido ADD FOREIGN KEY(fk_idUsuario_usuario) REFERENCES Usuario(idUsuario)
GO

CREATE TABLE Logradouro (
	idLogradouro INT PRIMARY KEY IDENTITY(1,1),
	endereco VARCHAR(120) not null,
	numero VARCHAR(5),
	bairro VARCHAR(40) not null,
	cep VARCHAR(10) not null,
	complemento VARCHAR(20),
	fk_idCidade_cidade INT,
	fk_idCliente_cliente INT,
)
ALTER TABLE Logradouro ADD FOREIGN KEY(fk_idCidade_cidade) REFERENCES Cidade(idCidade)
ALTER TABLE Logradouro ADD FOREIGN KEY(fk_idCliente_cliente) REFERENCES Cliente(idCliente)
GO

CREATE TABLE PedProduto (
	idPedItem INT PRIMARY KEY IDENTITY(1,1),
	quantidade INT not null,
	vlrUnit FLOAT not null,
	dsObs VARCHAR(200),
	subTotal FLOAT,
	fk_idPedido_pedido INT,
	fk_idProduto_produto INT,
)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idPedido_pedido) REFERENCES Pedido(idPedido)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idProduto_produto) REFERENCES Produto(idProduto)
GO


