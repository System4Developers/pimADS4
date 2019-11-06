use pimads4
go

CREATE PROCEDURE sp_AtualizarPessoa
    @idPessoa int,
	@tpPessoa VARCHAR(1),
	@nmPessoa VARCHAR(100),
	@numDocumento VARCHAR(15),
	@numRG VARCHAR(12),
	@dtNascimento DATETIME,
	@dsEmail VARCHAR(100),
	@dsEndereco VARCHAR(120),
	@complemento VARCHAR(10),
	@numEnd VARCHAR(5),
	@observacao VARCHAR(100),
	@fk_idBairro_Bairros INT
AS 
BEGIN
	UPDATE Pessoas
	SET tpPessoa = @tpPessoa
	,nmPessoa=@nmPessoa
	,numDocumento=@numDocumento
	,numRG=@numRG
	,dtNascimento=@dtNascimento
	,dsEmail=@dsEmail
	,dsEndereco=@dsEndereco
	,complemento=@complemento
	,numEnd=@numEnd
	,observacao=@observacao
	,fk_idBairro_Bairros=@fk_idBairro_Bairros 
	WHERE idPessoa = @idPessoa
END
