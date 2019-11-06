use pimads4
go

CREATE PROCEDURE sp_CadastrarBairro
	@dsBairro varchar(150),
	@fk_idCidade_Cidades INT
AS 
BEGIN
	INSERT INTO Bairros 
	(
		dsBairro
		,fk_idCidade_Cidades
	) 
	VALUES
	(
		@dsBairro
		,@fk_idCidade_Cidades
	)
END
