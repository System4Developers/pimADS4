use pimads4
go

CREATE PROCEDURE sp_AtualizarUsuario
    @idUsuario int,
	@dsLogin varchar(15),
	@dsSenha varchar(15),
	@tpStatus varchar(10),
	@nmUsuario varchar(40),
	@tpUsuario varchar(10)
AS 
BEGIN
	UPDATE Usuarios 
    SET dsLogin = @dsLogin,
        dsSenha =@dsSenha,
        tpStatus =@tpStatus,
        nmUsuario =@nmUsuario,
        tpUsuario = @tpUsuario
	WHERE idUsuario  = @idUsuario
END
