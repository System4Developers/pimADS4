use pimads4
go

CREATE PROCEDURE sp_CadastrarUsuario
	@dsLogin varchar(15),
	@dsSenha varchar(15),
	@tpStatus varchar(10),
	@nmUsuario varchar(40),
	@tpUsuario varchar(10)
AS 
BEGIN
	INSERT INTO Usuarios(dsLogin,dsSenha,tpStatus,nmUsuario,tpUsuario)
	VALUES(@dsLogin,@dsSenha,@tpStatus,@nmUsuario,@tpUsuario)
END
