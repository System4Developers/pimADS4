use pimads4
go

CREATE PROCEDURE sp_AtualizarOrdemCompra
    @idOrdemCompra INT
	,@dtDigitacao DATETIME
	,@tpStatus VARCHAR(1)
	,@fk_idUsuario_Usuarios INT
	,@fk_idPessoa_Pessoas INT
AS 
BEGIN
	UPDATE OrdemCompra
	SET dtDigitacao = @dtDigitacao
	,tpStatus = @tpStatus
	,fk_idUsuario_Usuarios=@fk_idUsuario_Usuarios
	,fk_idPessoa_Pessoas=@fk_idPessoa_Pessoas
	WHERE idOrdemCompra = @idOrdemCompra
END
