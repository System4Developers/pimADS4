USE pimads4
GO

CREATE PROCEDURE sp_ExcluirOrdemCompraProduto
(
	@idOcProduto INt
)
AS BEGIN
	DELETE FROM OrdemCompraProduto 
	WHERE idOcProduto=@idOcProduto
END
