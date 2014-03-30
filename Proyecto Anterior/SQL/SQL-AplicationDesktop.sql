
-- %% ENCABEZADO %%

USE AplicationDesktop
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

CREATE SCHEMA ingeniAR AUTHORIZATION Luciano;
GO

-- CREATE TYPES

--USUARIOS
CREATE TABLE ingeniAR.Usuarios(
        username varchar(50) NOT NULL,
        password varchar(64) NOT NULL,
        usuario_intentos_fallidos SMALLINT DEFAULT 0,
        estado bit NOT NULL DEFAULT 1,
 
 CONSTRAINT PK_Usuarios PRIMARY KEY(username)
 );

GO


--FUNCIONALIDADES

CREATE TABLE ingeniAR.Funcionalidades(
        id numeric(18, 0) NOT NULL,
        nombre varchar(50) NOT NULL,

        CONSTRAINT PK_Funcionalidades PRIMARY KEY (id)
);

GO

--FUNCIONALIDADES X USUARIO

CREATE TABLE ingeniAR.FuncionalidadXUsuario(
        username varchar(50) NOT NULL,
        id_funcionalidad numeric(18, 0) NOT NULL,

        CONSTRAINT PK_FuncionalidadXUsuario PRIMARY KEY (username,id_funcionalidad),
        CONSTRAINT FK_FuncionalidadXUsuario_Usuario FOREIGN KEY (username) REFERENCES ingeniAR.Usuarios(username),
        CONSTRAINT FK_FuncionalidadXUsuario_Funcionalidad FOREIGN KEY (id_funcionalidad) REFERENCES ingeniAR.Funcionalidades(id)

);

GO

--CLIENTE

CREATE TABLE ingeniAR.Cliente(
        codigo numeric(18, 0) NOT NULL IDENTITY,
        razon_social nvarchar(100) NOT NULL,
		telefono numeric(18, 0),
		direccion nvarchar(255),
		email nvarchar(100),
		estado bit NOT NULL DEFAULT 1,
		
        CONSTRAINT PK_Cliente PRIMARY KEY (codigo)
);

GO

--FACTURA

CREATE TABLE ingeniAR.Factura(
        numero numeric(18, 0) NOT NULL IDENTITY,
        fecha date NOT NULL,
		cliente numeric(18, 0) NOT NULL,
		total decimal(12,2) NOT NULL,
		
        CONSTRAINT PK_Factura PRIMARY KEY (numero),
		CONSTRAINT FK_Factura_Cliente FOREIGN KEY (cliente) REFERENCES ingeniAR.Cliente(codigo),
);

GO

--PRODUCTO

CREATE TABLE ingeniAR.Producto(
        codigo numeric(18, 0) NOT NULL IDENTITY,
        nombre nvarchar(255) NOT NULL,
        detalle nvarchar(1024) NOT NULL,
        estado bit NOT NULL DEFAULT 1,
        
        CONSTRAINT PK_Producto PRIMARY KEY (codigo),
);

GO

--PRODUCTOXCLIENTE

CREATE TABLE ingeniAR.ProductoXCliente(
        codigo_producto numeric(18, 0) NOT NULL,
        codigo_cliente numeric(18, 0) NOT NULL,
        precio decimal(12,2) NOT NULL,
             
        CONSTRAINT PK_ProductoXCliente PRIMARY KEY (codigo_producto,codigo_cliente),
		CONSTRAINT FK_ProductoXCliente_Cliente FOREIGN KEY (codigo_cliente) REFERENCES ingeniAR.Cliente(codigo),
		CONSTRAINT FK_ProductoXCliente_Producto FOREIGN KEY (codigo_producto) REFERENCES ingeniAR.Producto(codigo),
);

GO

--ITEM_FACTURA

CREATE TABLE ingeniAR.Item_Factura(
        item_numero numeric(18, 0) NOT NULL,
        fact_numero numeric(18, 0) NOT NULL,
        producto numeric(18, 0) NOT NULL,
        cantidad numeric(18,0) NOT NULL,
        precio decimal(12,2) NOT NULL,
		
        CONSTRAINT PK_Item_Factura PRIMARY KEY (item_numero,fact_numero),
		CONSTRAINT FK_Item_Factura_Factura FOREIGN KEY (fact_numero) REFERENCES ingeniAR.Factura(numero),
		CONSTRAINT FK_Item_Factura_Producto FOREIGN KEY (producto) REFERENCES ingeniAR.Producto(codigo),
);

