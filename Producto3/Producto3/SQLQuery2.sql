/*----------------CLIENTE--------------------------------------------*/

-- Insertar tres registros en la tabla Cliente
INSERT INTO Cliente (cNombre, cApellido1, cApellido2, cEdad, cPais, cCiudad, cCalle, cZipcode, cTipocliente)
VALUES
    ('Juan', 'P�rez', 'Gonz�lez', 30, 'M�xico', 'Ciudad de M�xico', 'Calle 123', '12345', 'Normal'),
    ('Ana', 'L�pez', 'Mart�nez', 25, 'Espa�a', 'Madrid', 'Calle 456', '54321', 'VIP'),
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


/*---------------------PARA HABITACI�N-------------------------------*/


-- Insertar tres registros en la tabla ServicioHabitacion
INSERT INTO ServicioHabitacion (nombre, descripcion)
VALUES
    ('Servicio 1', 'Descripci�n del Servicio 1'),
    ('Servicio 2', 'Descripci�n del Servicio 2'),
    ('Servicio 3', 'Descripci�n del Servicio 3');

-- Insertar tres registros en la tabla EstadoHabitacion
INSERT INTO EstadoHabitacion (nombre)
VALUES
    ('Disponible'),
    ('Ocupada'),
    ('Mantenimiento');

-- Insertar tres registros en la tabla Pension--------------------------
INSERT INTO Pension (nombre, descripcion)
VALUES
    ('Pensi�n Completa', 'Todas las comidas incluidas'),
    ('Media Pensi�n', 'Desayuno y cena incluidos'),
    ('Sin Pensi�n', 'Sin comidas incluidas');

-- Insertar tres registros en la tabla Temporada------------------------------
INSERT INTO Temporada (nombre, fecha_inicio, fecha_fin)
VALUES
    ('Temporada Alta', '2023-07-01', '2023-08-31'),
    ('Temporada Media', '2023-05-01', '2023-06-30'),
    ('Temporada Baja', '2023-01-01', '2023-04-30');

-- Insertar tres registros en la tabla Habitacion----------------------------
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado_id, temporada_id, servicio_id, pension_id)
VALUES
    (101, 'Doble', 2, 150.00, 1, 1, 1, 1), -- Ejemplo de habitaci�n con estado Disponible, Temporada Alta, Servicio 1 y Pensi�n Completa
    (102, 'Individual', 1, 100.00, 2, 2, 2, 2), -- Ejemplo de habitaci�n con estado Ocupada, Temporada Media, Servicio 2 y Media Pensi�n
    (103, 'Doble', 2, 160.00, 1, 3, 3, 3); -- Ejemplo de habitaci�n con estado Disponible, Temporada Baja, Servicio 3 y Sin Pensi�n
/*---------------------FIN HABITACI�N-------------------------------*/


/*---------------------PARA SERVICIOS-------------------------------*/
-- Insertar registros en la tabla Servicio
INSERT INTO Servicio (nombre, descripcion, precio)
VALUES
    ('Lavander�a', 'Lavado y planchado de ropa', 25.00),
    ('Paseo de Perro', 'Paseo diario para su mascota', 15.00),
    ('Entradas a Espect�culos', 'Reserva de entradas a espect�culos locales', 40.00),
    ('Servicio de Taxi', 'Transporte en taxi al aeropuerto', 30.00),
    ('Limpieza de Habitaci�n', 'Limpieza y orden en su habitaci�n', 20.00),
    ('Servicio de Habitaci�n', 'Comida y bebidas en la habitaci�n', 18.00);
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
    H.idHabitacion AS 'ID Habitaci�n',
    H.numero AS 'N�mero de Habitaci�n',
    H.tipo AS 'Tipo de Habitaci�n',
    H.capacidad AS 'Capacidad',
    H.precio AS 'Precio por Noche',
    EH.nombre AS 'Estado de la Habitaci�n',
    T.nombre AS 'Temporada',
    SH.nombre AS 'Servicio de Habitaci�n',
    P.nombre AS 'Pensi�n'
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
    U.uCorreo_electronico AS 'Correo Electr�nico del Usuario',
    H.numero AS 'N�mero de Habitaci�n',
    SH.nombre AS 'Servicio de Habitaci�n',
    R.fecha_inicio AS 'Fecha de Inicio',
    R.fecha_fin AS 'Fecha de Fin',
    R.total AS 'Total de la Reserva',
    F.numero_factura AS 'N�mero de Factura',
    F.fecha_emision AS 'Fecha de Emisi�n de Factura',
    F.total AS 'Total de la Factura'
FROM
    Reserva AS R
INNER JOIN UsuarioLogin AS U ON R.idUsuario_id = U.idUsuario
INNER JOIN Habitacion AS H ON R.idHabitacion_id = H.idHabitacion
INNER JOIN ServicioHabitacion AS SH ON H.servicio_id = SH.idServicioHabitacion
LEFT JOIN Factura AS F ON R.idReserva = F.idReserva_id;


















