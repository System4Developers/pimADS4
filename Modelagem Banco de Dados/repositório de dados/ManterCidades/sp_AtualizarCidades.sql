use pimads4
go

CREATE PROCEDURE sp_AtualizarCidades
    @idCidade int,
	@nmCidade varchar(150),
	@codIBGE varchar(7),
	@fk_idEstado_Estados int
AS 
BEGIN
	UPDATE Cidades
	SET nmCidade = @nmCidade,
	codIBGE=@codIBGE,
	fk_idEstado_Estados = @fk_idEstado_Estados 
	WHERE idCidade = @idCidade
END
