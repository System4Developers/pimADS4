use pimads4
go

CREATE PROCEDURE sp_CadastarUsuario
	@tpUsuario varchar(6),
	@dsLogin varchar(50),
	@dsSenha varchar(40),
	@tpStatus varchar(1)
AS 
BEGIN
	INSERT INTO Usuario(tpUsuario,dsLogin,dsSenha,tpStatus)
	VALUES(@tpUsuario,@dsLogin,@dsSenha,@tpStatus)
END

