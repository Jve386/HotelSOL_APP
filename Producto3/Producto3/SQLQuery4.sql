CREATE DATABASE HotelSol_4
use HotelSol_03

-- Insertar datos ficticios en la tabla Cliente
INSERT INTO Cliente (cNombre, cApellido1, cApellido2, cEdad, cPais, cCiudad, cCalle, cZipcode, cCorreoElectronico, cTipoCliente)
VALUES
('Juan', 'Gómez', 'Pérez', 35, 'España', 'Madrid', 'Calle Gran Vía 123', '28001', 'juan@gmail.com', 'Regular'),
('María', 'Martínez', 'López', 28, 'España', 'Barcelona', 'Calle Diagonal 456', '08001', 'maria@hotmail.com', 'Premium'),
('Luis', 'Fernández', 'García', 45, 'España', 'Sevilla', 'Calle Sierpes 789', '41001', 'luis@yahoo.com', 'Regular'),
('Ana', 'Rodríguez', 'Díaz', 32, 'España', 'Valencia', 'Calle Mayor 101', '46001', 'ana@gmail.com', 'Premium'),
('Carlos', 'López', 'Sánchez', 40, 'España', 'Bilbao', 'Calle Gran Bilbao 567', '48001', 'carlos@hotmail.com', 'Regular');

-- Insertar datos ficticios en la tabla UsuarioLogin
INSERT INTO UsuarioLogin (uCorreo_electronico, uContrasena, nivelUsuario)
VALUES
    ('javi@hotelsol.com', 'contrasena1', 1),  -- Asociado al primer usuario
    ('Cristina@hotelsol.com', 'contrasena2', 2),   -- Asociado al segundo usuario
    ('israel@hotelsol.com', 'contrasena3', 1), -- Asociado al tercer usuario
	('roger@hotelsol.com', 'contrasena4', 2), -- Asociado al cuarto usuario
	('javier@hotelsol.com', 'contrasena5', 2); -- Asociado al quinto usuario




-- Insertar datos en la tabla ServicioHabitacion
INSERT INTO ServicioHabitacion (nombre, descripcion, opcion1, opcion2, opcion3, opcion4, opcion5, opcion6, opcion7)
VALUES
('nombre1', 'Individual', 'jacuzzi', 'tv', 'secador', 'aireAcondicionado', 'caja fuerte', 'balcon', 'Cama normal'),
('nombre2', 'Doble', 'bañera', 'tv', 'secador', 'aireAcondicionado', 'caja fuerte', 'balcon', 'Cama doble'),
('nombre3', 'De luxe', 'jacuzzi', 'tv', 'secador', 'aireAcondicionado', 'caja fuerte', 'balcon', 'Cama extragrande');


--Inserto datos de Habitacion
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado, servicio_id, pension_id)
VALUES 
(101, 'Doble', 2, 150.00, 'Disponible', 1, 1),
(102, 'Individual', 1, 100.00, 'Ocupada', 2, 2),
(103, 'Doble', 2, 150.00, 'Mantenimiento', 1, 1);



-- Insertar datos ficticios en la tabla Pension
INSERT INTO Pension (nombre, descripcion)
VALUES 
('Pensión Completa', 'Todas las comidas incluidas'),
('Media Pensión', 'Desayuno y cena incluidos'),
('Solo Alojamiento', 'Solo la habitación sin comidas incluidas');


-- Insertar datos ficticios en la tabla Habitacion con claves foráneas
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado, servicio_id, pension_id)
VALUES 
(101, 'Doble', 2, 150.00, 1, 1, 1),
(102, 'Individual', 1, 100.00, 1, 2, 2),
(103, 'Doble', 2, 150.00, 1, 1, 1);

-- Insertar datos ficticios en la tabla Servicio

INSERT INTO Servicio (nombre, descripcion, precio)
VALUES
('Servicio 1', 'Paseo perro', 50.00),
('Servicio 2', 'Masaje', 75.00),
('Servicio 3', 'Taxi', 100.00),
('Servicio 4', 'Excursión', 120.00),
('Servicio 5', 'Entradas', 80.00),
('Servicio 6', 'Otros', 60.00);
INSERT INTO Factura (numero_factura, fecha_emision, totalFactura, idReserva_id)
VALUES
(1001, '2023-07-21', 300.00, 1),
(1002, '2023-08-16', 400.00, 2),
(1003, '2023-09-11', 500.00, 3);

--DBCC CHECKIDENT ('Reserva', RESEED, 0);

-- Insertar datos ficticios en la tabla Reserva
INSERT INTO Reserva (idUsuario_id, cIdCliente_id, idHabitacion_id, idServicio_id, fecha_inicio, fecha_fin, total, temporada, pension)
VALUES
(1, 1, 1, 1,'2023-07-15', '2023-07-20', 300.00, 1, 'Pensión Completa'),
(2, 2,  2, 2,'2023-08-10', '2023-08-15', 400.00, 2, 'Media Pensión'),
(3, 3,  3, 3,'2023-09-05', '2023-09-10', 500.00, 3, 'Solo Alojamiento');

select *From Habitacion;
UPDATE Habitacion
SET estado = 'Disponible'
WHERE estado = '1';

UPDATE Habitacion
SET estado = 'Ocupada'
WHERE estado = '2';

UPDATE Habitacion
SET estado = 'Mantenimiento'
WHERE estado = '3';
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado, servicio_id, pension_id)
VALUES 
(101, 'Doble', 2, 150.00, 'Disponible', 1, 1),
(102, 'Individual', 1, 100.00, 'Ocupada', 2, 2),
(103, 'Doble', 2, 150.00, 'Mantenimiento', 1, 1);
-- Insertar datos ficticios en la tabla Factura

