/*----------------CLIENTE--------------------------------------------*/

-- Insertar tres registros en la tabla Cliente
INSERT INTO Cliente (cNombre, cApellido1, cApellido2, cEdad, cPais, cCiudad, cCalle, cZipcode, cTipocliente)
VALUES
    ('Juan', 'Pérez', 'González', 30, 'México', 'Ciudad de México', 'Calle 123', '12345', 'Normal'),
    ('Ana', 'López', 'Martínez', 25, 'España', 'Madrid', 'Calle 456', '54321', 'VIP'),
    ('Robert', 'Smith', 'Johnson', 40, 'Estados Unidos', 'Nueva York', 'Street 789', '67890', 'Regular');
/*----------------FIN CLIENTE--------------------------------------------*/

/*----------------USUARIO--------------------------------------------*/

-- Insertar tres registros en la tabla UsuarioLogin
INSERT INTO UsuarioLogin (uCorreo_electronico, uContrasena, cIdCliente)
VALUES
    ('juan@example.com', 'contrasena1', 1),  -- Asociado al primer cliente
    ('ana@example.com', 'contrasena2', 2),   -- Asociado al segundo cliente
    ('robert@example.com', 'contrasena3', 3); -- Asociado al tercer cliente
/*----------------FIN USUARIO--------------------------------------------*/


/*---------------------PARA HABITACIÓN-------------------------------*/


-- Insertar tres registros en la tabla ServicioHabitacion
INSERT INTO ServicioHabitacion (nombre, descripcion)
VALUES
    ('Servicio 1', 'Descripción del Servicio 1'),
    ('Servicio 2', 'Descripción del Servicio 2'),
    ('Servicio 3', 'Descripción del Servicio 3');

-- Insertar tres registros en la tabla EstadoHabitacion
INSERT INTO EstadoHabitacion (nombre)
VALUES
    ('Disponible'),
    ('Ocupada'),
    ('Mantenimiento');

-- Insertar tres registros en la tabla Pension--------------------------
INSERT INTO Pension (nombre, descripcion)
VALUES
    ('Pensión Completa', 'Todas las comidas incluidas'),
    ('Media Pensión', 'Desayuno y cena incluidos'),
    ('Sin Pensión', 'Sin comidas incluidas');

-- Insertar tres registros en la tabla Temporada------------------------------
INSERT INTO Temporada (nombre, fecha_inicio, fecha_fin)
VALUES
    ('Temporada Alta', '2023-07-01', '2023-08-31'),
    ('Temporada Media', '2023-05-01', '2023-06-30'),
    ('Temporada Baja', '2023-01-01', '2023-04-30');

-- Insertar tres registros en la tabla Habitacion----------------------------
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado_id, temporada_id, servicio_id, pension_id)
VALUES
    (101, 'Doble', 2, 150.00, 1, 1, 1, 1), -- Ejemplo de habitación con estado Disponible, Temporada Alta, Servicio 1 y Pensión Completa
    (102, 'Individual', 1, 100.00, 2, 2, 2, 2), -- Ejemplo de habitación con estado Ocupada, Temporada Media, Servicio 2 y Media Pensión
    (103, 'Doble', 2, 160.00, 1, 3, 3, 3); -- Ejemplo de habitación con estado Disponible, Temporada Baja, Servicio 3 y Sin Pensión
/*---------------------FIN HABITACIÓN-------------------------------*/


/*---------------------PARA SERVICIOS-------------------------------*/
-- Insertar registros en la tabla Servicio
INSERT INTO Servicio (nombre, descripcion, precio)
VALUES
    ('Lavandería', 'Lavado y planchado de ropa', 25.00),
    ('Paseo de Perro', 'Paseo diario para su mascota', 15.00),
    ('Entradas a Espectáculos', 'Reserva de entradas a espectáculos locales', 40.00),
    ('Servicio de Taxi', 'Transporte en taxi al aeropuerto', 30.00),
    ('Limpieza de Habitación', 'Limpieza y orden en su habitación', 20.00),
    ('Servicio de Habitación', 'Comida y bebidas en la habitación', 18.00);
