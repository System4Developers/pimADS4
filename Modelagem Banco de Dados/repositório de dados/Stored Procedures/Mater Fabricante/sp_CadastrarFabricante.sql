use pimads4
go

CREATE PROCEDURE sp_CadastarFabricante
	@nmFabricante varchar(50)
AS 
BEGIN
	INSERT INTO fabricantes (nmFabricante) 
	VALUES(@nmFabricante)
END
