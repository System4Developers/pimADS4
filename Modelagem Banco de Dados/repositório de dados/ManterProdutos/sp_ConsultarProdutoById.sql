use pimads4
go

CREATE PROCEDURE sp_ConsultarProdutoById
	@idProduto int
AS 
BEGIN
	SELECT * FROM Produtos
	WHERE idProduto = @idProduto
END
