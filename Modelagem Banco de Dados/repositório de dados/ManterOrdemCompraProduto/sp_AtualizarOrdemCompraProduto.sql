use pimads4
go

CREATE PROCEDURE sp_AtualizarOrdemCompraProduto
     @idOcProduto INT
	,@vlrUnit FLOAT
	,@quantidade INT
	,@fk_idProduto_Produtos INT
AS 
BEGIN
	UPDATE OrdemCompraProduto
	SET vlrUnit = @vlrUnit
	,quantidade = @quantidade
	,fk_idProduto_Produtos=@fk_idProduto_Produtos
	WHERE idOcProduto = @idOcProduto
END
