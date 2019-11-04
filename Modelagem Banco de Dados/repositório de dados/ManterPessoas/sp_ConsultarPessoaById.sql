use pimads4
go

CREATE PROCEDURE sp_ConsultarPessoaById
	@idPessoa int
AS 
BEGIN
	SELECT * FROM Pessoas
	WHERE idPessoa = @idPessoa
END
