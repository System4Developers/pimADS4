USE pimads4
GO

CREATE PROCEDURE sp_ExcluirUnidade
(
	@idUnidade int
)
AS BEGIN
	DELETE FROM Unidades 
	WHERE idUnidade=@idUnidade
END