GO

--CREAR USUARIO

INSERT INTO ingeniAR.Usuarios (username,password,usuario_intentos_fallidos) VALUES ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',0)
--

--CREAR FUNCIONALIDADES
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(1,'Alta Usuario')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(3,'Baja Usuario')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(2,'Modificar Usuario')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(4,'Alta Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(6,'Baja Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(5,'Modificar Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(7,'Asignar Producto Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(8,'Baja Producto Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(9,'Modificar Precio Producto Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(10,'Visualizar Productos Cliente')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(11,'Alta Producto') 
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(12,'Baja Producto')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(13,'Modificar Producto')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(14,'Alta Factura')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(15,'Baja Factura')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(16,'Modificar Factura')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(17,'Visualizar Factura')
INSERT INTO ingeniAR.Funcionalidades (id,nombre) VALUES(18,'Estadisticas')        
  
--
--CREAR FUNCIONALIDAD PARA ADMIN
INSERT INTO ingeniAR.FuncionalidadXUsuario (username,id_funcionalidad) VALUES ('admin',1)
INSERT INTO ingeniAR.FuncionalidadXUsuario (username,id_funcionalidad) VALUES ('admin',2)
INSERT INTO ingeniAR.FuncionalidadXUsuario (username,id_funcionalidad) VALUES ('admin',3)
--



--PROCEDURES

CREATE PROCEDURE [ingeniAR].[p_AltaCliente]
(
	@razon_social nvarchar(100),
	@direccion nvarchar(100),
	@telefono numeric(18,0),
	@email nvarchar(100)
	 
)	
AS
BEGIN transaction

IF EXISTS(SELECT * FROM ingeniAR.Cliente WHERE razon_social = @razon_social AND estado=1)
	BEGIN
		RAISERROR ('Ya existe un cliente con esa razon social.',16,1)
		ROLLBACK
		RETURN
	END

IF EXISTS(SELECT * FROM ingeniAR.Cliente WHERE razon_social = @razon_social AND estado=0)
	BEGIN		
		UPDATE ingeniAR.Cliente SET estado = 1,direccion=@direccion,telefono=@telefono,email=@email WHERE razon_social = @razon_social
		COMMIT
		RETURN
	END	



INSERT INTO ingeniAR.Cliente (razon_social,telefono,direccion,email) VALUES (@razon_social,@telefono,@direccion,@email)
	
COMMIT
GO


CREATE PROCEDURE [ingeniAR].[p_AltaFactura]
(
	@cliente numeric(18,0),
	@fecha date,
	@total decimal(12,2),
	@respuesta numeric(18,0) OUTPUT  
)	
AS
BEGIN transaction

INSERT INTO ingeniAR.Factura (fecha,cliente,total) VALUES (@fecha,@cliente,@total)

select @respuesta = @@IDENTITY
	
COMMIT
return @respuesta
GO


CREATE PROCEDURE [ingeniAR].[p_AltaFuncionalidadesXUsuario]
(
	@usuario varchar(50),
	@funcionalidad varchar(50)
)	
AS
BEGIN transaction
	
	DECLARE @id numeric(18,0)
	
	SELECT @id=id FROM ingeniAR.Funcionalidades WHERE nombre=@funcionalidad
	
	INSERT INTO ingeniAR.FuncionalidadXUsuario (username,id_funcionalidad) VALUES (@usuario,@id)
	
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_AltaItemFactura]
(
	@producto numeric(18,0),
	@cantidad numeric(18,0),
	@precio decimal(12,2),
	@item_numero numeric(18,0),
	@fact_numero numeric(18,0)  
)	
AS
BEGIN transaction

INSERT INTO ingeniAR.Item_Factura(item_numero,fact_numero,producto,cantidad,precio) VALUES (@item_numero,@fact_numero,@producto,@cantidad,@precio)

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_AltaProducto]
(
	@nombre nvarchar(255),
	@detalle nvarchar(1024)
)	
AS
BEGIN transaction

IF EXISTS(SELECT 1 FROM ingeniAR.Producto WHERE nombre = @nombre AND estado=1)
BEGIN
		RAISERROR ('No se pudo dar de alta el producto %s porque este ya existe.',16,1,@nombre)
		ROLLBACK
		RETURN	
END

IF EXISTS(SELECT 1 FROM ingeniAR.Producto WHERE nombre = @nombre AND estado=0)
BEGIN
	UPDATE ingeniAR.Producto SET estado=1 WHERE nombre=@nombre
	COMMIT
	RETURN
END

INSERT INTO ingeniAR.Producto(nombre,detalle) VALUES (@nombre,@detalle)

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_AltaUsuario]
(
	@usuario varchar(50),
	@password varchar(64)
)	
AS
BEGIN transaction
	
	IF EXISTS(SELECT * FROM ingeniAR.Usuarios WHERE username = @usuario)
	BEGIN
		RAISERROR ('El nombre de usuario que eligio ya existe.',16,1)
		ROLLBACK
		RETURN		
	END
	
	INSERT INTO ingeniAR.Usuarios (username,password,usuario_intentos_fallidos,estado) VALUES (@usuario,@password,0,1)

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_AsignarProductoCliente]
(
	@cliente nvarchar(100), 
	@producto nvarchar(255),
	@precio decimal(12,2)
)	
AS
BEGIN transaction

