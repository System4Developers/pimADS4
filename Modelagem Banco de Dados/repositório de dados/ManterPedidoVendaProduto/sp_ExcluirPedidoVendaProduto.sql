USE pimads4
GO

CREATE PROCEDURE sp_ExcluirPedidoVendaProduto
(
	@idPedidoVendaProduto INT
)
AS BEGIN
	DELETE FROM PedidoVendaProduto 
	WHERE idPedidoVendaProduto=@idPedidoVendaProduto
END
