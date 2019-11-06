USE pimads4
GO

CREATE PROCEDURE sp_ExcluirBairro
(
	@idBairro int
)
AS BEGIN
	DELETE FROM Bairros 
	WHERE idBairro=@idBairro
END
