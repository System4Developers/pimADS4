USE pimads4
GO

CREATE PROCEDURE sp_ExcluirUsuario
(
	@idUsuario int
)
AS BEGIN
	DELETE FROM Usuarios 
	WHERE idUsuario=@idUsuario
END
