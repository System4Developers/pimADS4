use pimads4
go

CREATE PROCEDURE sp_ConsultarOrdemCompraById
	@idOrdemCompra int
AS 
BEGIN
	SELECT * FROM OrdemCompra
	WHERE idOrdemCompra = @idOrdemCompra
END
