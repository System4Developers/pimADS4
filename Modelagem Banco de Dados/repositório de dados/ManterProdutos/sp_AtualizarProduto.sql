use pimads4
go

CREATE PROCEDURE sp_AtualizarProduto
    @idProduto int,
	@dsProduto varchar(100),
	@valorVenda float,
	@valorCusto float,
	@tpProduto varchar(1),
	@fk_idUnidade_Unidades int,
	@fk_idFabricante_Fabricantes int
AS 
BEGIN
	UPDATE Produtos
	SET dsProduto = @dsProduto, valorVenda = @valorVenda,valorCusto=@valorCusto,tpProduto=@tpProduto,fk_idUnidade=@fk_idUnidade_Unidades,fk_idFabricante_Fabricantes=@fk_idFabricante_Fabricantes WHERE idProduto = @idProduto
END
