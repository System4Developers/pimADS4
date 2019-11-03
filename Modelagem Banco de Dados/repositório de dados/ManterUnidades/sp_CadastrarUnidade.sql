use pimads4
go

CREATE PROCEDURE sp_CadastrarUnidade
	@dsUnidade varchar(5)
AS 
BEGIN
	INSERT INTO Unidades (dsUnidade) 
	VALUES(@dsUnidade)
END
