use pimads4
go

CREATE PROCEDURE sp_ConsultarBairroById
	@idBairro int
AS 
BEGIN
	SELECT * FROM Bairros
	JOIN Cidades on Bairros.fk_idCidade_Cidades = Cidades.idCidade
	WHERE idBairro = @idBairro
END
