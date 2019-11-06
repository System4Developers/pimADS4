use pimads4
go

CREATE PROCEDURE sp_AtualizarFabricante
    @idFabricante int,
	@nmFabricante varchar(50)
AS 
BEGIN
	UPDATE fabricantes
	SET nmFabricante = @nmFabricante 
	WHERE idFabricante = @idFabricante
END
