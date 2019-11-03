use pimads4
go

CREATE PROCEDURE sp_ConsultarUnidadeById
	@idUnidade int
AS 
BEGIN
	SELECT * FROM Unidades
	WHERE idUnidade = @idUnidade
END
