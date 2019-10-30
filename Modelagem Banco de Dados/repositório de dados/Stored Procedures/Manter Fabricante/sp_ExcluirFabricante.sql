USE pimads4
GO

CREATE PROCEDURE sp_ExcluirFabricante
(
	@idFabricante int
)
AS BEGIN
	DELETE FROM Fabricantes WHERE idFabricante=@idFabricante
END