IF EXISTS(SELECT 1 FROM ingeniAR.ProductoXCliente WHERE codigo_producto=ingeniAR.f_CodigoProducto(@producto) AND codigo_cliente=ingeniAR.f_CodigoCliente (@cliente))
BEGIN
	RAISERROR ('No se pudo asignar el producto %s para el cliente %s porque este ya posee ese producto.',16,1,@producto,@cliente)
	ROLLBACK
	RETURN	
END

INSERT INTO ingeniAR.ProductoXCliente(codigo_producto,codigo_cliente,precio) VALUES (ingeniAR.f_CodigoProducto(@producto),ingeniAR.f_CodigoCliente (@cliente),@precio)

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaCliente]
(
	@razon_social nvarchar(100)
)
AS
BEGIN transaction

DELETE FROM ingeniAR.ProductoXCliente
WHERE codigo_cliente=ingeniAR.f_CodigoCliente(@razon_social) 

UPDATE ingeniAR.Cliente SET estado=0 WHERE razon_social = @razon_social

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaFactura]
(
	@numero numeric(18,0) 
)	
AS
BEGIN transaction

DELETE ingeniAR.Item_Factura WHERE fact_numero = @numero

DELETE ingeniAR.Factura WHERE numero=@numero 

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaFuncionalidadXUsuario]
(
	@usuario varchar(50)
)	
AS
BEGIN transaction
	
	DELETE FROM ingeniAR.FuncionalidadXUsuario WHERE username=@usuario
	
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaItemFactura]
(
	@fact_numero numeric(18,0) 
)	
AS
BEGIN transaction

DELETE ingeniAR.Item_Factura WHERE fact_numero = @fact_numero

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaProducto]
(
	@codigo numeric(18,0)
)
AS
BEGIN transaction

DELETE FROM ingeniAR.ProductoXCliente
WHERE codigo_producto=@codigo 

IF NOT EXISTS(SELECT 1 FROM ingeniAR.ProductoXCliente WHERE codigo_producto=@codigo)
BEGIN
	UPDATE ingeniAR.Producto SET estado=0 WHERE codigo=@codigo
END
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaProductoCliente]
(
	@clienteid numeric(18,0),
	@productoid numeric(18,0)
)
AS
BEGIN transaction

DELETE FROM ingeniAR.ProductoXCliente
WHERE codigo_producto=@productoid AND codigo_cliente=@clienteid 

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaUsuario]
(
	@usuario varchar(50)
)	
AS
BEGIN transaction
	
DELETE FROM ingeniAR.FuncionalidadXUsuario WHERE username=@usuario

DELETE FROM ingeniAR.Usuarios WHERE username=@usuario

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_BajaUsuario]
(
	@usuario varchar(50)
)	
AS
BEGIN transaction
	
DELETE FROM ingeniAR.FuncionalidadXUsuario WHERE username=@usuario

