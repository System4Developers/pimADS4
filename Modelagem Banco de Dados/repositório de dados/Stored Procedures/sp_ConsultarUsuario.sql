USE [pimads4]
GO

CREATE PROCEDURE sp_ConsultarUsuarioById
	@idUsuario int
AS 
BEGIN
	SELECT * FROM Usuarios
	WHERE idUsuario = @idUsuario
END
