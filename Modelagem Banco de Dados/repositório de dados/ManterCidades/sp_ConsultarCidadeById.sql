use pimads4
go

CREATE PROCEDURE sp_ConsultarCidadeById
	@idCidade int
AS 
BEGIN
	SELECT * FROM Cidades
	WHERE idCidade = @idCidade
END
