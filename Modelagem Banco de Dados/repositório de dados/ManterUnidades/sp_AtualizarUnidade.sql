use pimads4
go

CREATE PROCEDURE sp_AtualizarUnidade
    @idUnidade int,
	@dsUnidade varchar(5)
AS 
BEGIN
	UPDATE Unidades
	SET dsUnidade = @dsUnidade 
	WHERE idUnidade = @idUnidade
END
