use pimads4
go

CREATE PROCEDURE sp_AtualizarPedidoVenda
	 @idPedidoVenda INT
	,@dtDigitacao DATETIME
	,@tpPagamento VARCHAR(15)
	,@tpStatus VARCHAR(1)
	,@fk_idPessoa_Pessoas INT
	,@fk_idUsuario_Usuarios INT
AS 
BEGIN
	UPDATE PedidoVenda
	SET dtDigitacao = @dtDigitacao
	,tpPagamento = @tpPagamento
	,tpStatus = @tpStatus
	,fk_idPessoa_Pessoas=@fk_idPessoa_Pessoas
	,fk_idUsuario_Usuarios=@fk_idUsuario_Usuarios
	WHERE @idPedidoVenda = @idPedidoVenda
END
