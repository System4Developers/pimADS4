USE pimads4
GO

CREATE PROCEDURE sp_ExcluirCidades
(
	@idCidade int
)
AS BEGIN
	DELETE FROM Cidades WHERE idCidade=@idCidade
END
