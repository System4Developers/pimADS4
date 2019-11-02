CREATE DATABASE pimads4
GO

USE pimads4
GO

CREATE TABLE Bairros 
(
    idBairro INT PRIMARY KEY IDENTITY(1,1),
    dsBairro VARCHAR(40),
    fk_idCidade_Cidades INT
)

CREATE TABLE Pessoas 
(
    idPessoa INT PRIMARY KEY IDENTITY(1,1),
    tpPessoa VARCHAR(10),
    nmPessoa VARCHAR(100),
    numDocumento VARCHAR(15),
    numRG VARCHAR(12),
    dtNascimento DATETIME,
    dsEmail VARCHAR(100),
    dsEndereco VARCHAR(120),
    complemento VARCHAR(10),
    numEnd VARCHAR(5),
    observacao VARCHAR(100),
    fk_idBairro_Bairros INT,
)

CREATE TABLE Estados 
(
    idEstado INT PRIMARY KEY IDENTITY(1,1),
    nmEstado VARCHAR(40),
    dsSigla VARCHAR(2),
    codIBGE VARCHAR(7)
)

CREATE TABLE Usuarios 
(
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    dsLogin VARCHAR(15),
    dsSenha VARCHAR(15),
    nmUsuario VARCHAR(40),
    tpUsuario VARCHAR(10),
    tpStatus VARCHAR(1)
)

CREATE TABLE OrdemCompra 
(
    idOrdemCompra INT PRIMARY KEY IDENTITY(1,1),
    valorTotal FLOAT,
    dtDigitacao DATETIME,
    tpStatus VARCHAR(1),
    fk_idUsuario_Usuarios INT,
    fk_idPessoa_Pessoas INT
)



CREATE TABLE OrdemCompraProduto 
(
    idOcProduto INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT,
    quantidade INT,
    fk_idOrdemCompra_OrdemCompra INT,
    fk_idProduto_Produtos INT
)

CREATE TABLE PedidoVenda 
(
    idPedVenda INT PRIMARY KEY IDENTITY(1,1),
    valorTotal FLOAT,
    dtDigitacao DATETIME,
    tpPagamento VARCHAR(15),
    tpStatus VARCHAR(1),
    fk_idPessoa_Pessoas INT
)

CREATE TABLE Cidades 
(
    idCidade INT PRIMARY KEY IDENTITY(1,1),
    nmCidade VARCHAR(40),
    codIBGE VARCHAR(7),
    fk_idEstado_Estados INT
)

CREATE TABLE PedidoProduto 
(
    idPedProduto INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT,
    quantidade INT,
    desconto INT,
    fk_idPedVenda_PedidoVenda INT,
    fk_idProduto_Produtos INT,
)

CREATE TABLE Produtos 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    quantidade INT,
    dsProduto VARCHAR(100),
    valorVenda FLOAT,
    valorCusto FLOAT,
    tpProduto VARCHAR(1),
    fk_idUnidade_Unidades INT,
    fk_idFabricante_Fabricantes INT
)

CREATE TABLE Fabricantes 
(
    idFabricante INT PRIMARY KEY IDENTITY(1,1),
    nmFabricante VARCHAR(50)
)

CREATE TABLE Unidades 
(
    idUnidade INT PRIMARY KEY IDENTITY(1,1),
    dsUnidade VARCHAR(5)
)


ALTER TABLE Bairros ADD FOREIGN KEY(fk_idCidade_Cidades) REFERENCES Cidades(idCidade)

ALTER TABLE Pessoas ADD FOREIGN KEY(fk_idBairro_Bairros) REFERENCES Bairros (idBairro)

ALTER TABLE OrdemCompra ADD FOREIGN KEY(fk_idUsuario_Usuarios) REFERENCES Usuarios (idUsuario)
ALTER TABLE OrdemCompra ADD  FOREIGN KEY(fk_idPessoa_Pessoas) REFERENCES Pessoas (idPessoa)

ALTER TABLE OrdemCompraProduto ADD FOREIGN KEY(idOrdemCompra) REFERENCES OrdemCompra (idOrdemCompra)
ALTER TABLE OrdemCompraProduto ADD FOREIGN KEY(fk_idProduto_Produtos) REFERENCES Produtos (idProduto)

ALTER TABLE PedidoVenda ADD FOREIGN KEY (fk_idPessoa_Pessoas) REFERENCES Pessoas (idPessoa)

ALTER TABLE Cidades ADD FOREIGN KEY(fk_idEstado_Estados) REFERENCES Estados (idEstado)

ALTER TABLE PedidoProduto ADD FOREIGN KEY(fk_idPedVenda_PedidoVenda) REFERENCES PedidosVenda (idPedVenda)
ALTER TABLE PedidoProduto ADD FOREIGN KEY(fk_idProduto_Produtos) REFERENCES Produtos (idProduto)

ALTER TABLE Produtos ADD FOREIGN KEY(fk_idUnidade_Unidades) REFERENCES Unidades(idUnidade)
ALTER TABLE Produtos ADD FOREIGN KEY(fk_idFabricante_Fabricantes) REFERENCES Fabricantes(idFabricante)

