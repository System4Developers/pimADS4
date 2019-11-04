USE pimads4
GO

CREATE PROCEDURE sp_ExcluirPessoa
(
	@idPessoa int
)
AS BEGIN
	DELETE FROM Pessoas WHERE idPessoa=@idPessoa
END
