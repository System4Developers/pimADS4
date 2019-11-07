use pimads4
go

CREATE PROCEDURE sp_CadastrarOrdemCompraProduto
	 @vlrUnit FLOAT
	,@quantidade INT
	,@fk_idOrdemCompra_OrdemCompra INT
	,@fk_idProduto_Produtos INT
AS 
BEGIN
	INSERT INTO OrdemCompraProduto 
	(
		 vlrUnit
		,quantidade
		,fk_idOrdemCompra_OrdemCompra
		,fk_idProduto_Produtos
	) 
	VALUES
	(
	     @vlrUnit
		,@quantidade
		,@fk_idOrdemCompra_OrdemCompra
		,@fk_idProduto_Produtos
	)
END
