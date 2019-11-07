use pimads4
go

CREATE PROCEDURE sp_AtualizarPedidoVendaProduto
     @idPedidoVendaProduto INT
	,@vlrUnit FLOAT
	,@quantidade INT
	,@desconto INT
	,@fk_idProduto_Produtos INT
AS 
BEGIN
	UPDATE PedidoVendaProduto
	SET vlrUnit = @vlrUnit
	,quantidade = @quantidade
	,desconto = @desconto
	,fk_idProduto_Produtos=@fk_idProduto_Produtos
	WHERE idPedidoVendaProduto = @idPedidoVendaProduto
END
