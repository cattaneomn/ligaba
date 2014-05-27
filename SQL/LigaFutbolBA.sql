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
        dni int NOT NULL,
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
        tablageneral nvarchar(2) NOT NULL,
        tipodetablageneral nvarchar(100),
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
 CONSTRAINT Unique_TorneoXCategoriaXEquipo UNIQUE(torneoxcategoria,equipo),
 CONSTRAINT FK_TorneoXCategoriaXEquipo_TorneoXCategoria FOREIGN KEY (torneoxcategoria) REFERENCES LigaBA.TorneoXCategoria(id),
 CONSTRAINT FK_TorneoXCategoriaXEquipo_Equipo FOREIGN KEY (equipo) REFERENCES LigaBA.Equipo(id),
 );

GO

--TORNEOXCATEGORIAXJUGADOR
CREATE TABLE LigaBA.TorneoXCategoriaXJugador(
        id int NOT NULL IDENTITY,
        torneoxcategoria int NOT NULL,
        jugador int NOT NULL,
        amarillas int NOT NULL DEFAULT 0,
        rojas int NOT NULL DEFAULT 0,
        amarillasacumuladas int NOT NULL DEFAULT 0,
        rojasacumuladas int NOT NULL DEFAULT 0,
        habilitado bit NOT NULL DEFAULT 1
 CONSTRAINT PK_TorneoXCategoriaXJugador PRIMARY KEY(id),
 CONSTRAINT Unique_TorneoXCategoriaXJugador UNIQUE(torneoxcategoria,jugador),
 CONSTRAINT FK_TorneoXCategoriaXJugador_TorneoXCategoria FOREIGN KEY (torneoxcategoria) REFERENCES LigaBA.TorneoXCategoria(id),
 CONSTRAINT FK_TorneoXCategoriaXJugador_Jugador FOREIGN KEY (jugador) REFERENCES LigaBA.Jugador(id),
 );

 GO


--PARTIDOS
CREATE TABLE LigaBA.Partido(
        id int NOT NULL IDENTITY,
        equipolocal int NOT NULL,
        equipovisitante int NOT NULL,
        fecha int NOT NULL,
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

--PARTIDOXJUGADOR
CREATE TABLE LigaBA.PartidoXJugador(
        partido int NOT NULL,
        jugador int NOT NULL,
        equipo int NOT NULL,
        goles int DEFAULT 0,
        amarillas int DEFAULT 0,
        rojas int DEFAULT 0,
 CONSTRAINT PK_PartidoXJugador PRIMARY KEY(partido,jugador),
 CONSTRAINT FK_PartidoXJugador_Partido FOREIGN KEY (partido) REFERENCES LigaBA.Partido(id),
 CONSTRAINT FK_PartidoXJugador_Jugador FOREIGN KEY (jugador) REFERENCES LigaBA.jugador(id),
 );

GO

--CREAR USUARIO

INSERT INTO LigaBA.Usuarios (username,password) VALUES ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')

GO

--CREAR INSTITUCION LIBRE
SET IDENTITY_INSERT ligaba.Institucion ON

INSERT INTO ligaba.Institucion(id,nombre,borrado) 
VALUES (0,'Libre',1)

SET IDENTITY_INSERT ligaba.Institucion OFF

GO

--CREAR CATEGORIA LIBRE
SET IDENTITY_INSERT ligaba.Categoria ON

INSERT INTO ligaba.Categoria(id,nombre,borrado) 
VALUES (0,'Libre',1)

SET IDENTITY_INSERT ligaba.Categoria OFF

GO

--CREAR EQUIPO LIBRE
SET IDENTITY_INSERT ligaba.Equipo ON

INSERT INTO ligaba.Equipo(id, nombre,institucion,categoria,borrado) 
VALUES (0,'Libre',0,0,1)

SET IDENTITY_INSERT ligaba.Equipo OFF

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
                ROLLBACK
                RETURN
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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Categoria WHERE nombre = @categoria AND borrado=0)
        BEGIN
                RAISERROR ('La categoria que intenta agregar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END
        
        DECLARE @id int
        
        IF EXISTS(SELECT id=@id FROM LigaBA.Categoria WHERE nombre = @categoria AND borrado=1)
        BEGIN               
                UPDATE LigaBA.Categoria SET borrado=0,nombre = @categoria WHERE id = @id                                                                              
        END 
        ELSE
        BEGIN
            INSERT INTO LigaBA.Categoria(nombre) VALUES (@categoria)
        END
        
        

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
        
        UPDATE LigaBA.Categoria SET borrado=1 WHERE id=@Id

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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE  dni = @dni AND borrado=0) AND EXISTS(SELECT 1 FROM LigaBA.Jugador AS J INNER JOIN LigaBA.JugadorXEquipo AS JXE ON J.id = JXE.jugador WHERE J.dni = @dni AND JXE.equipo=@equipo AND J.borrado = 0)
        BEGIN
                RAISERROR ('El jugador que intenta agregar ya existe en ese equipo.',16,1)
                ROLLBACK
                RETURN          
        END                
        
        declare @id int
        
        IF EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE  dni = @dni AND borrado=1) AND EXISTS(SELECT 1 FROM LigaBA.Jugador AS J INNER JOIN LigaBA.JugadorXEquipo AS JXE ON J.id = JXE.jugador WHERE J.dni = @dni AND JXE.equipo=@equipo AND J.borrado = 1)
        BEGIN   
                SELECT @id=id FROM LigaBA.Jugador WHERE dni = @dni AND borrado=1

                UPDATE LigaBA.Jugador SET borrado=0,dni=@dni, nombre=@nombre, apellido=@apellido, fecha_de_nacimiento=@fecha_de_nacimiento 
                WHERE id = @id 
                
                IF NOT(EXISTS(SELECT 1 FROM LigaBA.JugadorXEquipo WHERE jugador = @id AND equipo = @equipo)) 
                BEGIN
                    INSERT INTO LigaBA.JugadorXEquipo(jugador,equipo) VALUES (@id,@equipo)
                END     
                
                --Si el equipo esta jugando en algun torneo se agrga el jugador al torneo x categoria
                IF(exists(SELECT 1 from LigaBA.TorneoXCategoriaXEquipo as TCE WHERE TCE.equipo=@equipo))
                BEGIN           
                    INSERT INTO LigaBA.TorneoXCategoriaXJugador
                    SELECT TCE.torneoxcategoria,@id,0,0,0,0,1 
                    from LigaBA.TorneoXCategoriaXEquipo as TCE
                    WHERE equipo=@equipo
                    AND NOT(EXISTS
                    (SELECT 1 FROM LigaBA.TorneoXCategoriaXJugador AS TJ 
                    WHERE TJ.jugador=@id AND TJ.torneoxcategoria=TCE.torneoxcategoria))
                    --Si ya esta no lo crea(caso del jugador borrado)
                END
                                                    
        END 
        ELSE
        BEGIN
            DECLARE @jugador int
            INSERT INTO LigaBA.Jugador(dni,nombre,apellido,fecha_de_nacimiento ) VALUES (@dni,@nombre,@apellido,@fecha_de_nacimiento)
            
            SELECT @jugador = SCOPE_IDENTITY()
            
            INSERT INTO LigaBA.JugadorXEquipo(jugador,equipo) VALUES (@jugador,@equipo)
            
            --Si el equipo esta jugando en algun torneo se agrga el jugador al torneo x categoria
            IF(exists(SELECT 1 from LigaBA.TorneoXCategoriaXEquipo WHERE equipo=@equipo))
            BEGIN           
                INSERT INTO LigaBA.TorneoXCategoriaXJugador
                SELECT TCE.torneoxcategoria,@jugador,0,0,0,0,1 
                from LigaBA.TorneoXCategoriaXEquipo as TCE
                WHERE equipo=@equipo
                AND NOT(EXISTS
                (SELECT 1 FROM LigaBA.TorneoXCategoriaXJugador AS TJ 
                WHERE TJ.jugador=@jugador AND TJ.torneoxcategoria=TCE.torneoxcategoria))
                --Si ya esta no lo crea(caso del jugador borrado)
            END
            
        END
