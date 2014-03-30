CREATE DATABASE LigabaDB;
GO

-- %% ENCABEZADO %%

USE LigabaDB
GO

--Evita que se devuelva el mensaje que muestra
--el recuento del n?mero de filas afectadas por una instrucci?n
SET NOCOUNT ON
GO

--Hace que SQL Server 2008 siga las reglas de SQL-92
--en cuanto a comillas delimitadoras de identificadores
--y cadenas literales.
SET QUOTED_IDENTIFIER ON
GO

--Define como igual y <> como distinto
SET ANSI_NULLS ON
GO


-- %% ESTRUCTURA %%

-- CREATE SCHEMA

CREATE SCHEMA LigaBA
GO


-- CREATE TYPES

--USUARIOS
CREATE TABLE LigaBA.Usuarios(
        username nvarchar(50) NOT NULL,
        password nvarchar(64) NOT NULL,
 CONSTRAINT PK_Usuarios PRIMARY KEY(username)
 );

GO

--JUGADOR
CREATE TABLE LigaBA.Jugador(
		id int IDENTITY NOT NULL,
        dni int NOT NULL UNIQUE,
        nombre nvarchar(50) NOT NULL,
 		apellido nvarchar(50) NOT NULL,
 		fecha_de_nacimiento date NOT NULL,
 		habilitado bit DEFAULT 1,
                borrado bit DEFAULT 0,
 CONSTRAINT PK_jugador PRIMARY KEY(id)
 );

GO

--INSTITUCION
CREATE TABLE LigaBA.Institucion(
        id int NOT NULL IDENTITY,
        nombre nvarchar(100) NOT NULL UNIQUE,
 		direccion nvarchar(300),
 		localidad nvarchar(300),
 		delegado nvarchar(100), 
 		coordinador nvarchar(100),
 		telefono nvarchar(100),
 		email nvarchar(100),
                borrado bit DEFAULT 0,
 CONSTRAINT PK_institucion PRIMARY KEY(id)
 );

GO

--CATEGORIA
CREATE TABLE LigaBA.Categoria(
        id int NOT NULL IDENTITY,
        nombre nvarchar(50) NOT NULL UNIQUE,
        borrado bit DEFAULT 0,
 CONSTRAINT PK_Categoria PRIMARY KEY(id)
 );

GO

--TIPODETORNEO
CREATE TABLE LigaBA.TipoDeTorneo(
        id int NOT NULL IDENTITY,
        nombre nvarchar(100) NOT NULL UNIQUE,
 CONSTRAINT PK_TipoDeTorneo PRIMARY KEY(id)
 );

GO

--EQUIPO
CREATE TABLE LigaBA.Equipo(
        id int NOT NULL IDENTITY,
        nombre nvarchar(100) NOT NULL,
        categoria int NOT NULL,
        institucion int NOT NULL,
        borrado bit NOT NULL DEFAULT 0,
 CONSTRAINT PK_Equipo PRIMARY KEY(id),
 CONSTRAINT FK_Equipo_Categoria FOREIGN KEY (categoria) REFERENCES LigaBA.Categoria(id),
 CONSTRAINT FK_Equipo_Institucion FOREIGN KEY (institucion) REFERENCES LigaBA.Institucion(id),
 );

GO

--JUGADORXEQUIPO
CREATE TABLE LigaBA.JugadorXEquipo(
        equipo int NOT NULL,
        jugador int NOT NULL,
 CONSTRAINT PK_JugadorXEquipo PRIMARY KEY(equipo,jugador),
 CONSTRAINT FK_JugadorXEquipo_Jugador FOREIGN KEY (jugador) REFERENCES LigaBA.Jugador(id),
 CONSTRAINT FK_JugadorXEquipo_Equipo FOREIGN KEY (equipo) REFERENCES LigaBA.Equipo(id),
 );

GO


