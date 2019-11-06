USE pimads4
GO

CREATE PROCEDURE sp_ExcluirPedidoVenda
(
	@idPedVenda int
)
AS BEGIN
	DELETE FROM PedidoVenda 
	WHERE idPedVenda=@idPedVenda
END
