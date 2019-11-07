use pimads4
go

CREATE PROCEDURE sp_ConsultarPedidoVendaById
	@idPedidoVenda int
AS 
BEGIN
	SELECT * FROM PedidoVenda
	WHERE idPedidoVenda = @idPedidoVenda
END
