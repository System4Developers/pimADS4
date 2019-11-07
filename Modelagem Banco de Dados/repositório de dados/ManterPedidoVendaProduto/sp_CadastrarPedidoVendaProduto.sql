use pimads4
go

CREATE PROCEDURE sp_CadastrarPedidoVendaProduto
	 @vlrUnit FLOAT
	,@quantidade INT
	,@desconto INT
	,@fk_idPedidoVenda_PedidoVenda INT
	,@fk_idProduto_Produtos INT
AS 
BEGIN
	INSERT INTO PedidoVendaProduto 
	(
		 vlrUnit
		,quantidade
		,desconto
		,fk_idPedidoVenda_PedidoVenda
		,fk_idProduto_Produtos
	) 
	VALUES
	(
	     @vlrUnit
		,@quantidade
		,@desconto
		,@fk_idPedidoVenda_PedidoVenda
		,@fk_idProduto_Produtos
	)
END
