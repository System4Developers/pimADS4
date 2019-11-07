CREATE DATABASE pimads4
GO

USE pimads4
GO

CREATE TABLE Bairros 
(
    idBairro INT PRIMARY KEY IDENTITY(1,1),
    dsBairro VARCHAR(150) NOT NULL,
    fk_idCidade_Cidades INT
)

CREATE TABLE Pessoas 
(
    idPessoa INT PRIMARY KEY IDENTITY(1,1),
    tpPessoa VARCHAR(10) NOT NULL,
    nmPessoa VARCHAR(100) NOT NULL,
    numDocumento VARCHAR(15) NOT NULL,
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
    nmEstado VARCHAR(40) NOT NULL,
    dsSigla VARCHAR(2) NOT NULL,
    codIBGE VARCHAR(7)
)

CREATE TABLE Usuarios 
(
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    dsLogin VARCHAR(15) NOT NULL,
    dsSenha VARCHAR(15) NOT NULL,
    nmUsuario VARCHAR(40) NOT NULL,
    tpUsuario VARCHAR(10) NOT NULL,
    tpStatus VARCHAR(1) NOT NULL
)

CREATE TABLE OrdemCompra 
(
    idOrdemCompra INT PRIMARY KEY IDENTITY(1,1),
    valorTotal FLOAT,
    dtDigitacao DATETIME NOT NULL,
    tpStatus VARCHAR(1) NOT NULL,
    fk_idUsuario_Usuarios INT,
    fk_idPessoa_Pessoas INT
)

CREATE TABLE OrdemCompraProduto 
(
    idOcProduto INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT NOT NULL,
    quantidade INT NOT NULL,
    fk_idOrdemCompra_OrdemCompra INT,
    fk_idProduto_Produtos INT
)

CREATE TABLE PedidoVenda 
(
    idPedidoVenda INT PRIMARY KEY IDENTITY(1,1),
    valorTotal FLOAT,
    dtDigitacao DATETIME NOT NULL,
    tpPagamento VARCHAR(15) NOT NULL,
    tpStatus VARCHAR(1) NOT NULL,
    fk_idPessoa_Pessoas INT,
    fk_idUsuario_Usuarios INT
)

CREATE TABLE Cidades 
(
    idCidade INT PRIMARY KEY IDENTITY(1,1),
    nmCidade VARCHAR(150) NOT NULL,
    codIBGE VARCHAR(7),
    fk_idEstado_Estados INT
)

CREATE TABLE PedidoVendaProduto 
(
    idPedidoVendaProduto INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT NOT NULL,
    quantidade INT NOT NULL,
    desconto INT,
    fk_idPedidoVenda_PedidoVenda INT,
    fk_idProduto_Produtos INT,

)

CREATE TABLE Produtos 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    quantidade INT,
    dsProduto VARCHAR(100) NOT NULL,
    valorVenda FLOAT,
    valorCusto FLOAT,
    tpProduto VARCHAR(1) NOT NULL,
    fk_idUnidade_Unidades INT,
    fk_idFabricante_Fabricantes INT
)

CREATE TABLE Fabricantes 
(
    idFabricante INT PRIMARY KEY IDENTITY(1,1),
    nmFabricante VARCHAR(50) NOT NULL
)

CREATE TABLE Unidades 
(
    idUnidade INT PRIMARY KEY IDENTITY(1,1),
    dsUnidade VARCHAR(5) NOT NULL
)


ALTER TABLE Bairros ADD FOREIGN KEY(fk_idCidade_Cidades) REFERENCES Cidades(idCidade)

ALTER TABLE Pessoas ADD FOREIGN KEY(fk_idBairro_Bairros) REFERENCES Bairros (idBairro)

ALTER TABLE OrdemCompra ADD FOREIGN KEY(fk_idUsuario_Usuarios) REFERENCES Usuarios (idUsuario)
ALTER TABLE OrdemCompra ADD  FOREIGN KEY(fk_idPessoa_Pessoas) REFERENCES Pessoas (idPessoa)

ALTER TABLE OrdemCompraProduto ADD FOREIGN KEY(fk_idOrdemCompra_OrdemCompra) REFERENCES OrdemCompra (idOrdemCompra)
ALTER TABLE OrdemCompraProduto ADD FOREIGN KEY(fk_idProduto_Produtos) REFERENCES Produtos (idProduto)

ALTER TABLE PedidoVenda ADD FOREIGN KEY (fk_idPessoa_Pessoas) REFERENCES Pessoas (idPessoa)
ALTER TABLE PedidoVenda ADD FOREIGN KEY (fk_idUsuario_Usuarios) REFERENCES Usuarios(idUsuario)

ALTER TABLE Cidades ADD FOREIGN KEY(fk_idEstado_Estados) REFERENCES Estados (idEstado)

ALTER TABLE PedidoVendaProduto ADD FOREIGN KEY(fk_idPedidoVenda_PedidoVenda) REFERENCES PedidoVenda (idPedidoVenda)
ALTER TABLE PedidoVendaProduto ADD FOREIGN KEY(fk_idProduto_Produtos) REFERENCES Produtos (idProduto)

ALTER TABLE Produtos ADD FOREIGN KEY(fk_idUnidade_Unidades) REFERENCES Unidades(idUnidade)
ALTER TABLE Produtos ADD FOREIGN KEY(fk_idFabricante_Fabricantes) REFERENCES Fabricantes(idFabricante)
