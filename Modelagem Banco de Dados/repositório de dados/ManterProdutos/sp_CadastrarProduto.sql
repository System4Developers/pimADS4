use pimads4
go

CREATE PROCEDURE sp_CadastrarProduto
	@dsProduto VARCHAR(100),
	@valorVenda FLOAT,
	@valorCusto FLOAT,
	@tpProduto VARCHAR(1),
	@fk_idUnidade_Unidades INT,
	@fk_idFabricante_Fabricantes INT
AS 
BEGIN
	INSERT INTO Produtos (quantidade,dsProduto,valorVenda,valorCusto,tpProduto,fk_idUnidade_Unidades,fk_idFabricante_Fabricantes) 
	VALUES(0,@dsProduto,@valorVenda,@valorCusto,@tpProduto,@fk_idUnidade_Unidades,@fk_idFabricante_Fabricantes)
END