--TORNEO
CREATE TABLE LigaBA.Torneo(
        id int NOT NULL IDENTITY,
        nombre nvarchar(300) NOT NULL UNIQUE,
        tipodetorneo int NOT NULL,
        tablageneral bit NOT NULL,
        tipoDeTablaGeneral nvarchar(100),
 CONSTRAINT PK_Torneo PRIMARY KEY(id),
 CONSTRAINT FK_Torneo_TipoDeTorneo FOREIGN KEY (tipodetorneo) REFERENCES LigaBA.TipoDeTorneo(id),
 );

GO

--TORNEOXCATEGORIA
CREATE TABLE LigaBA.TorneoXCategoria(
        id int NOT NULL IDENTITY,
        torneogeneral int NOT NULL,
        categoria int NOT NULL,
 CONSTRAINT PK_TorneoXCategoria PRIMARY KEY(id),
 CONSTRAINT FK_TorneoXCategoria_Categoria FOREIGN KEY (categoria) REFERENCES LigaBA.Categoria(id),
 );

GO

--TORNEOXCATEGORIAXEQUIPO
CREATE TABLE LigaBA.TorneoXCategoriaXEquipo(
        id int NOT NULL IDENTITY,
        torneoxcategoria int NOT NULL,
        equipo int NOT NULL,
        partidosjugados int NOT NULL DEFAULT 0,
        partidosganados int NOT NULL DEFAULT 0,
        partidosempatados int NOT NULL DEFAULT 0,
        partidosperdidos int NOT NULL DEFAULT 0,
        golesafavor int NOT NULL DEFAULT 0,
        golesencontra int NOT NULL DEFAULT 0,
        puntos int NOT NULL DEFAULT 0,
 CONSTRAINT PK_TorneoXCategoriaXEquipo PRIMARY KEY(id),
 CONSTRAINT FK_TorneoXCategoriaXEquipo_TorneoXCategoria FOREIGN KEY (torneoxcategoria) REFERENCES LigaBA.TorneoXCategoria(id),
 CONSTRAINT FK_TorneoXCategoriaXEquipo_Equipo FOREIGN KEY (equipo) REFERENCES LigaBA.Equipo(id),
 );

GO

--TORNEOXJUGADOR
CREATE TABLE LigaBA.PartidoXJugador(
        partido int NOT NULL,
        jugador int NOT NULL,
        goles int DEFAULT 0,
        amarillas int DEFAULT 0,
        rojas int DEFAULT 0,
 CONSTRAINT PK_PartidoXJugador PRIMARY KEY(torneoxcategoria,jugador),
 CONSTRAINT FK_PartidoXJugador_Partido FOREIGN KEY (partido) REFERENCES LigaBA.Partido(id),
 CONSTRAINT FK_PartidoXJugador_Jugador FOREIGN KEY (jugador) REFERENCES LigaBA.jugador(id),
 );

GO


--PARTIDOS
CREATE TABLE LigaBA.Partido(
        id int NOT NULL IDENTITY,
        equipolocal int NOT NULL,
        equipovisitante int NOT NULL,
        fecha nvarchar(50) NOT NULL,
        goleslocal int DEFAULT -1,
        golesvisiante int DEFAULT -1,
        torneoxcategoria int NOT NULL, 
 CONSTRAINT PK_Partido PRIMARY KEY(id),
 CONSTRAINT FK_Partido_TorneoXCategoria FOREIGN KEY (torneoxcategoria) REFERENCES LigaBA.TorneoXCategoria(id),
 CONSTRAINT FK_Partido_EquipoLocal FOREIGN KEY (equipolocal) REFERENCES LigaBA.Equipo(id),
 CONSTRAINT FK_Partido_EquipoVisitante FOREIGN KEY (equipovisitante) REFERENCES LigaBA.Equipo(id),
 CONSTRAINT U_Partido UNIQUE(equipolocal,equipovisitante,torneoxcategoria),
 );

GO



--CREAR USUARIO

INSERT INTO LigaBA.Usuarios (username,password) VALUES ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')
--

GO

