USE pimads4
GO

CREATE PROCEDURE sp_ExcluirPedidoVenda
(
	@idPedidoVenda int
)
AS BEGIN
	DELETE FROM PedidoVenda 
	WHERE idPedidoVenda=@idPedidoVenda
END
