use pimads4
go

CREATE PROCEDURE sp_CadastarFabricante
	@dsFabricante varchar(50)
AS 
BEGIN
	INSERT INTO fabricantes (nmFabricante) 
	VALUES(@dsFabricante)
END
