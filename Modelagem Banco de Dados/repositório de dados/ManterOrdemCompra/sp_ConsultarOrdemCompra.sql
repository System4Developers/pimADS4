USE pimads4
GO

CREATE PROCEDURE sp_ConsultarOrdemCompraEmitida
	@dtInicio datetime,
	@dtFinal datetime,
	@idPessoa int
AS
BEGIN
	IF isnull(@dtInicio,'') != '' and isnull(@idPessoa,0) != 0
		SELECT * from OrdemCompra WHERE (dtDigitacao BETWEEN @dtInicio AND @dtFinal) AND (fk_idPessoa_Pessoas = @idPessoa)
	ELSE IF isnull(@dtInicio,'') !='' AND isnull(@idPessoa,0) = 0
		SELECT * FROM OrdemCompra WHERE (dtDigitacao BETWEEN @dtInicio AND @dtFinal)
	ELSE IF isnull(@dtInicio,'') = '' AND isnull(@idPessoa,0) !=0
		SELECT * FROM OrdemCompra WHERE fk_idPessoa_Pessoas=@idPessoa
	ELSE IF isnull(@dtInicio,'') = '' AND isnull(@idPessoa,0) =0
		SELECT * FROM OrdemCompra
END