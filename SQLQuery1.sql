use HojaPrueba;


CREATE TABLE reserva (
id_reserva integer IDENTITY(1,1) PRIMARY KEY,
id_cliente integer NOT NULL,
fecha_inicio datetime, 
fecha_fin datetime,
id_temporada integer,
metodo_pago varchar,
num_personas integer,
discapacidad bit, 
observaciones varchar,
sw_factura bit,
id_pension integer
);

CREATE TABLE cliente (
id_cliente integer IDENTITY(1,1) PRIMARY KEY,
nombre_cliente varchar,
apellido1_cliente varchar,
apellido2_cliente varchar,
edad_cliente integer,
pais_cliente varchar,
ciudad_cliente varchar,
calle_cliente varchar,
zip_code_cliente integer, 
vip bit
);

CREATE TABLE habitacion (
id_habitacion integer IDENTITY(1,1) PRIMARY KEY,
numero_habitacion integer,
id_tipo_habitacion integer,
id_estado integer,
precio_habitacion float,
discapacidad_habitacion bit 
);


CREATE TABLE estado_habitacion(
id_estado integer IDENTITY(1,1) PRIMARY KEY,
nombre_estado varchar);


CREATE TABLE tipo_habitacion (

id_tipo_habitacion integer PRIMARY KEY,
nombre_tipo varchar
);


CREATE TABLE reserva_habitacion (
id_reserva integer,
id_habitacion integer
);


CREATE TABLE tipoPension(
id_pension integer IDENTITY(1,1) PRIMARY KEY,
nombre_pension varchar(255) NOT NULL,
precio_pension float
);

CREATE TABLE tipoDescuento (
descuentoVip float
);

CREATE TABLE servicioExtra (
id_extra integer PRIMARY KEY,
nombre_extra varchar(255) NOT NULL,
precio_extra float
);


CREATE TABLE servicioReestauranteOtros(
id_servicio integer PRIMARY KEY,
id_reserva integer,
nombre_servicio varchar(255) NOT NULL,
precio_servicio float,
comentario_servicio varchar(255)
);
--Le cambio el nombre a la tabla por que esta mal escrito

EXEC sp_rename 'servicioReestauranteOtros', 'servicioRestauranteOtros';

CREATE TABLE reserva_servicioExtra (
id_servicioExtra integer IDENTITY(1,1) PRIMARY KEY,
id_reserva integer,
id_extra integer,
id_servicio integer
);

CREATE TABLE temporada(
id_temporada integer IDENTITY(1,1) PRIMARY KEY,
nombre_temporada varchar,
multiplicador_temporada float, /* para los aumnetos en porcentaje */
extra_temporada float, /* para los aumentos fijos */
fecha_inicio_temporada datetime,
fecha_fin_temporada datetime
);


CREATE TABLE usuarios (
id_usuario integer IDENTITY(1,1) PRIMARY KEY,
nombre_usuario varchar NOT NULL,
apellido1_usuario varchar,
apellido2_usuario varchar,
fecha_alta_usuario datetime NOT NULL,
fecha_baja_usuario datetime,
fecha_ultima_conexion_usuario datetime,
permisos_usuario integer NOT NULL
);

CREATE TABLE historico(
id_reserva integer NOT NULL,
id_cliente integer NOT NULL,
fecha_inicio datetime,
fecha_fin datetime,
metodo_pago varchar(255),
num_personas integer,
iva integer,
observaciones varchar(255),
sw_factura bit,
total_precio float
);

CREATE TABLE facturaEmitida(
id_factura integer IDENTITY(1,1) PRIMARY KEY,
id_reserva integer NOT NULL,
nif_facturaEmitida varchar,
import_base float,
import_liquido float,
iva_factura float,
nombreLegal varchar,
fecha_facturaEmitida datetime,
comentari_facturaEmitida varchar
);



/* ESTAS TRES NO SE UTILIZAN, SOLO SI NOS DA TIEMPO SE IMPLEMENTAN
CREATE TABLE facturaRecibidas(
id_proveedor integer, 
id_facturaRecibida integer IDENTITY(1,1) PRIMARY KEY, 
importBase float,
importLiquido float,
iva_facturaRecibida float,
fecha_facturaRecivida datetime,
comentari_facturaRecivida varchar
);
CREATE TABLE proveedor(
id_proveedor integer IDENTITY(1,1) PRIMARY KEY,
nombre_proveedor varchar,
nif_proveedor integer,
nombreLegal varchar
);
CREATE TABLE inventario(
idProducto integer PRIMARY KEY AUTO_INCREMENT,
nombreProducto varchar,
stockMin integer,
stockMax integer,
stockAct integer
);
*/

/*	AÑADIMOS LAS FOREIGN KEYS Y LAS RELACIONES	*/

ALTER TABLE reserva 
add constraint FK_reserva_cliente 
foreign key (id_cliente) references cliente(id_cliente)
ON UPDATE CASCADE; 

