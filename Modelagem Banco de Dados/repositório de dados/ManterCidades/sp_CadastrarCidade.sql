use pimads4
go

CREATE PROCEDURE sp_CadastrarCidade
	@nmCidade varchar(150),
	@codIBGE varchar(7),
	@fk_idEstado_Estados int
AS 
BEGIN
	INSERT INTO Cidades (nmCidade,codIBGE,fk_idEstado_Estados) 
	VALUES(@nmCidade,@codIBGE,@fk_idEstado_Estados)
END