DELETE FROM ingeniAR.Usuarios WHERE username=@usuario

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ConsultarCliente]
(
	@Cod_Cliente numeric(18,0)
)	
AS
BEGIN transaction
	SELECT direccion,telefono FROM ingeniar.Cliente WHERE codigo=@Cod_Cliente
	
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ConsultarFuncionalidadesXUsuario]
(
	@usuario varchar(50)
)	
AS
BEGIN transaction
	
SELECT distinct(F.nombre),CASE 
         WHEN (SELECT Count(*) FROM ingeniAR.FuncionalidadXUsuario WHERE username=@usuario and id_funcionalidad=F.id) = 1 THEN 'true'
         WHEN (SELECT Count(*) FROM ingeniAR.FuncionalidadXUsuario WHERE username=@usuario and id_funcionalidad=F.id) = 0 THEN 'false'
		END as Permiso 
FROM ingeniar.Funcionalidades as F

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ConsultarItemFactura]
(
	@numero numeric(18,0)
)	
AS
BEGIN transaction
	
	SELECT P.codigo as Codigo,P.nombre as Producto,F.precio as "Precio Unitario",F.cantidad as Cantidad,(F.cantidad * F.precio) as Importe 
	FROM ingeniAR.Factura as FA
	JOIN ingeniAR.Item_Factura as F on F.fact_numero=FA.numero
	JOIN ingeniar.Producto as P ON P.codigo=F.producto
	WHERE FA.numero=@numero
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_EstadisticasDias]
(
	@desde date,
	@hasta date 
)	
AS
BEGIN transaction

SELECT CASE
WHEN DATEPART(dw,F.fecha) = 1
then 'Lunes'
when DATEPART(dw,F.fecha) = 2
then 'Martes'
WHEN DATEPART(dw,F.fecha) = 3
then 'Miercoles'
WHEN DATEPART(dw,F.fecha) = 4
then 'Jueves'
WHEN DATEPART(dw,F.fecha) = 5
then 'Viernes'
WHEN DATEPART(dw,F.fecha) = 6
then 'Sabado'
WHEN DATEPART(dw,F.fecha) = 7
then 'Domingo'
END as Dia
,COUNT(F.fecha) as Cantidad_Ventas 

FROM ingeniAR.Factura AS F

WHERE F.fecha BETWEEN @desde AND @hasta

GROUP BY DATEPART(dw,F.fecha)

ORDER BY Cantidad_Ventas DESC

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_EstadisticasProductos]
(
	@desde date,
	@hasta date 
)	
AS
BEGIN transaction

SELECT P.nombre AS Producto,SUM(I.cantidad)Total_Comprado FROM ingeniAR.Factura as F

JOIN ingeniAR.Item_Factura as I ON I.fact_numero = F.numero

JOIN ingeniAR.Producto as P ON P.codigo = I.producto

JOIN ingeniAR.Cliente as C ON C.codigo = F.cliente

WHERE F.fecha BETWEEN @desde AND @hasta

GROUP BY P.nombre

ORDER BY Total_Comprado DESC

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_EstadisticasProductosXCliente]
(
	@desde date,
	@hasta date,
	@cliente numeric(18,0)
)	
AS
BEGIN transaction

SELECT P.nombre AS Producto,SUM(I.cantidad)Total_Comprado FROM ingeniAR.Factura as F

JOIN ingeniAR.Item_Factura as I ON I.fact_numero = F.numero

JOIN ingeniAR.Producto as P ON P.codigo = I.producto

JOIN ingeniAR.Cliente as C ON C.codigo = F.cliente

WHERE F.fecha BETWEEN @desde AND @hasta AND C.codigo=@cliente

GROUP BY P.nombre

ORDER BY Total_Comprado DESC
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_EstadisticasVentas]
(
	@desde date,
	@hasta date 
)	
AS
BEGIN transaction

SELECT C.razon_social AS Razon_Social,SUM(F.total)Total FROM ingeniAR.Factura as F

JOIN ingeniAR.Cliente as C on C.codigo=F.cliente

WHERE F.fecha BETWEEN @desde AND @hasta

GROUP BY C.razon_social

ORDER BY Total DESC

COMMIT
GO


