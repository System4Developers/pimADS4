use pimads4
go

CREATE PROCEDURE sp_ConsultarFabricanteById
	@idFabricante int
AS 
BEGIN
	SELECT * FROM fabricantes
	WHERE idFabricante = @idFabricante
END
