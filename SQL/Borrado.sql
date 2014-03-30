USE LigabaDB
GO

--BORRADO DE TABLAS
DROP TABLE LigaBA.PartidoXJugador
GO
DROP TABLE LigaBA.Partido
GO
DROP TABLE LigaBA.TorneoXCategoriaXEquipo
GO
DROP TABLE LigaBA.TorneoXCategoria
GO
DROP TABLE LigaBA.Torneo
GO
DROP TABLE LigaBA.JugadorXEquipo
GO
DROP TABLE LigaBA.Equipo
GO
DROP TABLE LigaBA.TipoDeTorneo
GO
DROP TABLE LigaBA.Categoria
GO
DROP TABLE LigaBA.Institucion
GO
DROP TABLE LigaBA.Jugador
GO
DROP TABLE LigaBA.Usuarios
GO

--BORRADO DE STORE PROCEDURES
	--USUARIO
		DROP PROCEDURE [LigaBA].[p_login]
		GO
		DROP PROCEDURE [LigaBA].[p_AltaUsuario]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaUsuario]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarContraseñaUsuario]
		GO
	--CATEGORIA
		DROP PROCEDURE [LigaBA].[p_AltaCategoria]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaCategoria]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarCategoria]
		GO
	--JUGADOR
		DROP PROCEDURE [LigaBA].[p_AltaJugador]
		GO
		DROP PROCEDURE [LigaBA].[p_BuscarJugador]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarJugador]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaJugador]
	GO
	--TIPO TORNEO
		DROP PROCEDURE [LigaBA].[p_AltaTipoDeTorneo]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaTipoDeTorneo]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarTipoDeTorneo]
		GO
	--EQUIPO
		DROP PROCEDURE [LigaBA].[p_AltaEquipo]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaEquipo]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarEquipo]	
		GO
	--INSTITUCION
		DROP PROCEDURE [LigaBA].[p_AltaInstitucion]
		GO
		DROP PROCEDURE [LigaBA].[p_ModificarInstitucion]
		GO
		DROP PROCEDURE [LigaBA].[p_BajaInstitucion]
		GO	
	--TORNEO
		--DROP PROCEDURE [LigaBA].[p_AltaTorneo]
		GO
		--DROP PROCEDURE [LigaBA].[p_ModificarTorneo]
		GO
		--DROP PROCEDURE [LigaBA].[p_BajaTorneo]
		GO
		--PARTIDO
		--DROP PROCEDURE [LigaBA].[p_AltaPartido]
		GO
		--DROP PROCEDURE [LigaBA].[p_ModificarPartido]
		GO
		--DROP PROCEDURE [LigaBA].[p_BajaPartido]
		GO
--BORRADO FUNCIONES
	--INSTITUCION
		DROP FUNCTION [LigaBA].[f_NombreInstitucion] 
		GO
	--CATEGORIA
		DROP FUNCTION [LigaBA].[f_NombreCategoria] 
		GO
		
--BORRADO DE ESQUEMA
DROP SCHEMA LigaBA
--BORRADO DE BASE DE DATOS
DROP DATABASE LigabaDB