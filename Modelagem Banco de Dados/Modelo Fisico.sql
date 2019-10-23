
CREATE TABLE Usuarios 
(
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    dsLogin VARCHAR(15),
    dsSenha VARCHAR(15),
    tpStatus VARCHAR(10),
    nmUsuario VARCHAR(40),
    tpUsuario VARCHAR(10)
)

CREATE TABLE Estoque 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    qtdDisponivel INT
)

CREATE TABLE Bairros 
(
    idBairro INT PRIMARY KEY IDENTITY(1,1),
    dsBairro VARCHAR(40),
    fk_idCidade_Cidades INT
)


CREATE TABLE Estados 
(
    idEstado INT PRIMARY KEY IDENTITY(1,1),
    dsSigla VARCHAR(2),
    codIBGE VARCHAR(7),
    nmEstado VARCHAR(40)
)

CREATE TABLE Cidades 
(
    idCidade INT PRIMARY KEY IDENTITY(1,1),
    nmCidade VARCHAR(40),
    codIBGE VARCHAR(7),
    fk_idEstado_estados INT,
)

CREATE TABLE Pessoas 
(
    idPessoa INT PRIMARY KEY IDENTITY(1,1),
    nmPessoa VARCHAR(100),
    tpPessoa VARCHAR(10),
    CPF VARCHAR(15),
    RG VARCHAR(12),
    nmRazaoSocial VARCHAR(120),
    dsObs VARCHAR(10),
    dsEstadoCivil VARCHAR(10),
    tpStatus VARCHAR(1),
    CNPJ VARCHAR(15),
    dsEmail VARCHAR(100),
    dtNascimento DATETIME,
    complemento VARCHAR(10),
    endereco VARCHAR(10),
    numEnd VARCHAR(10),
    fk_idBairro_bairros INT,
)

CREATE TABLE Pedidos 
(
    idPedido INT PRIMARY KEY IDENTITY(1,1),
    dtDigitacao DATETIME,
    valorTotal FLOAT,
    formaPagamento VARCHAR(12),
    tpStatus VARCHAR(1),
    formaAquisicao VARCHAR(10),
    tpPedido VARCHAR(10),
    fk_idPessoa_pessoas INT,
    fk_idUsuario_usuarios INT,
)

CREATE TABLE Produtos 
(
    idProduto INT PRIMARY KEY IDENTITY(1,1),
    dsProduto VARCHAR(100),
    valorVenda FLOAT,
    valorCusto FLOAT,
    fk_idUnidade_unidades INT,
    fk_idFabricante_fabricantes INT
)

CREATE TABLE unidades 
(
    idUnidade INT PRIMARY KEY IDENTITY(1,1),
    dsUnidade VARCHAR(5)
)

CREATE TABLE fabricantes 
(
    idFabricante INT PRIMARY KEY IDENTITY(1,1),
    nmFabricante VARCHAR(50)
)

CREATE TABLE PedProduto 
(
    idPedProd INT PRIMARY KEY IDENTITY(1,1),
    vlrUnit FLOAT,
    quantidade INT,
    fk_idProduto_produtos INT,
    fk_idPedido_Pedidos INT
)

ALTER TABLE Bairros ADD FOREIGN KEY (fk_idCidade_Cidades) REFERENCES Cidades(idCidade)
ALTER TABLE Cidades ADD FOREIGN KEY(fk_idEstado_estados) REFERENCES Estados (idEstado)
ALTER TABLE Pessoas ADD FOREIGN KEY(idBairro) REFERENCES Bairros (idBairro)
ALTER TABLE Produtos ADD FOREIGN KEY (fk_idUnidade_unidades) REFERENCES unidades (idUnidade)
ALTER TABLE Produtos ADD FOREIGN KEY (fk_idFabricante_fabricantes) REFERENCES fabricantes (idFabricante)
ALTER TABLE Pedidos ADD FOREIGN KEY(fk_idPessoa_pessoas) REFERENCES Pessoas (idPessoa)
ALTER TABLE Pedidos ADD FOREIGN KEY(fk_idUsuario_usuarios) REFERENCES Usuarios (idUsuario)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idProduto_produtos) REFERENCES Produtos (idProduto)
ALTER TABLE PedProduto ADD FOREIGN KEY(fk_idPedido_Pedidos) REFERENCES Pedidos (idPedido)
