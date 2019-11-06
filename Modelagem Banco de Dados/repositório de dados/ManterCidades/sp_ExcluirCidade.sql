USE pimads4
GO

CREATE PROCEDURE sp_ExcluirCidade
(
	@idCidade int
)
AS BEGIN
	DELETE FROM Cidades 
	WHERE idCidade=@idCidade
END
