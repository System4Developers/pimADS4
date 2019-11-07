use pimads4
go

CREATE PROCEDURE sp_ConsultarOrdemCompraProdutoById
	@idOcProduto INT
AS 
BEGIN
	SELECT * FROM OrdemCompraProduto
	WHERE idOcProduto = @idOcProduto
END