/*---------------------FIN SERVICIOS-------------------------------*/


/*-----------------------RESERVA---------------------------------------------*/
-- Insertar 10 registros en la tabla Reserva
INSERT INTO Reserva (idUsuario_id, idHabitacion_id, idServicio_id, fecha_inicio, fecha_fin, total)
VALUES
    (1, 1, 1, '2023-07-15', '2023-07-20', 600.00),
    (2, 2, 2, '2023-08-10', '2023-08-15', 500.00),
    (3, 3, 3, '2023-09-05', '2023-09-10', 700.00);
/*-----------------------FIN RESERVA---------------------------------------------*/


/*-----------------------Factura---------------------------------------------*/

-- Insertar 3 registros en la tabla Factura
INSERT INTO Factura (numero_factura, fecha_emision, total, idReserva_id)
VALUES
    (1001, '2023-07-20', 600.00, 1),  -- Asociado a la reserva con id 1
    (1002, '2023-08-15', 500.00, 2),  -- Asociado a la reserva con id 2
    (1003, '2023-09-10', 700.00, 3);  -- Asociado a la reserva con id 3
/*-----------------------Factura---------------------------------------------*/
/*-----------------------FIN---------------------------------------------*/


/*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*/
/*------------------SELECT PARA COMPROBAR---------------------------------------------------------*/
/*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*/

SELECT * from Reserva;
SELECT * from Cliente;
SELECT * from EstadoHabitacion;
SELECT * from Factura;
SELECT * from Habitacion;
SELECT * from Pension;
SELECT * from Servicio;
SELECT * from ServicioHabitacion;
SELECT * from Temporada;
SELECT * from UsuarioLogin;




/*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*/
/*                        informacion de la habitacion              */
/*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*/



SELECT
    H.idHabitacion AS 'ID Habitación',
    H.numero AS 'Número de Habitación',
    H.tipo AS 'Tipo de Habitación',
    H.capacidad AS 'Capacidad',
    H.precio AS 'Precio por Noche',
    EH.nombre AS 'Estado de la Habitación',
    T.nombre AS 'Temporada',
    SH.nombre AS 'Servicio de Habitación',
    P.nombre AS 'Pensión'
FROM
    Habitacion AS H
INNER JOIN EstadoHabitacion AS EH ON H.estado_id = EH.idEstadoHabitacion
INNER JOIN Temporada AS T ON H.temporada_id = T.idTemporada
INNER JOIN ServicioHabitacion AS SH ON H.servicio_id = SH.idServicioHabitacion
INNER JOIN Pension AS P ON H.pension_id = P.idPension;





/*---------------------------------------------------------------------------*/
/*                        informacion de la Reserva              */
/*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*/




SELECT
    R.idReserva AS 'ID Reserva',
    U.uCorreo_electronico AS 'Correo Electrónico del Usuario',
    H.numero AS 'Número de Habitación',
    SH.nombre AS 'Servicio de Habitación',
    R.fecha_inicio AS 'Fecha de Inicio',
    R.fecha_fin AS 'Fecha de Fin',
    R.total AS 'Total de la Reserva',
    F.numero_factura AS 'Número de Factura',
    F.fecha_emision AS 'Fecha de Emisión de Factura',
    F.total AS 'Total de la Factura'
FROM
    Reserva AS R
INNER JOIN UsuarioLogin AS U ON R.idUsuario_id = U.idUsuario
INNER JOIN Habitacion AS H ON R.idHabitacion_id = H.idHabitacion
INNER JOIN ServicioHabitacion AS SH ON H.servicio_id = SH.idServicioHabitacion
LEFT JOIN Factura AS F ON R.idReserva = F.idReserva_id;


















