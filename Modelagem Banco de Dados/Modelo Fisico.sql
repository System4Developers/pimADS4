-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE Cidade (
nome VARCHAR(40),
idCidade VARCHAR(10) PRIMARY KEY,
codIbge VARCHAR(7),
idEstado INT
)

CREATE TABLE Estado (
nome VARCHAR(40),
sigla VARCHAR(2),
codIbge VARCHAR(7),
idEstado INT PRIMARY KEY
)

CREATE TABLE Fabricante (
idFabricante INT PRIMARY KEY,
nome VARCHAR(50)
)

CREATE TABLE MovEstoque (
idMovimentacao INT PRIMARY KEY,
dtMov DATETIME,
quantidade INT,
operacao INT,
Obs VARCHAR(200),
idProduto INT,
idUsuario INT
)

CREATE TABLE Produto (
unidade VARCHAR(4),
codAlter VARCHAR(12),
dsProduto VARCHAR(100),
idProduto INT PRIMARY KEY,
valorEntrada DOUBLE,
idFabricante INT,
FOREIGN KEY(idFabricante) REFERENCES Fabricante (idFabricante)
)

CREATE TABLE Pedido (
idPedido INT PRIMARY KEY,
numPedido INT,
formaPagamento VARCHAR(12),
status VARCHAR(1),
dtDigitacao DATETIME,
valorTotal DOUBLE,
idCliente INT,
idUsuario INT
)

CREATE TABLE Usuario (
tipo VARCHAR(6),
login VARCHAR(50),
senha VARCHAR(40),
idUsuario INT PRIMARY KEY,
status VARCHAR(1)
)

CREATE TABLE Cliente (
idCliente INT PRIMARY KEY,
nome VARCHAR(100),
cpf VARCHAR(15),
dtNascimento DATETIME,
estadoCivil VARCHAR(10),
rg VARCHAR(12),
sexo VARCHAR(1),
dsObs VARCHAR(200),
razaoSocial VARCHAR(120),
status VARCHAR(1),
email VARCHAR(100),
tipo VARCHAR(10)
)

CREATE TABLE Logradouro (
idLogradouro INT PRIMARY KEY,
endereco VARCHAR(120),
numero VARCHAR(5),
bairro VARCHAR(40),
cep VARCHAR(10),
complemento VARCHAR(20),
idCidade VARCHAR(10),
idCliente INT,
FOREIGN KEY(idCidade) REFERENCES Cidade (idCidade),
FOREIGN KEY(idCliente) REFERENCES Cliente (idCliente)
)

CREATE TABLE Relacao2_PedProduto (
idPedido INT,
idProduto INT,
quantidade INT,
idPedItem INT PRIMARY KEY,
vlrUnit DOUBLE,
dsObs VARCHAR(200),
subTotal DOUBLE,
FOREIGN KEY(idPedido) REFERENCES Pedido (idPedido),
FOREIGN KEY(idProduto) REFERENCES Produto (idProduto)
)

ALTER TABLE Cidade ADD FOREIGN KEY(idEstado) REFERENCES Estado (idEstado)
ALTER TABLE MovEstoque ADD FOREIGN KEY(idProduto) REFERENCES Produto (idProduto)
ALTER TABLE MovEstoque ADD FOREIGN KEY(idUsuario) REFERENCES Usuario (idUsuario)
ALTER TABLE Pedido ADD FOREIGN KEY(idCliente) REFERENCES Cliente (idCliente)
ALTER TABLE Pedido ADD FOREIGN KEY(idUsuario) REFERENCES Usuario (idUsuario)
