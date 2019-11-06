use pimads4
go

CREATE PROCEDURE sp_CadastrarOrdemCompra
	 @dtDigitacao DATETIME
	,@tpStatus VARCHAR(1)
	,@fk_idUsuario_Usuarios INT
	,@fk_idPessoa_Pessoas INT
AS 
BEGIN
	INSERT INTO OrdemCompra 
	(
		dtDigitacao
		,valorTotal
		,tpStatus
		,fk_idUsuario_Usuarios
		,fk_idPessoa_Pessoas
	) 
	VALUES
	(
		@dtDigitacao
		,0
		,@tpStatus
		,@fk_idUsuario_Usuarios
		,@fk_idPessoa_Pessoas
	)
END
