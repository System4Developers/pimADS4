use pimads4
go

CREATE PROCEDURE sp_CadastrarPedidoVenda
	 @dtDigitacao DATETIME
	,@tpPagamento VARCHAR(15)
	,@tpStatus VARCHAR(1)
	,@fk_idPessoa_Pessoas INT
	,@fk_idUsuario_Usuarios INT
AS 
BEGIN
	INSERT INTO PedidoVenda 
	(
		valorTotal
		,dtDigitacao
		,tpPagamento
		,tpStatus
		,fk_idPessoa_Pessoas
		,fk_idUsuario_Usuarios
	) 
	VALUES
	(
		0
		,@dtDigitacao
		,@tpPagamento
		,@tpStatus
		,@fk_idPessoa_Pessoas
		,@fk_idUsuario_Usuarios
	)
END