ALTER TABLE reserva
add constraint FK_reserva_temporada
foreign key (id_temporada) references temporada(id_temporada);

ALTER TABLE reserva_habitacion
add constraint FK_reserva_hab_reserva
foreign key (id_reserva) references reserva(id_reserva)
ON UPDATE CASCADE; 

ALTER TABLE reserva_habitacion
add constraint FK_reserva_hab_habitacion
foreign key (id_habitacion) references habitacion(id_habitacion)
ON UPDATE CASCADE; 

ALTER TABLE reserva 
add constraint FK_reserva_tipopension
foreign key (id_pension) references tipopension(id_pension);

ALTER TABLE reserva_servicioExtra
add constraint FK_reseEx_reserva
foreign key(id_reserva) references reserva(id_reserva)
ON UPDATE CASCADE; 

ALTER TABLE reserva_servicioExtra
add constraint FK_reseEx_servEx
foreign key(id_extra) references servicioExtra(id_extra)
ON UPDATE CASCADE; 

ALTER TABLE reserva_servicioExtra
add constraint FK_reseEx_servicio
foreign key(id_servicio) references servicioReestauranteOtros(id_servicio)
ON UPDATE CASCADE; 

ALTER TABLE facturaEmitida
add constraint FK_facturaEmitida_reserva
foreign key(id_reserva) references reserva(id_reserva);

ALTER TABLE historico
add constraint FK_historico_reserva
foreign key(id_reserva) references reserva(id_reserva);

ALTER TABLE habitacion
ADD CONSTRAINT FK_habitacion_tipo_habitacion
FOREIGN KEY (id_tipo_habitacion)
REFERENCES tipo_habitacion(id_tipo_habitacion);

ALTER TABLE habitacion
add constraint FK_estado_habitacion
foreign key(id_estado) references estado_habitacion(id_estado);

ALTER TABLE reserva
ADD CONSTRAINT FK_cliente_reserva
FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente);


-- Agrega una columna en la tabla reserva para la relación con tipoDescuento
ALTER TABLE reserva
ADD id_tipo_descuento integer;

ALTER TABLE tipoDescuento
ADD id_tipo_descuento integer IDENTITY(1,1) PRIMARY KEY;

-- Crea la restricción de clave foránea (foreign key constraint)
ALTER TABLE reserva
ADD CONSTRAINT FK_reserva_tipoDescuento
FOREIGN KEY (id_tipo_descuento)
REFERENCES tipoDescuento(id_tipo_descuento);


--Agregar Reserva: Un procedimiento almacenado que toma como entrada los datos necesarios para crear una nueva reserva y la inserta en la tabla de reservas.

CREATE PROCEDURE AgregarReserva
    @id_cliente INT,
    @fecha_inicio DATETIME,
    @fecha_fin DATETIME,
    @id_temporada INT,
    @metodo_pago VARCHAR(50),
    @num_personas INT,
    @discapacidad BIT,
    @observaciones VARCHAR(MAX),
    @sw_factura BIT,
    @id_pension INT
AS
BEGIN
    INSERT INTO reserva (id_cliente, fecha_inicio, fecha_fin, id_temporada, metodo_pago, num_personas, discapacidad, observaciones, sw_factura, id_pension)
    VALUES (@id_cliente, @fecha_inicio, @fecha_fin, @id_temporada, @metodo_pago, @num_personas, @discapacidad, @observaciones, @sw_factura, @id_pension);
END

--Modificar Reserva: Un procedimiento que permite actualizar los detalles de una reserva existente.

CREATE PROCEDURE ModificarReserva
    @id_reserva INT,
    @nuevos_datos...
AS
BEGIN
    -- Actualizar la reserva con los nuevos datos proporcionados
    UPDATE reserva
    SET campo1 = @nuevos_datos1, campo2 = @nuevos_datos2, ...
    WHERE id_reserva = @id_reserva;
END


--Anular Reserva: Para cancelar una reserva y liberar la habitación correspondiente.

CREATE PROCEDURE AnularReserva
    @id_reserva INT
AS
BEGIN
    -- Update nos marca la reserva como anulada
    UPDATE reserva
    SET sw_factura = 0
    WHERE id_reserva = @id_reserva;
END

--Generar Factura: Un procedimiento para generar una factura para un cliente basada en su estancia, servicios adicionales y descuentos.

CREATE PROCEDURE GenerarFactura
    @id_reserva INT
AS
BEGIN
    -- Insertar una nueva factura basada en los datos de la reserva
    INSERT INTO facturaEmitida (id_reserva, nif_facturaEmitida, importe_base, importe_liquido, iva_factura, nombreLegal, fecha_facturaEmitida, comentario_facturaEmitida)
    SELECT r.id_reserva, c.nif_cliente, r.total_precio, r.total_precio, r.iva, 
	CONCAT(c.nombre_cliente, ' ', c.apellido1_cliente), 
	GETDATE(), 'Factura generada automáticamente.'
    FROM reserva r
    INNER JOIN cliente c ON r.id_cliente = c.id_cliente
    WHERE r.id_reserva = @id_reserva;
