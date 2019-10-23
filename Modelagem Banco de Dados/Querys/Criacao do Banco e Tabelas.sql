CREATE DATABASE pimads4
GO

USE pimads4
GO

CREATE TABLE Usuarios 
(
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    dsLogin VARCHAR(15) NOT NULL,
    dsSenha VARCHAR(15) NOT NULL,
    tpStatus VARCHAR(10) NOT NULL,
    nmUsuario VARCHAR(40) NOT NULL,
    tpUsuario VARCHAR(10) NOT NULL
)
GO

CREATE TABLE Estoque 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    qtdDisponivel INT NOT NULL
)
GO

CREATE TABLE Bairros 
(
    idBairro INT PRIMARY KEY IDENTITY(1,1),
    dsBairro VARCHAR(70)  NOT NULL,
    fk_idCidade_Cidades INT
)
GO

CREATE TABLE Estados 
(
    idEstado INT PRIMARY KEY IDENTITY(1,1),
    dsSigla VARCHAR(2)  NOT NULL,
    codIBGE VARCHAR(7),
    nmEstado VARCHAR(40)  NOT NULL
)
GO

CREATE TABLE Cidades 
(
    idCidade INT PRIMARY KEY IDENTITY(1,1),
    nmCidade VARCHAR(40)  NOT NULL,
    codIBGE VARCHAR(7),
    fk_idEstado_estados INT,
)
GO

CREATE TABLE Pessoas 
(
    idPessoa INT PRIMARY KEY IDENTITY(1,1),
    nmPessoa VARCHAR(100),
    tpPessoa VARCHAR(10)  NOT NULL,
    CPF VARCHAR(15),
    RG VARCHAR(12),
    nmRazaoSocial VARCHAR(120),
    dsObs VARCHAR(10),
    dsEstadoCivil VARCHAR(10),
    tpStatus VARCHAR(1)  NOT NULL,
    CNPJ VARCHAR(15),
    dsEmail VARCHAR(100),
    dtNascimento DATETIME,
    complemento VARCHAR(10),
    endereco VARCHAR(10)  NOT NULL,
    numEnd VARCHAR(10)  NOT NULL,
    fk_idBairro_bairros INT,
)
GO

CREATE TABLE Pedidos 
(
    idPedido INT PRIMARY KEY IDENTITY(1,1),
    dtDigitacao DATETIME  NOT NULL,
    valorTotal FLOAT,
    formaPagamento VARCHAR(12),
    tpStatus VARCHAR(1)  NOT NULL,
    formaAquisicao VARCHAR(10),
    tpPedido VARCHAR(10)  NOT NULL,
    fk_idPessoa_pessoas INT,
    fk_idUsuario_usuarios INT,
)
GO

CREATE TABLE Produtos 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    dsProduto VARCHAR(100)  NOT NULL,
    valorVenda FLOAT  NOT NULL,
    valorCusto FLOAT  NOT NULL,
    fk_idUnidade_unidades INT,
    fk_idFabricante_fabricantes INT
)
GO

CREATE TABLE unidades 
(
    idUnidade INT PRIMARY KEY IDENTITY(1,1),
    dsUnidade VARCHAR(5)  NOT NULL
)
GO

CREATE TABLE fabricantes 
(
    idFabricante INT PRIMARY KEY IDENTITY(1,1),
    nmFabricante VARCHAR(50)  NOT NULL
)
GO

CREATE TABLE PedProduto 
(
    idPedProd INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT NOT NULL,
    quantidade INT  NOT NULL,
    fk_idProduto_produtos INT,
    fk_idPedido_Pedidos INT
)
GO

ALTER TABLE Bairros ADD FOREIGN KEY (fk_idCidade_Cidades) REFERENCES Cidades(idCidade)
ALTER TABLE Cidades ADD FOREIGN KEY(fk_idEstado_estados) REFERENCES Estados (idEstado)
ALTER TABLE Pessoas ADD FOREIGN KEY(fk_idBairro_bairros) REFERENCES Bairros (idBairro)
ALTER TABLE Produtos ADD FOREIGN KEY (fk_idUnidade_unidades) REFERENCES unidades (idUnidade)
ALTER TABLE Produtos ADD FOREIGN KEY (fk_idFabricante_fabricantes) REFERENCES fabricantes (idFabricante)
ALTER TABLE Pedidos ADD FOREIGN KEY(fk_idPessoa_pessoas) REFERENCES Pessoas (idPessoa)
ALTER TABLE Pedidos ADD FOREIGN KEY(fk_idUsuario_usuarios) REFERENCES Usuarios (idUsuario)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idProduto_produtos) REFERENCES Produtos (idProduto)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idPedido_Pedidos) REFERENCES Pedidos (idPedido)
GO

INSERT INTO Usuarios VALUES('admin','admin','ATIVO','ADMINISTRADOR','ADMIN')
GO