USE pimads4
GO

CREATE PROCEDURE sp_ExcluirProduto
(
	@idProduto int
)
AS BEGIN
	DELETE FROM Produtos WHERE idProduto=@idProduto
END
