use pimads4
go

CREATE PROCEDURE sp_ConsultarBairroById
	@idBairro int
AS 
BEGIN
	SELECT * FROM Bairros
	WHERE idBairro = @idBairro
END