--PROCEDURES
--LOGIN
CREATE PROCEDURE [LigaBA].[p_login]
(
        @user_name varchar(50),
        @respuesta int output
)       
AS
BEGIN transaction
        IF NOT EXISTS( SELECT * FROM LigaBA.Usuarios WHERE username = @user_name)
        BEGIN
                Set @respuesta = 1
                return
        END

        
        SELECT * FROM LigaBA.Usuarios WHERE username = @user_name
COMMIT
GO

--ALTAUSUARIO
CREATE PROCEDURE [LigaBA].[p_AltaUsuario]
(
        @usuario varchar(50),
        @password varchar(64)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT * FROM LigaBA.Usuarios WHERE username = @usuario)
        BEGIN
                RAISERROR ('El nombre de usuario que eligio ya existe.',16,1)
                ROLLBACK
                RETURN          
        END
        
        INSERT INTO LigaBA.Usuarios (username,password) VALUES (@usuario,@password)

COMMIT
GO

--BAJAUSUARIO
CREATE PROCEDURE [LigaBA].[p_BajaUsuario]
(
        @usuario varchar(50)
)       
AS
BEGIN transaction
        
DELETE FROM LigaBA.Usuarios WHERE username=@usuario

COMMIT

GO

--MODIFICARUSUARIO
CREATE PROCEDURE [LigaBA].[p_ModificarContraseñaUsuario]
(
        @usuario varchar(50),
        @password varchar(64)
)       
AS
BEGIN transaction
        
        UPDATE LigaBA.Usuarios SET password=@password WHERE username=@usuario 

COMMIT

GO

