USE pimads4
GO

CREATE PROCEDURE sp_ExcluirOrdemCompra
(
	@idOrdemCompra int
)
AS BEGIN
	DELETE FROM OrdemCompra 
	WHERE idOrdemCompra=@idOrdemCompra
END
