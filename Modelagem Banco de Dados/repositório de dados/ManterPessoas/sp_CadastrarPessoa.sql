use pimads4
go

CREATE PROCEDURE sp_CadastrarPessoa
	@tpPessoa VARCHAR(10)
	,@nmPessoa VARCHAR(100)
	,@numDocumento VARCHAR(15)
	,@numRG VARCHAR(12)
	,@dtNascimento DATETIME
	,@dsEmail VARCHAR(100)
	,@dsEndereco VARCHAR(120)
	,@complemento VARCHAR(10)
	,@numEnd VARCHAR(5)
	,@observacao VARCHAR(100)
	,@fk_idBairro_Bairros INT
AS 
BEGIN
	INSERT INTO Pessoas
	(
		tpPessoa
		,nmPessoa
		,numDocumento
		,numRG
		,dtNascimento
		,dsEmail
		,dsEndereco
		,complemento
		,numEnd
		,observacao
		,fk_idBairro_Bairros
	) 
	VALUES
	(
		@tpPessoa
		,@nmPessoa
		,@numDocumento
		,@numRG
		,@dtNascimento
		,@dsEmail
		,@dsEndereco
		,@complemento
		,@numEnd
		,@observacao
		,@fk_idBairro_Bairros
	)
END
