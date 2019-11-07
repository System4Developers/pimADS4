use pimads4
go

CREATE PROCEDURE sp_ConsultarPedidoVendaProdutoById
	@idPedidoVendaProduto INT
AS 
BEGIN
	SELECT * FROM PedidoVendaProduto
	WHERE idPedidoVendaProduto = @idPedidoVendaProduto
END