COMMIT
GO


GO
--BUSCAR JUGADOR
CREATE PROCEDURE [LigaBA].[p_BuscarJugador]
(
        @dni nvarchar(50),
        @nombre nvarchar(50),
        @apellido nvarchar(50),
        @fecha_de_nacimiento nvarchar(50),
        @institucion nvarchar(50),
        @categoria nvarchar(50),
        @equipo nvarchar(50),
        @habilitado nvarchar(50)
)       
AS
BEGIN transaction
        
        DECLARE @instruccion nvarchar(1024)
        DECLARE @consulta nvarchar(500)        
        DECLARE @from nvarchar(500)
        DECLARE @where nvarchar(100)
        DECLARE @condiciones nvarchar(500)
        
        SET @consulta = 'SELECT Jugador.id as Id, Jugador.dni as Dni,Jugador.nombre as Nombre, Jugador.apellido as Apellido,Jugador.fecha_de_nacimiento as '''+'Fecha de Nacimiento'+''',Institucion.nombre as Institucion, Categoria.nombre as Categoria, Equipo.nombre as Equipo, Jugador.habilitado as Habilitado '
        SET @from = ' FROM LigaBA.Jugador as Jugador INNER JOIN LigaBA.JugadorXEquipo as JugadorXEquipo ON Jugador.id = JugadorXEquipo.jugador INNER JOIN LigaBA.Equipo ON JugadorXEquipo.equipo = Equipo.id INNER JOIN LigaBA.Institucion as Institucion ON Institucion.id = Equipo.institucion INNER JOIN LigaBA.Categoria as Categoria ON Categoria.id = Equipo.categoria'
        SET @where = ' WHERE '
        SET @condiciones = 'Jugador.borrado = 0 AND Jugador.habilitado = ' + @habilitado
        
        IF(@dni != '')
        BEGIN
            IF(@condiciones != '')
            BEGIN
                SET @condiciones = @condiciones + ' AND '
            END
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
        
        IF(@categoria != '')
        BEGIN
            IF(@condiciones != '')
            BEGIN
                SET @condiciones = @condiciones + ' AND '
            END
            SET @condiciones = @condiciones + ' Categoria.id = ' + @categoria
        END
        
        IF(@institucion != '')
        BEGIN
            IF(@condiciones != '')
            BEGIN
                SET @condiciones = @condiciones + ' AND '
            END
            SET @condiciones = @condiciones + ' Institucion.id = ' + @institucion
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

--execute LigaBA.p_BuscarJugador '','','','','','','','0'

--MODIFICAR JUGADOR
CREATE PROCEDURE [LigaBA].[p_ModificarJugador]
(
        @id int,
        @dni nvarchar(50),
        @dni_anterior nvarchar(50),
        @nombre nvarchar(50),
        @apellido nvarchar(50),
        @fecha_de_nacimiento nvarchar(50),
        @equipo int,
        @habilitado int 
)       
AS
BEGIN transaction
               
        IF @dni != @dni_anterior AND EXISTS(SELECT 1 FROM LigaBA.Jugador WHERE dni = @dni)
        BEGIN
                RAISERROR ('El dni que intenta cambiar ya existe.',16,1)
                ROLLBACK
                RETURN          
        END  
                      
        UPDATE LigaBA.Jugador SET dni=@dni, nombre=@nombre, apellido=@apellido, fecha_de_nacimiento=@fecha_de_nacimiento, habilitado = @habilitado WHERE id = @id     
        
        UPDATE LigaBA.JugadorXEquipo SET equipo=@equipo WHERE jugador = @id                               

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
        
        IF EXISTS(SELECT 1 FROM LigaBA.TipoDeTorneo WHERE nombre = @nombre and id!=@id)
        BEGIN
                RAISERROR ('Ya existe un tipo de torneo con ese nombre,el tipo de torneo no pudo ser modificado.',16,1)
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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE nombre = @nombre AND categoria = @categoria AND borrado=0)
        BEGIN
                RAISERROR ('No se puede guardar el equipo porque ya existe un equipo con ese nombre y categoria.',16,1)
                ROLLBACK
                RETURN          
        END
        
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE nombre = @nombre AND borrado=1)
        BEGIN   
                
                UPDATE LigaBA.Equipo SET borrado=0,nombre=@nombre,institucion=@institucion,
                categoria=@categoria WHERE id = (SELECT TOP 1 id FROM LigaBA.Equipo WHERE nombre = @nombre AND borrado=1)  

        END
        ELSE
        BEGIN
                INSERT INTO LigaBA.Equipo (nombre,institucion,categoria)
                VALUES (@nombre,@institucion,@categoria)
        END
COMMIT

GO

--BAJA EQUIPO
CREATE PROCEDURE [LigaBA].[p_BajaEquipo]
(        
        @id int
)       
AS
BEGIN transaction
        
IF EXISTS(SELECT 1 FROM LigaBA.TorneoXCategoriaXEquipo WHERE  
equipo = @id)
BEGIN
                RAISERROR ('No puede eliminar el equipo porque participa en al menos un torneo.',16,1)
                ROLLBACK
                RETURN  
END              

        --ACTUALIZAR JUGADOR
        UPDATE LigaBA.Jugador SET borrado=1 WHERE id IN 
        (SELECT JXE.jugador FROM LigaBA.JugadorXEquipo AS JXE WHERE JXE.equipo=@id)

        --ACTUALIZAR EQUIPO
        UPDATE LigaBA.Equipo SET borrado=1 WHERE id=@id

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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Equipo WHERE nombre = @nombre AND categoria = @categoria AND institucion=@institucion AND id!=@id )
        BEGIN
                RAISERROR ('No se puede modificar el equipo porque ya existe un equipo con ese nombre y categoria.',16,1)
                ROLLBACK
                RETURN          
        END
        
        UPDATE LigaBA.Equipo SET nombre=@nombre WHERE id=@id

COMMIT
GO
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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Institucion WHERE nombre = @nombre AND borrado=0)
        BEGIN
                RAISERROR ('No puede guardar la institucion por que ya existe una institucion con ese nombre.',16,1)
                ROLLBACK
                RETURN          
        END
        
     

        IF EXISTS(SELECT 1 FROM LigaBA.Institucion WHERE nombre = @nombre AND borrado=1)
        BEGIN   
                UPDATE LigaBA.Institucion SET borrado=0,nombre=@nombre,direccion=@direccion,
                localidad=@localidad,telefono=@telefono,email=@email,delegado=@delegado,
                coordinador=@coordinador WHERE id = (SELECT TOP 1 id FROM LigaBA.Institucion WHERE nombre = @nombre AND borrado=1)  

        END 
        ELSE
        BEGIN

                INSERT INTO LigaBA.Institucion (nombre,direccion,localidad,telefono,email,delegado,coordinador)
                VALUES (@nombre,@direccion,@localidad,@telefono,@email,@delegado,@coordinador)
        END
COMMIT
GO

--BAJA INSTITUCION
CREATE PROCEDURE [LigaBA].[p_BajaInstitucion]
(
        @id int
)       
AS
BEGIN transaction

IF EXISTS(SELECT 1 FROM LigaBA.TorneoXCategoriaXEquipo WHERE  
equipo IN (SELECT id FROM LigaBA.Equipo WHERE institucion =@id))
BEGIN
                RAISERROR ('No puede eliminar la institucion porque esta posee equipos que participan en torneos.',16,1)
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
        
        IF EXISTS(SELECT 1 FROM LigaBA.Institucion WHERE nombre = @nombre AND id!=@id)
        BEGIN
                RAISERROR ('Ya existe una institucion con ese nombre.',16,1)
                ROLLBACK
                RETURN          
        END
        

        UPDATE LigaBA.Institucion SET nombre=@nombre,direccion=@direccion,localidad=@localidad,
        telefono=@telefono,email=@email,delegado=@delegado,coordinador=@coordinador
        WHERE id=@id

COMMIT
GO

--FUNCIONES

--NOMBRE EQUIPO
CREATE FUNCTION [LigaBA].[f_NombreEquipo] 
(
       @id int
)
RETURNS nvarchar(100)
AS
BEGIN
       DECLARE @nombre nvarchar(100)
       
       SELECT @nombre=nombre FROM LigaBA.Equipo WHERE id = @id
       return @nombre

END
GO

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

--ALTA TORNEO
CREATE PROCEDURE [LigaBA].[p_AltaTorneo]
(
        @nombre nvarchar(300),
        @tipodetorneo int,
        @tablageneral nvarchar(2),
        @tipodetablageneral nvarchar(100),
        @respuesta int OUTPUT 
)       
AS
BEGIN transaction
        
        IF EXISTS(SELECT 1 FROM LigaBA.Torneo WHERE nombre = @nombre)
        BEGIN
                RAISERROR ('No se pudo crear el torneo por que ya existe un torneo con ese nombre.',16,1)
                ROLLBACK
                SET @respuesta = -1
                RETURN @respuesta         
        END
        
        --Torneo        
        INSERT INTO LigaBA.Torneo(nombre,tipodetorneo,tablageneral,tipodetablageneral) 
        VALUES (@nombre,@tipodetorneo,@tablageneral,@tipodetablageneral)
        

        select @respuesta = @@IDENTITY
    
COMMIT

return @respuesta

GO

--ALTA TORNEOXCATEGORIA
CREATE PROCEDURE [LigaBA].[p_AltaTorneoXCategoria]
(
        @torneogeneral int,
        @categoria int,
        @respuesta int OUTPUT
)       
AS
BEGIN transaction

        --TorneoXCategoria
        INSERT INTO LigaBA.TorneoXCategoria(torneogeneral,categoria) 
        VALUES (@torneogeneral,@categoria)

        select @respuesta = @@IDENTITY
    
COMMIT

return @respuesta

GO

--ALTA TORNEOXCATEGORIAXEQUIPO
CREATE PROCEDURE [LigaBA].[p_AltaTorneoXCategoriaXEquipo]
(
        @torneoxcategoria int,
        @equipo int
)       
AS
BEGIN transaction

        --TorneoXCategoriaXEquipo
        INSERT INTO LigaBA.TorneoXCategoriaXEquipo(torneoxcategoria,equipo) 
        VALUES (@torneoxcategoria,@equipo)

COMMIT
GO

--ALTA TORNEOXCATEGORIAXJUGADOR
CREATE PROCEDURE [LigaBA].[p_AltaTorneoXCategoriaXJugador]
(
        @torneoxcategoria int,
        @equipo int
)       
AS
BEGIN transaction

        --TorneoXCategoriaXJugador
        INSERT INTO LigaBA.TorneoXCategoriaXJugador (torneoxcategoria,jugador)
        SELECT @torneoxcategoria,J.id FROM LigaBA.JugadorXEquipo as JXE
        JOIN LigaBA.Jugador as J ON J.id=JXE.jugador
        WHERE JXE.equipo=@equipo AND J.habilitado=1 AND J.borrado=0
COMMIT

GO


--BAJA TORNEO
CREATE PROCEDURE [LigaBA].[p_BajaTorneo]
(
        @id int,
        @idTC int
)       
AS
BEGIN transaction
                      
        --BORRAR TORNEOXCATEGORIAXJUGADOR
        DELETE FROM LigaBA.TorneoXCategoriaXJugador WHERE torneoxcategoria=@idTC
        --BORRAR TORNEOXCATEGORIAXEQUIPO
        DELETE FROM LigaBA.TorneoXCategoriaXEquipo WHERE torneoxcategoria=@idTC
        --BORRAR PARTIDOSXJUGADOR
        DELETE FROM LigaBA.PartidoXJugador WHERE partido IN (SELECT id FROM LigaBA.Partido WHERE torneoxcategoria=@idTC)
        --BORRAR PARTIDOS
        DELETE FROM LigaBA.Partido WHERE torneoxcategoria=@idTC
        --BORRAR TORNEOXCATEGORIA  
        DELETE FROM LigaBA.TorneoXCategoria WHERE id=@idTC   

        
        --SINO HAY MAS TORNEOSXCATEGORIA DE ESE TORNEO BORRA TORNEOGENERAL
        IF( (SELECT COUNT(*) FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@id) = 0)
        BEGIN 
            DELETE FROM LigaBA.Torneo WHERE id=@id
        END


COMMIT

GO

--REPORTE INSTITUCIONES

CREATE PROCEDURE [LigaBA].[p_ReporteInstituciones]
(
        @TorneoXCategoria int
)       
AS
BEGIN transaction
        
         SELECT nombre as Nombre,direccion as Direccion,localidad as Localidad,telefono as Telefono,email as Email,delegado as Delegado,coordinador as Coordinador 
         FROM LigaBA.Institucion 
         WHERE id IN (SELECT (SELECT institucion from LigaBA.Equipo as E where E.id=TCE.equipo) FROM LigaBA.TorneoXCategoriaXEquipo as TCE WHERE torneoxcategoria=@TorneoXCategoria)

COMMIT

GO

--REPORTE JUGADORES
CREATE PROCEDURE [LigaBA].[p_ReporteJugadores]
(
        @Equipo int
)       
AS
BEGIN transaction        
        SELECT nombre as Nombre,apellido as Apellido,dni as Dni,fecha_de_nacimiento as Fecha_De_Nacimiento
        FROM LigaBA.Jugador
        WHERE id IN (SELECT jugador FROM LigaBA.JugadorXEquipo WHERE equipo=@Equipo)
        
COMMIT
GO

--INSERTAR PARTIDO
CREATE PROCEDURE [LigaBA].[p_InsertarPartido]
(
        @TorneoXCategoria int,
        @Fecha int,
        @Local int,
        @Visitante int
)       
AS
BEGIN transaction

        INSERT INTO LigaBA.Partido(equipolocal,equipovisitante,fecha,torneoxcategoria) 
        VALUES (@Local,@Visitante,@Fecha,@TorneoXCategoria)

COMMIT
GO

--BUSCAR PARTIDOS
CREATE PROCEDURE [LigaBA].[p_BuscarPartidos]
(
        @Torneo int,
        @Categoria int,
        @Fecha int
)       
AS
BEGIN transaction

        DECLARE @TorneoXCategoria int
        DECLARE @consulta nvarchar(1024)  
        
        SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo AND categoria=@Categoria
        
        SET @consulta= ('SELECT P.equipolocal as LocalId,P.equipovisitante as VisitanteId,P.id,P.fecha as Fecha,LigaBA.f_NombreEquipo(P.equipolocal) as Local,
        CASE 
          WHEN P.goleslocal >= 0 THEN (CAST(P.goleslocal as nvarchar(10)) + '' - '' + CAST(P.golesvisiante as nvarchar(10))) 
          WHEN P.goleslocal  < 0 THEN '' - ''   
        END as Resultado,
        LigaBA.f_NombreEquipo(P.equipovisitante) as Visitante 
        FROM LigaBA.Partido as P
        WHERE P.torneoxcategoria=' + CAST(@TorneoXCategoria as nvarchar(100)))
        
        IF (@Fecha != -1)
        BEGIN 
             SET @consulta = @consulta + ' AND P.fecha =' + CAST(@Fecha as nvarchar(10))
        END
        
        exec(@Consulta)

COMMIT

GO


--BUSCAR FIXTURE
CREATE PROCEDURE [LigaBA].[p_BuscarFixture]
(
        @Torneo int,
        @Categoria int,
        @Fecha int,
        @Equipo int
)       
AS
BEGIN transaction

        DECLARE @TorneoXCategoria int
        DECLARE @consulta nvarchar(1024)  
        
        SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo AND categoria=@Categoria
        
        SET @consulta= ('SELECT P.equipolocal as LocalId,P.equipovisitante as VisitanteId,P.id,P.fecha as Fecha,LigaBA.f_NombreEquipo(P.equipolocal) as Local,'+'''vs'''+' as Vs,
        LigaBA.f_NombreEquipo(P.equipovisitante) as Visitante 
        FROM LigaBA.Partido as P
        WHERE P.torneoxcategoria=' + CAST(@TorneoXCategoria as nvarchar(100))) 
        
        IF(@Fecha != '')
        BEGIN
			SET @consulta = @consulta + ' AND P.fecha = ''' + CAST(@Fecha as nvarchar(100)) + ''''
		END
		
		IF(@Equipo != '')
        BEGIN
			SET @consulta = @consulta + ' AND (P.equipolocal = ' + CAST(@Equipo as nvarchar(100))
			SET @consulta = @consulta + ' OR P.equipovisitante = ' + CAST(@Equipo as nvarchar(100)) +')'
		END
		
		SET @consulta = @consulta + ' ORDER BY P.fecha'
		print(@consulta)
        
        exec(@Consulta)

COMMIT

--execute LigaBA.p_BuscarFixture 1,1,1,null

GO

--MOSTRAR FIXTURE
CREATE PROCEDURE [LigaBA].[p_MostrarFixture]
(
        @Torneo int,
        @Categoria int        
)       
AS
BEGIN transaction

        DECLARE @TorneoXCategoria int
        DECLARE @consulta nvarchar(1024)  
        
        SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo AND categoria=@Categoria
        
        SET @consulta= ('SELECT P.fecha as Fecha,LigaBA.f_NombreEquipo(P.equipolocal) as Local,'+'''Vs'''+' as vs,
        LigaBA.f_NombreEquipo(P.equipovisitante) as Visitante 
        FROM LigaBA.Partido as P
        WHERE P.torneoxcategoria=' + CAST(@TorneoXCategoria as nvarchar(100)))        
        
        exec(@Consulta)

COMMIT

GO
--MODIFICAR LOCALIA FIXTURE
CREATE PROCEDURE [LigaBA].[p_ModificarLocalia]
(
        @partido nvarchar(50),
        @equipolocal nvarchar(50),
        @equipovisitante nvarchar(50)            
)       
AS
BEGIN transaction
                                             
        UPDATE LigaBA.Partido SET equipolocal=@equipolocal, equipovisitante=@equipovisitante WHERE id = @partido                                     

COMMIT

GO

--ALTA PARTIDOXJUGADOR
CREATE PROCEDURE [LigaBA].[p_AltaPartidoXJugador]
(
        @idPartido int,
        @idJugador int,
        @idEquipo int,
        @cantGoles int,
        @cantAmarillas int,
        @cantRojas int
)       
AS
BEGIN transaction

     INSERT INTO LigaBA.PartidoXJugador (partido,jugador,equipo,goles,amarillas,rojas) VALUES
     (@idPartido,@idJugador,@idEquipo,@cantGoles,@cantAmarillas,@cantRojas)

    --SUMAR TARJETAS A JUGADOR
    --MODIFICAR TORNEOXCATEGORIAXJUGADOR
    UPDATE LigaBA.TorneoXCategoriaXJugador SET 
    amarillas=@cantAmarillas,rojas=@cantRojas,
    amarillasacumuladas= amarillasacumuladas + @cantAmarillas,rojasacumuladas= rojasacumuladas + @cantRojas
    WHERE Jugador=@idJugador AND TorneoXCategoria=(SELECT TorneoXCategoria FROM LigaBA.Partido WHERE id=@idPartido)


COMMIT
GO

--MODIFICAR PARTIDOXJUGADOR
CREATE PROCEDURE [LigaBA].[p_ModificarPartidoXJugador]
(
        @idPartido int
)
AS
BEGIN transaction

--RESTAR AMARILLAS Y ROJAS
UPDATE LigaBA.TorneoXCategoriaXJugador 
	SET 
	amarillas =  amarillas - (SELECT PJA.amarillas FROM LigaBA.PartidoXJugador AS PJA WHERE PJA.partido = @idPartido AND PJA.jugador = TorneoXCategoriaXJugador.jugador),  
	amarillasacumuladas =  amarillasacumuladas - (SELECT PJA.amarillas FROM LigaBA.PartidoXJugador AS PJA WHERE PJA.partido = @idPartido AND PJA.jugador = TorneoXCategoriaXJugador.jugador),
	rojas =  rojas - (SELECT PJA.rojas FROM LigaBA.PartidoXJugador AS PJA WHERE PJA.partido = @idPartido AND PJA.jugador = TorneoXCategoriaXJugador.jugador),
	rojasacumuladas =  rojasacumuladas - (SELECT PJA.rojas FROM LigaBA.PartidoXJugador AS PJA WHERE PJA.partido = @idPartido AND PJA.jugador = TorneoXCategoriaXJugador.jugador)
	
	WHERE torneoxcategoria = (SELECT TOP 1 P.torneoxcategoria FROM LigaBA.Partido AS P WHERE id = @idPartido) AND TorneoXCategoriaXJugador.jugador IN (SELECT PJ.jugador FROM LigaBA.PartidoXJugador PJ WHERE PJ.partido = @idPartido)
	
DELETE FROM LigaBA.PartidoXJugador WHERE partido=@idPartido

COMMIT
GO

--JUGAR PARTIDO
CREATE PROCEDURE [LigaBA].[p_JugarPartido]
(
        @idPartido int,
        @golesLocal int,
        @golesVisitante int,
        @localId int,
        @visitanteId int
)       
AS
BEGIN transaction

        DECLARE @torneoXCategoria int
        
        --TORNEOXCATEGORIA QUE PERTECENE EL PARTIDO
        SET @torneoXCategoria = (SELECT TOP 1 torneoxcategoria FROM LigaBA.Partido WHERE id=@idPartido)
        
        --ACTUALIZO GOLES
        UPDATE LigaBA.Partido SET goleslocal=@golesLocal, golesvisiante=@golesVisitante
        WHERE id=@idPartido
        
        --ACTUALIZO SUSPENDIDOS AMARRILLAS
        UPDATE LigaBA.TorneoXCategoriaXJugador SET habilitado = 1,amarillas=0,rojas=0 WHERE habilitado = 0 AND amarillas >= 5
        AND (jugador IN (SELECT JE.jugador FROM LigaBA.JugadorXEquipo as JE WHERE JE.equipo= @localId) 
        OR jugador IN (SELECT JXE.jugador FROM LigaBA.JugadorXEquipo as JXE WHERE JXE.equipo= @visitanteId))
        
        --ACTUALIZO SUSPENDIDOS ROJAS
        UPDATE LigaBA.TorneoXCategoriaXJugador SET habilitado = 1,rojas=0 WHERE habilitado = 0 AND rojas >= 1 
        AND (jugador IN (SELECT JE.jugador FROM LigaBA.JugadorXEquipo as JE WHERE JE.equipo= @localId) 
        OR jugador IN (SELECT JXE.jugador FROM LigaBA.JugadorXEquipo as JXE WHERE JXE.equipo= @visitanteId))
        
        --ACTUALIZO TABLA DE POSICIONES
        IF (@golesLocal > @golesVisitante)
        BEGIN
            --GANADOR LOCAL
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1, partidosganados=partidosganados+1,
            golesafavor=golesafavor+@golesLocal, golesencontra=golesencontra+@golesVisitante,
            puntos=puntos+3
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
            
            --PERDEDOR VISITANTE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1,partidosperdidos=partidosperdidos+1,
            golesafavor=golesafavor+@golesVisitante, golesencontra=golesencontra+@golesLocal
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
        END

        IF (@golesVisitante > @golesLocal)
        BEGIN 
            --GANADOR VISITANTE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1, partidosganados=partidosganados+1,
            golesafavor=golesafavor+@golesVisitante, golesencontra=golesencontra+@golesLocal,
            puntos=puntos+3
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
            
            --PERDEDOR LOCAL
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1,partidosperdidos=partidosperdidos+1,
            golesafavor=golesafavor+@golesLocal, golesencontra=golesencontra+@golesVisitante
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
        END
        
        IF (@golesVisitante = @golesLocal)
        BEGIN
            --EMPATE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1,partidosempatados=partidosempatados+1,
            golesafavor=golesafavor+@golesLocal, golesencontra=golesencontra+@golesVisitante,
            puntos=puntos+1
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
            
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados+1,partidosempatados=partidosempatados+1,
            golesafavor=golesafavor+@golesVisitante, golesencontra=golesencontra+@golesLocal,
            puntos=puntos+1
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
        END

COMMIT
GO

--MODIFICAR PARTIDO
CREATE PROCEDURE [LigaBA].[p_ModificarPartido]
(
        @idPartido int,
        @golesLocal int,
        @golesVisitante int,
        @localId int,
        @visitanteId int
)       
AS
BEGIN transaction

        DECLARE @torneoXCategoria int
        
        --TORNEOXCATEGORIA QUE PERTECENE EL PARTIDO
        SET @torneoXCategoria = (SELECT TOP 1 torneoxcategoria FROM LigaBA.Partido WHERE id=@idPartido)
        
        
        --ACTUALIZO TABLA DE POSICIONES
        IF (@golesLocal > @golesVisitante)
        BEGIN
            --GANADOR LOCAL
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1, partidosganados=partidosganados-1,
            golesafavor=golesafavor-@golesLocal, golesencontra=golesencontra-@golesVisitante,
            puntos=puntos-3
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
            
            --PERDEDOR VISITANTE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1,partidosperdidos=partidosperdidos-1,
            golesafavor=golesafavor-@golesVisitante, golesencontra=golesencontra-@golesLocal
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
        END

        IF (@golesVisitante > @golesLocal)
        BEGIN 
            --GANADOR VISITANTE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1, partidosganados=partidosganados-1,
            golesafavor=golesafavor-@golesVisitante, golesencontra=golesencontra-@golesLocal,
            puntos=puntos-3
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
            
            --PERDEDOR LOCAL
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1,partidosperdidos=partidosperdidos-1,
            golesafavor=golesafavor-@golesLocal, golesencontra=golesencontra-@golesVisitante
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
        END
        
        IF (@golesVisitante = @golesLocal)
        BEGIN
            --EMPATE
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1,partidosempatados=partidosempatados-1,
            golesafavor=golesafavor-@golesLocal, golesencontra=golesencontra-@golesVisitante,
            puntos=puntos-1
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@localId
            
            UPDATE LigaBA.TorneoXCategoriaXEquipo SET 
            partidosjugados=partidosjugados-1,partidosempatados=partidosempatados-1,
            golesafavor=golesafavor-@golesVisitante, golesencontra=golesencontra-@golesLocal,
            puntos=puntos-1
            WHERE torneoxcategoria=@torneoXCategoria AND equipo=@visitanteId
        END

COMMIT
GO

--REPORTE FICHA PARTIDO
CREATE PROCEDURE [LigaBA].[p_ReporteFichaPartido]
(
        @Equipo int,
        @Torneo int,
        @Categoria int
)       
AS
BEGIN transaction        
    
    DECLARE @TorneoXCategoria int
        
    SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria 
    WHERE torneogeneral=@Torneo AND categoria=@Categoria

    SELECT nombre as Nombre,apellido as Apellido,dni as Dni,
    CASE TCJ.habilitado WHEN 1 THEN ' ' ELSE 'INHABILITADO' END as Habilitado
    FROM LigaBA.Jugador as J
    JOIN LigaBA.TorneoXCategoriaXJugador as TCJ ON TCJ.jugador = J.id
    WHERE J.id IN (SELECT jugador FROM LigaBA.JugadorXEquipo WHERE equipo=@Equipo) 
    AND TCJ.torneoxcategoria=@TorneoXCategoria
    
    
COMMIT
GO

--BUSCAR GOLEADORES
CREATE PROCEDURE [LigaBA].[p_BuscarGoleadores]
(
        @Torneo int,
        @Categoria int
)       
AS
BEGIN transaction

        DECLARE @TorneoXCategoria int 
        
        SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo AND categoria=@Categoria
        
        SELECT J.nombre as Nombre,J.apellido as Apellido,E.nombre as Equipo,SUM(PJ.goles) AS Goles 
        FROM LigaBA.PartidoXJugador as PJ
        JOIN LigaBA.Jugador as J ON J.id=PJ.jugador
        JOIN LigaBA.Equipo as E ON E.id=PJ.equipo
        WHERE PJ.partido IN (SELECT id FROM LigaBA.Partido WHERE torneoxcategoria=@TorneoXCategoria)
        GROUP BY E.nombre,J.nombre,J.apellido,PJ.jugador
        ORDER BY SUM(PJ.goles) DESC

COMMIT
GO


--BUSCAR POSICIONES X CATEGORIA
CREATE PROCEDURE [LigaBA].[p_BuscarPosicionesXCategoria]
(
        @Torneo int,
        @Categoria int
)       
AS
BEGIN transaction

        DECLARE @TorneoXCategoria int 
        
        SELECT @TorneoXCategoria=id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo AND categoria=@Categoria
        
        SELECT ROW_NUMBER() OVER(ORDER BY TCE.puntos DESC,(TCE.golesafavor - TCE.golesencontra) DESC) AS Pos,
        E.nombre as Equipo,TCE.partidosjugados as PJ,TCE.partidosganados as PG,TCE.partidosempatados as PE,
        TCE.partidosperdidos as PP,TCE.golesafavor as GF, TCE.golesencontra as GC,TCE.puntos as Puntos 
        FROM LigaBA.TorneoXCategoriaXEquipo as TCE
        JOIN LigaBA.Equipo as E ON E.id=TCE.equipo
        WHERE torneoxcategoria=@TorneoXCategoria

COMMIT
GO

--BUSCAR TIPO TORNEO
CREATE PROCEDURE [LigaBA].[p_BuscarTipoTorneo]
(
        @Torneo int,
        @respuesta nvarchar(100) OUTPUT
)       
AS
BEGIN transaction


        SELECT @respuesta=TDT.nombre FROM LigaBA.Torneo as T 
        JOIN LigaBA.TipoDeTorneo as TDT ON TDT.id=T.tipodetorneo
        WHERE T.id=@Torneo
        
        IF (@respuesta = 'Baby')
        BEGIN 
            SET @respuesta = 1
        END
        ELSE
        BEGIN 
            SET @respuesta = 0
        END
    
COMMIT

RETURN @respuesta

GO

--BUSCAR POSICIONES GENERALES
CREATE PROCEDURE [LigaBA].p_BuscarPosicionesGeneral
(
        @Torneo int
)       
AS
BEGIN transaction

DECLARE @tipo nvarchar(150)

		SELECT @tipo=tipodetablageneral FROM LigaBA.Torneo WHERE id = @Torneo
		
		IF(@tipo = 'Todas las categorias')
		BEGIN
			SELECT ROW_NUMBER() OVER(ORDER BY SUM(TE.puntos) DESC) AS Pos,I.nombre AS Institucion,SUM(TE.puntos) AS Puntos
			FROM LigaBA.TorneoXCategoriaXEquipo as TE
			INNER JOIN LigaBA.TorneoXCategoria AS TC ON TC.id = TE.torneoxcategoria AND TC.torneogeneral = @Torneo
			INNER JOIN LigaBA.Equipo AS E ON E.id = TE.equipo
			INNER JOIN LigaBA.Institucion AS I ON I.id = E.institucion
			GROUP BY I.nombre
		END
		
		IF(@tipo = 'Todas las categorias, exepto la menor')
		BEGIN
			SELECT ROW_NUMBER() OVER(ORDER BY SUM(TE.puntos) DESC) AS Pos,I.nombre AS Institucion,SUM(TE.puntos) AS Puntos
			FROM LigaBA.TorneoXCategoriaXEquipo as TE
			INNER JOIN LigaBA.TorneoXCategoria AS TC ON TC.id = TE.torneoxcategoria AND TC.torneogeneral = @Torneo
			INNER JOIN LigaBA.Equipo AS E ON E.id = TE.equipo
			INNER JOIN LigaBA.Institucion AS I ON I.id = E.institucion
			INNER JOIN LigaBA.Categoria AS C ON C.id = TC.categoria
			WHERE C.nombre != (SELECT MAX(C_AUX.nombre) FROM LigaBA.TorneoXCategoria as TC_AUX INNER JOIN LigaBA.Categoria AS C_AUX ON C_AUX.id = TC_AUX.categoria WHERE TC_AUX.torneogeneral = @Torneo)
			GROUP BY I.nombre
		END
		
COMMIT

GO

--REPORTE FECHA POSICIONESXCATEGORIA
CREATE PROCEDURE [LigaBA].[p_ReporteFechaPosicionesXCategoria]
(
        @Torneo int
)       
AS
BEGIN transaction

    SELECT C.nombre,ROW_NUMBER() OVER(PARTITION BY C.nombre ORDER BY TCE.puntos DESC,(TCE.golesafavor - TCE.golesencontra) DESC) AS Pos,
    E.nombre as Equipo,TCE.partidosjugados as PJ,TCE.partidosganados as PG,TCE.partidosempatados as PE,
    TCE.partidosperdidos as PP,TCE.golesafavor as GF, TCE.golesencontra as GC,TCE.puntos as Puntos 
    FROM LigaBA.TorneoXCategoriaXEquipo as TCE
    JOIN LigaBA.Equipo as E ON E.id=TCE.equipo
    JOIN LigaBA.TorneoXCategoria AS TC ON TC.id=TCE.torneoxcategoria
    JOIN LigaBA.Categoria as C ON C.id=TC.categoria
    WHERE torneoxcategoria IN (SELECT id FROM LigaBA.TorneoXCategoria WHERE torneogeneral=@Torneo)

COMMIT
GO

--CONTROL DE SUSPENCIONES
CREATE TRIGGER [LigaBA].[t_suspencion]
	ON [LigaBA].[TorneoXCategoriaXJugador]
	FOR UPDATE
AS 
	UPDATE LigaBA.TorneoXCategoriaXJugador SET habilitado = 1 WHERE habilitado = 0 AND (amarillas < 5 OR rojas = 0)
	UPDATE LigaBA.TorneoXCategoriaXJugador SET habilitado = 0 WHERE habilitado = 1 AND (amarillas >= 5 OR rojas >= 1)
;

GO