END



--Consultar Reservas por Cliente: Para recuperar todas las reservas realizadas por un cliente en particular.

CREATE PROCEDURE ConsultarReservaPorCliente
    @id_cliente INT
AS
BEGIN
    SELECT *
    FROM reserva
    WHERE id_cliente = @id_cliente;
END
--Para consultarlo

-- Ejecutar el procedimiento ConsultarReservaPorCliente
-- Proporciona el ID del cliente como parámetro
EXEC ConsultarReservaPorCliente @id_cliente = 1; -- Reemplaza "1" con el ID del cliente deseado

--Consultar Habitaciones Disponibles: Un procedimiento que acepta fechas de inicio y fin, así como otros filtros (como tipo de habitación) y devuelve una lista de habitaciones disponibles en ese período.

CREATE PROCEDURE ConsultarHabitacionesDisponibles
    @fecha_inicio DATETIME,
    @fecha_fin DATETIME
AS
BEGIN
    SELECT h.*
    FROM habitacion h
    WHERE h.id_habitacion NOT IN (
        SELECT rh.id_habitacion
        FROM reserva_habitacion rh
        INNER JOIN reserva r ON rh.id_reserva = r.id_reserva
        WHERE (
            (@fecha_inicio >= r.fecha_inicio AND @fecha_inicio < r.fecha_fin)
            OR (@fecha_fin > r.fecha_inicio AND @fecha_fin <= r.fecha_fin)
            OR (@fecha_inicio <= r.fecha_inicio AND @fecha_fin >= r.fecha_fin)
        )
    );
END
--Para consultarlo

-- Ejecutar el procedimiento ConsultarHabitacionesDisponibles
-- Proporciona las fechas de inicio y fin como parámetros
EXEC ConsultarHabitacionesDisponibles @fecha_inicio = '2023-10-01', @fecha_fin = '2023-10-10'; -- Reemplaza las fechas con las que desees consultar

--Consultar Reservas Pendientes: Para obtener una lista de las reservas que aún no han llegado.

CREATE PROCEDURE ConsultarReservasPendientes
AS
BEGIN
    SELECT * FROM reserva WHERE sw_factura = 0;
END;

-- Ejecutar el procedimiento ConsultarReservasPendientes
EXEC ConsultarReservasPendientes;

--Registrar Llegada de Cliente: Marcar que un cliente ha llegado y su reserva está confirmada.

-- Crear el procedimiento almacenado RegistrarLlegadaCliente

CREATE PROCEDURE RegistrarLlegadaCliente
    @id_reserva INT
AS
BEGIN
    -- Actualizar el campo "sw_factura" para marcar la llegada del cliente
    UPDATE reserva SET sw_factura = 1 WHERE id_reserva = @id_reserva;
END;

-- Ejecutar el procedimiento RegistrarLlegadaCliente
-- Proporciona el ID de reserva como parámetro
EXEC RegistrarLlegadaCliente @id_reserva = 1; -- Reemplaza "1" con el ID de reserva deseado


--Consultar Facturas por Cliente: Recuperar todas las facturas de un cliente en particular.

CREATE PROCEDURE ConsultarFacturasPorCliente
    @id_cliente INT
AS
BEGIN
    SELECT * FROM facturaEmitida WHERE id_cliente = @id_cliente;
END;

-- Ejecutar el procedimiento ConsultarFacturasPorCliente
-- Proporciona el ID del cliente como parámetro
EXEC ConsultarFacturasPorCliente @id_cliente = 1; -- Reemplaza "1" con el ID de cliente deseado

--Consultar Facturas Pendientes de Pago: Obtener una lista de facturas pendientes de pago.

CREATE PROCEDURE ConsultarFacturasPendientesPago
AS
BEGIN
    SELECT * FROM facturaEmitida WHERE import_liquido > 0;
END;

-- Ejecutar el procedimiento ConsultarFacturasPendientesPago
EXEC ConsultarFacturasPendientesPago;

--Actualizar Precios por Temporada: Un procedimiento que permite al administrador actualizar los precios de las habitaciones basándose en las temporadas.

CREATE PROCEDURE ActualizarPreciosPorTemporada
    @id_temporada INT,
    @nuevo_multiplicador FLOAT,
    @nuevo_extra FLOAT
AS
BEGIN
    -- Actualizar los precios de acuerdo a la temporada
    UPDATE temporada
    SET multiplicador_temporada = @nuevo_multiplicador,
        extra_temporada = @nuevo_extra
    WHERE id_temporada = @id_temporada;
END;

-- Ejecutar el procedimiento ActualizarPreciosPorTemporada
-- Proporciona el ID de temporada, el nuevo multiplicador y el nuevo extra como parámetros
EXEC ActualizarPreciosPorTemporada @id_temporada = 1, @nuevo_multiplicador = 1.2, @nuevo_extra = 50.0;

