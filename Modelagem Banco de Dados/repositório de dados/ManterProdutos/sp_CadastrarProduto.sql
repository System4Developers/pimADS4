use pimads4
go

CREATE PROCEDURE sp_CadastrarProduto
	@dsProduto VARCHAR(100),
	@vlrVenda FLOAT,
	@vlrCusto FLOAT,
	@tpProduto VARCHAR(1),
	@fk_idUnidade_Unidades INT,
	@fk_idFabricante_Fabricantes INT
AS 
BEGIN
	Set @quantidade =0

	INSERT INTO Produtos (quantidade,dsProduto,valorVenda,valorCusto,tpProduto,fk_idUnidade_Unidades,fk_idFabricante_Fabricantes) 
	VALUES(@quantidade,@dsProduto,@vlrVenda,@vlrCusto,@tpProduto,@fk_idUnidade_Unidades,@fk_idFabricante_Fabricantes)
END
