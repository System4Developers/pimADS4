use pimads4
go

CREATE PROCEDURE sp_ConsultarPessoaById
	@idPessoa int
AS 
BEGIN
	SELECT * FROM Pessoas
	JOIN Bairros on Bairros.idBairro = Pessoas.fk_idBairro_Bairros
	JOIN Cidades on Cidades.idCidade = Bairros.fk_idCidade_Cidades
	WHERE idPessoa = @idPessoa
END