--ALTA CATEGORIA
CREATE PROCEDURE [LigaBA].[p_AltaCategoria]
(
        @categoria nvarchar(50)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Categoria WHERE nombre = @categoria)
        BEGIN
                RAISERROR ('La categoria que intenta agregar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END
        
        INSERT INTO LigaBA.Categoria(nombre) VALUES (@categoria)

COMMIT

GO

--BAJA CATEGORIA
CREATE PROCEDURE [LigaBA].[p_BajaCategoria]
(
        @Id int
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE categoria = @Id AND borrado=0)
        BEGIN
                RAISERROR ('No puede eliminar esa categoria por que existe al menos un equipo con esa categoria asignada.',16,1)
                ROLLBACK
                RETURN          
        END
        
        IF EXISTS(SELECT 1 FROM LigaBA.TorneoXCategoria WHERE categoria = @Id)
        BEGIN
                RAISERROR ('No puede eliminar esa categoria por que existe al menos un torneo con esa categoria asignada.',16,1)
                ROLLBACK
                RETURN          
        END
        
        UPDATE LigaBA.Categoria SET borrado=0

COMMIT

GO

--MODIFICAR CATEGORIA
CREATE PROCEDURE [LigaBA].[p_ModificarCategoria]
(
        @Id int,
        @Categoria nvarchar(50)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Categoria WHERE nombre = @categoria and id!=@Id)
        BEGIN
                RAISERROR ('Ya existe una categoria con ese nombre,la categoria no pudo ser modificada.',16,1)
                ROLLBACK
                RETURN          
        END
        
        UPDATE LigaBA.Categoria SET nombre=@Categoria where id=@Id

COMMIT

GO

--ALTA JUGADOR
CREATE PROCEDURE [LigaBA].[p_AltaJugador]
(        
        @dni int,
        @nombre nvarchar(50),
        @apellido nvarchar(50),
        @fecha_de_nacimiento date,
        @equipo int
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE dni = @dni)
        BEGIN
                RAISERROR ('El jugador que intenta agregar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END                
        
        DECLARE @jugador int
        INSERT INTO LigaBA.Jugador(dni,nombre,apellido,fecha_de_nacimiento ) VALUES (@dni,@nombre,@apellido,@fecha_de_nacimiento)
        
		SELECT @jugador = SCOPE_IDENTITY()
        
        INSERT INTO LigaBA.JugadorXEquipo(jugador,equipo) VALUES (@jugador,@equipo)

COMMIT

GO

--BUSCAR JUGADOR
CREATE PROCEDURE [LigaBA].[p_BuscarJugador]
(
        @dni nvarchar(50),
        @nombre nvarchar(50),
        @apellido nvarchar(50),
        @fecha_de_nacimiento nvarchar(50),
        @equipo nvarchar(50)
)       
AS
BEGIN transaction
        
        DECLARE @instruccion nvarchar(1024)
        DECLARE @consulta nvarchar(500)        
        DECLARE @from nvarchar(500)
		DECLARE @where nvarchar(100)
		DECLARE @condiciones nvarchar(500)
		
		SET @consulta = 'SELECT Jugador.id as Id, Jugador.dni as Dni,Jugador.nombre as Nombre, Jugador.apellido as Apellido,Jugador.fecha_de_nacimiento as 'Fecha de Nacimiento', Equipo.nombre as Equipo, Jugador.amarillas as 'Tarjetas Amarillas', Jugador.rojas as 'TarjetasRojas''
		SET @from = ' FROM LigaBA.Jugador as Jugador INNER JOIN LigaBA.JugadorXEquipo as JugadorXEquipo ON Jugador.id = JugadorXEquipo.jugador INNER JOIN LigaBA.Equipo ON JugadorXEquipo.equipo = Equipo.id'
		SET @where = ' WHERE '
		SET @condiciones = ''
		
		IF(@dni != '')
		BEGIN
			SET @condiciones = @condiciones + ' Jugador.dni = ' + @dni
		END				
		
		IF(@nombre != '')
		BEGIN
			IF(@condiciones != '')
			BEGIN
				SET @condiciones = @condiciones + ' AND '
			END
			SET @condiciones = @condiciones + ' Jugador.nombre LIKE ''' + @nombre + ''''
		END				
		
		IF(@apellido != '')
		BEGIN
			IF(@condiciones != '')
			BEGIN
				SET @condiciones = @condiciones + ' AND '
			END
			SET @condiciones = @condiciones + ' Jugador.apellido LIKE ''' + @apellido + ''''
		END	
		
		IF(@fecha_de_nacimiento != '')
		BEGIN
			IF(@condiciones != '')
			BEGIN
				SET @condiciones = @condiciones + ' AND '
			END
			SET @condiciones = @condiciones + ' Jugador.fecha_de_nacimiento = ''' + @fecha_de_nacimiento + ''''
		END	
		
		IF(@equipo != '')
		BEGIN
			IF(@condiciones != '')
			BEGIN
				SET @condiciones = @condiciones + ' AND '
			END
			SET @condiciones = @condiciones + ' Equipo.id = ' + @equipo
		END
		
		IF(@condiciones = '')
			BEGIN
				SET @instruccion = @consulta + @from
			END
		ELSE
			BEGIN
				SET @instruccion = @consulta + @from + @where + @condiciones
			END
		exec(@instruccion)
COMMIT

GO

--execute LigaBA.p_BuscarJugador '','','','',''

--MODIFICAR JUGADOR
CREATE PROCEDURE [LigaBA].[p_ModificarJugador]
(
        @id nvarchar(50),
        @dni nvarchar(50),
        @dni_anterior nvarchar(50),
        @nombre nvarchar(50),
        @apellido nvarchar(50),
        @fecha_de_nacimiento nvarchar(50)        
)       
AS
BEGIN transaction
               
        IF @dni != @dni_anterior AND EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE dni = @dni)
        BEGIN
                RAISERROR ('El dni que intenta cambiar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END  
                      
        UPDATE LigaBA.Jugador SET dni=@dni, nombre=@nombre, apellido=@apellido, fecha_de_nacimiento=@fecha_de_nacimiento WHERE id = @id                                      

COMMIT

GO


--BAJA JUGADOR
CREATE PROCEDURE [LigaBA].[p_BajaJugador]
(        
        @id nvarchar(50)
)       
AS
BEGIN transaction
        
        IF NOT(EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE id = @id))
        BEGIN
                RAISERROR ('El jugador que intenta borrar no existe.',16,1)
                ROLLBACK
                RETURN          
        END                

        UPDATE LigaBA.Jugador SET borrado=1 WHERE id=@id

       -- NO BORRAMOS JUGADORXEQUIPO --

COMMIT

GO

--ALTA TIPO DE TORNEO
CREATE PROCEDURE [LigaBA].[p_AltaTipoDeTorneo]
(
        @nombre nvarchar(50)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.TipoDeTorneo WHERE nombre = @nombre)
        BEGIN
                RAISERROR ('El tipo de torneo que intenta agregar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END
        
        INSERT INTO LigaBA.TipoDeTorneo(nombre) VALUES (@nombre)

COMMIT

GO

--BAJA TIPO DE TORNEO
CREATE PROCEDURE [LigaBA].[p_BajaTipoDeTorneo]
(
        @id nvarchar(50)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Torneo WHERE tipodetorneo = @id)
        BEGIN
                RAISERROR ('No puede eliminar este tipo de torneo por que existe al menos un torneo con este tipo.',16,1)
                ROLLBACK
                RETURN          
        END                
        
        DELETE FROM LigaBA.TipoDeTorneo WHERE id=@id

COMMIT

GO

--MODIFICAR TIPO DE TORNEO
CREATE PROCEDURE [LigaBA].[p_ModificarTipoDeTorneo]
(
        @id nvarchar(50),
        @nombre nvarchar(50)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.TipoDeTorneo WHERE nombre = @nombre)
        BEGIN
                RAISERROR ('Ya existe un tipo de torneo con ese nombre,el  no pudo tipo de torneo no puedo ser modificado.',16,1)
                ROLLBACK
                RETURN          
        END
        
        UPDATE LigaBA.TipoDeTorneo SET nombre=@nombre where id = @id

COMMIT

GO

--ALTA EQUIPO
CREATE PROCEDURE [LigaBA].[p_AltaEquipo]
(
        @nombre nvarchar(100),
        @institucion int,
        @categoria int
)
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE nombre = @nombre AND categoria = @categoria)
        BEGIN
                RAISERROR ('No se puede guardar el equipo porque ya existe un equipo con ese nombre y categoria.',16,1)
                ROLLBACK
                RETURN          
        END
        
        INSERT INTO LigaBA.Equipo (nombre,institucion,categoria)
        VALUES (@nombre,@institucion,@categoria)

COMMIT

GO

--BAJA EQUIPO
CREATE PROCEDURE [LigaBA].[p_BajaEquipo]
(        
        @id int
)       
AS
BEGIN transaction
        
IF EXISTS(SELECT 1 FROM LigaBA.Partido WHERE goleslocal=-1 AND 
equipolocal IN (SELECT id FROM LigaBA.Equipo WHERE institucion =@id) OR  
equipovisitante IN (SELECT id FROM LigaBA.Equipo WHERE institucion =@id))
BEGIN
                RAISERROR ('No puede eliminar el equipo porque participa en torneos que aun no han finalizado.',16,1)
                ROLLBACK
                RETURN  
END              

        --ACTUALIZAR JUGADOR
        UPDATE LigaBA.Jugador SET borrado=1 WHERE id IN 
        (SELECT JXE.jugador FROM LigaBA.JugadorXEquipo AS JXE WHERE JXE.equipo=@id)

        --ACTUALIZAR EQUIPO
        UPDATE LigaBA.Equipo borrado=1 WHERE id=@id

COMMIT

GO


--MODIFICAR EQUIPO
CREATE PROCEDURE [LigaBA].[p_ModificarEquipo]
(
        @id int,        
        @nombre nvarchar(100),
        @categoria int,
        @institucion int
)
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE nombre = @nombre AND categoria = @categoria AND institucion=@institucion )
        BEGIN
                RAISERROR ('No se puede modificar el equipo porque ya existe un equipo con ese nombre y categoria.',16,1)
                ROLLBACK
                RETURN          
        END
        
        UPDATE LigaBA.Equipo SET nombre=@nombre WHERE id=@id

COMMIT

--ALTA INSTITUCION
CREATE PROCEDURE [LigaBA].[p_AltaInstitucion]
(
        @nombre nvarchar(100),
        @direccion nvarchar(300),
        @localidad nvarchar(300),
        @telefono nvarchar(100),
        @email nvarchar(100),
        @delegado nvarchar(100),
        @coordinador nvarchar(100)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Institucion WHERE nombre = @nombre)
        BEGIN
                RAISERROR ('Ya existe una institucion con ese nombre.',16,1)
                ROLLBACK
                RETURN          
        END
        
        INSERT INTO LigaBA.Institucion (nombre,direccion,localidad,telefono,email,delegado,coordinador)
        VALUES (@nombre,@direccion,@localidad,@telefono,@email,@delegado,@coordinador)

COMMIT
GO

--BAJA INSTITUCION
CREATE PROCEDURE [LigaBA].[p_BajaInstitucion]
(
        @id int
)       
AS
BEGIN transaction

IF EXISTS(SELECT 1 FROM LigaBA.Partido WHERE goleslocal IS NULL AND 
equipolocal IN (SELECT id FROM LigaBA.Equipo WHERE institucion =@id) OR  
equipovisitante IN (SELECT id FROM LigaBA.Equipo WHERE institucion =@id))
BEGIN
                RAISERROR ('No puede eliminar la institucion porque esta posee equipos que participan en torneos que aun no han finalizado.',16,1)
                ROLLBACK
                RETURN  
END

        --ACTUALIZO JUGADOR
        UPDATE LigaBA.Jugador SET borrado=1 WHERE id IN 
                (SELECT JXE.jugador FROM LigaBA.JugadorXEquipo AS JXE WHERE JXE.equipo IN 
                        (SELECT E.id FROM LigaBA.Equipo AS E WHERE institucion = @id)
                ) 

        --ACTUALIZO EQUIPO
        UPDATE LigaBA.Equipo SET borrado=1 WHERE institucion=@id

        --ACTUALIZO INSTITUCION
        UPDATE LigaBA.Institucion SET borrado=1 WHERE id=@id

COMMIT

GO


--MODIFICAR INSTITUCION
CREATE PROCEDURE [LigaBA].[p_ModificarInstitucion]
(
        @id int,
        @nombre nvarchar(100),
        @direccion nvarchar(300),
        @localidad nvarchar(300),
        @telefono nvarchar(100),
        @email nvarchar(100),
        @delegado nvarchar(100),
        @coordinador nvarchar(100)
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Institucion WHERE nombre = @nombre)
        BEGIN
                RAISERROR ('Ya existe una institucion con ese nombre.',16,1)
                ROLLBACK
                RETURN          
        END
        

        UPDATE LigaBA.Institucion SET nombre=@nombre,direccion=@direccion,localidad=@localidad,
        telefono=@telefono,email=@email,delegado=@delegado,coordinador=@coordinador
        WHERE id=@id

COMMIT


--FUNCIONES

--NOMBRE INSTITUCION
CREATE FUNCTION [LigaBA].[f_NombreInstitucion] 
(
        @id int
)
RETURNS nvarchar(100)
AS
BEGIN
        DECLARE @nombre nvarchar(100)
        
        SELECT @nombre=nombre FROM LigaBA.Institucion WHERE id = @id
        return @nombre

END

GO

--NOMBRE CATEGORIA
CREATE FUNCTION [LigaBA].[f_NombreCategoria] 
(
        @id int
)
RETURNS nvarchar(100)
AS
BEGIN
        DECLARE @nombre nvarchar(100)
        
        SELECT @nombre=nombre FROM LigaBA.Categoria WHERE id = @id
        return @nombre

END

GO