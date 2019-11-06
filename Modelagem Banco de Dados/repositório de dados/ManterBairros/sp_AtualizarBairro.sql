use pimads4
go

CREATE PROCEDURE sp_AtualizarBairro
    @idBairro int,
	@dsBairro varchar(150),
	@fk_idCidade_Cidades int
AS 
BEGIN
	UPDATE Bairros
	SET dsBairro = @dsBairro
	,fk_idCidade_Cidades = @fk_idCidade_Cidades 
	WHERE idBairro = @idBairro
END