CREATE PROCEDURE [ingeniAR].[p_login]
(
	@user_name varchar(50),
	@respuesta int output
)	
AS
BEGIN transaction
	IF NOT EXISTS( SELECT * FROM ingeniAR.Usuarios WHERE username = @user_name)
	BEGIN
		Set @respuesta = 1
		COMMIT
		return
	END
	
	IF EXISTS( SELECT * FROM ingeniAR.Usuarios WHERE username = @user_name and estado=0)
	BEGIN
		Set @respuesta = 2
		COMMIT
		return
	END
	
	IF EXISTS( SELECT * FROM ingeniAR.Usuarios WHERE username = @user_name and usuario_intentos_fallidos>=3)
	BEGIN
		Set @respuesta = 3
		COMMIT
		return
	END
	
	
	SELECT * FROM ingeniAR.Usuarios WHERE username = @user_name
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ModificarCliente]
(
	@codigo numeric(18,0),
	@razon_social nvarchar(100),
	@direccion nvarchar(100),
	@telefono numeric(18,0),
	@email nvarchar(100)
	 
)	
AS
BEGIN TRANSACTION

IF EXISTS(SELECT * FROM ingeniAR.Cliente WHERE razon_social = @razon_social AND estado=1 AND NOT codigo = @codigo)
	BEGIN
		
		RAISERROR ('Ya existe un cliente con esa razon social.',16,1)
		ROLLBACK
		RETURN
		
	END

UPDATE ingeniAR.Cliente SET razon_social = @razon_social,direccion=@direccion,telefono=@telefono,email=@email WHERE codigo=@codigo
	
COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ModificarContraseñaUsuario]
(
	@usuario varchar(50),
	@password varchar(64)
)	
AS
BEGIN transaction
	
	UPDATE ingeniAR.Usuarios SET password=@password WHERE username=@usuario 

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ModificarFactura]
(
	@numero numeric(18,0),
	@cliente numeric(18,0),
	@fecha date,
	@total decimal(12,2)
 
)	
AS
BEGIN transaction

UPDATE ingeniAR.Factura SET cliente=@cliente,fecha=@fecha,total=@total WHERE numero=@numero

COMMIT
GO


CREATE PROCEDURE [ingeniAR].[p_ModificarHabilitadoUsuario]
(
	@usuario varchar(50),
	@estado bit
)	
AS
BEGIN transaction
	
	UPDATE ingeniAR.Usuarios SET estado=@estado WHERE username=@usuario 

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ModificarPrecioProducto]
(
	@cliente nvarchar(100),
	@producto nvarchar(255),
	@precio decimal(12,2)
)	
AS
BEGIN transaction

UPDATE ingeniAR.ProductoXCliente SET precio=@precio WHERE codigo_cliente=ingeniAR.f_CodigoCliente(@cliente) 
AND codigo_producto= ingeniAR.f_CodigoProducto(@producto) 

COMMIT
GO

CREATE PROCEDURE [ingeniAR].[p_ModificarProducto]
(
	@nombre nvarchar(255),
	@detalle nvarchar(1000),
	@codigo numeric(18,0)
)	
AS
BEGIN transaction

UPDATE ingeniAR.Producto SET nombre=@nombre,detalle=@detalle WHERE codigo=@codigo

COMMIT
GO

--FUNCIONES

CREATE FUNCTION [ingeniAR].[f_CodigoCiudad] 
(
	@cliente nvarchar(100)
)
RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @codigo numeric(18,0)
	
	SELECT @codigo=codigo FROM ingeniAR.Cliente WHERE razon_social = @cliente
	return @codigo

END
GO

CREATE FUNCTION [ingeniAR].[f_CodigoCliente] 
(
	@cliente nvarchar(100)
)
RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @codigo numeric(18,0)
	
	SELECT @codigo=codigo FROM ingeniAR.Cliente WHERE razon_social = @cliente
	return @codigo

END
GO

CREATE FUNCTION [ingeniAR].[f_CodigoProducto] 
(
	@producto nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @codigo numeric(18,0)
	
	SELECT @codigo=codigo FROM ingeniAR.Producto WHERE nombre = @producto
	return @codigo

END
GO

CREATE FUNCTION [ingeniAR].[f_NombreCliente] 
(
	@codigo numeric(18,0)
)
RETURNS nvarchar(100)
AS
BEGIN
	DECLARE @nombre nvarchar(100)
	
	SELECT @nombre=razon_social FROM ingeniAR.Cliente WHERE codigo = @codigo
	return @nombre

END
GO