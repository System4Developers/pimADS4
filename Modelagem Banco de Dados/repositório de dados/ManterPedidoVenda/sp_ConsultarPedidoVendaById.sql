use pimads4
go

CREATE PROCEDURE sp_ConsultarPedidoVendaById
	@idPedVenda int
AS 
BEGIN
	SELECT * FROM PedidoVenda
	WHERE idPedVenda = @idPedVenda
END
