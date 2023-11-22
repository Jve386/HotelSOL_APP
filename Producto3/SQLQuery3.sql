create DATABASE HotelSol_03
use HotelSol_03;

-- Crear la tabla 'Cliente' con su clave primaria
CREATE TABLE Cliente (
    cIdCliente INT IDENTITY(1,1) PRIMARY KEY,
    cNombre NVARCHAR(255) NOT NULL,
    cApellido1 NVARCHAR(255) NOT NULL,
    cApellido2 NVARCHAR(255),
    cEdad INT,
    cPais NVARCHAR(100),
    cCiudad NVARCHAR(100),
    cCalle NVARCHAR(255),
    cZipcode NVARCHAR(20),
    cCorreoElectronico NVARCHAR(255), -- Nueva columna para el correo electrónico del cliente
    cTipoCliente NVARCHAR(50)
);



-- Crear la tabla 'UsuarioLogin' con clave foránea a la tabla 'Cliente'
CREATE TABLE UsuarioLogin (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    uCorreo_electronico VARCHAR(255) NOT NULL,
    uContrasena VARCHAR(255) NOT NULL,
    nivelUsuario INT -- Nueva columna para el nivel de usuario
);


-- Crear la tabla 'ServicioHabitacion' con su clave primaria

CREATE TABLE ServicioHabitacion (
    idServicioHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    opcion1 NVARCHAR(100),  -- Opción adicional 1
    opcion2 NVARCHAR(100),  -- Opción adicional 2
    opcion3 NVARCHAR(100),  -- Opción adicional 3
    opcion4 NVARCHAR(100),  -- Opción adicional 4
    opcion5 NVARCHAR(100),  -- Opción adicional 5
    opcion6 NVARCHAR(100),  -- Opción adicional 6
    opcion7 NVARCHAR(100)   -- Opción adicional 7
);



-- Crear la tabla 'EstadoHabitacion' con su clave primaria
CREATE TABLE EstadoHabitacion (
    idEstadoHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);
-- Elimino esta tabla porque me parece que no debe existir, debe ser un campo de reserva



-- Crear la tabla 'Pension' con su clave primaria
CREATE TABLE Pension (
    idPension INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(255)
);

-- Crear la tabla 'Habitacion' con claves foráneas
CREATE TABLE Habitacion (
    idHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    numero INT NOT NULL,
    tipo NVARCHAR(50) NOT NULL,
    capacidad INT,
    precio DECIMAL(10, 2),
    estado NVARCHAR(20)NOT NULL,
   
    servicio_id INT,
    pension_id INT,
    
    FOREIGN KEY (servicio_id) REFERENCES ServicioHabitacion(idServicioHabitacion),
    FOREIGN KEY (pension_id) REFERENCES Pension(idPension)
);


-- Actualizar la columna estado en la tabla Habitacion


-- Actualizar la columna estado en la tabla Habitacion

-- Crear la tabla 'Servicios' con su clave primaria
CREATE TABLE Servicio (
    idServicios INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    precio DECIMAL(10, 2)
);

-- Crear la tabla 'Reserva' con claves foráneas
CREATE TABLE Reserva (
    idReserva INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario_id INT, -- Cambiamos a idCliente_id o lo añadimos ?!
    cIdCliente_id INT,
    idHabitacion_id INT,
    idServicio_id INT,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
	temporada TINYINT,
	pension NVARCHAR(100) NOT NULL,
    
    FOREIGN KEY (idUsuario_id) REFERENCES UsuarioLogin(idUsuario),  -- Asegúrate de que coincida con la estructura de la tabla "UsuarioLogin"
    FOREIGN KEY (cIdCliente_id) REFERENCES Cliente(cIdCliente),
    FOREIGN KEY (idHabitacion_id) REFERENCES Habitacion(idHabitacion),  -- Asegúrate de que coincida con la estructura de la tabla "Habitacion"
    FOREIGN KEY (idServicio_id) REFERENCES Servicio(idServicios),  -- Asegúrate de que coincida con la estructura de la tabla "Servicios"
   
);
ALTER TABLE Reserva
ADD precio DECIMAL(10, 2);

UPDATE Reserva
SET precio = CASE
    WHEN temporada = 'Temporada Alta' THEN 200.00
    WHEN temporada = 'Temporada Media' THEN 150.00
    WHEN temporada = 'Temporada Baja' THEN 100.00
    ELSE 0.00  -- Puedes establecer un valor predeterminado o manejarlo según tu lógica
END;
-- Insertar datos ficticios en la tabla Habitacion con claves foráneas
INSERT INTO Habitacion (numero, tipo, capacidad, precio, estado, servicio_id, pension_id)
VALUES 
(101, 'Doble', 2, 150.00, 'Disponible', 1, 1),
(102, 'Individual', 1, 100.00, 'Disponible', 2, 2),
(103, 'Doble', 2, 150.00, 'Disponible', 1, 1);

-- Insertar datos ficticios en la tabla Reserva
INSERT INTO Reserva (idUsuario_id, cIdCliente_id, idHabitacion_id, idServicio_id, fecha_inicio, fecha_fin, total, temporada, pension, precio)
VALUES
(1, 1, 1, 1, '2023-07-15', '2023-07-20', 300.00, 'Temporada Alta', 'Pensión Completa', 200.00),
(2, 2, 2, 2, '2023-08-10', '2023-08-15', 400.00, 'Temporada Media', 'Media Pensión', 150.00),
(3, 3, 3, 3, '2023-09-05', '2023-09-10', 500.00, 'Temporada Baja', 'Solo Alojamiento', 100.00);



-- Crear la tabla 'Factura' con su clave primaria y clave foránea
CREATE TABLE Factura (
    idFactura INT IDENTITY(1,1) PRIMARY KEY,
    
    numero_factura INT NOT NULL,
    fecha_emision DATE NOT NULL,
    totalFactura DECIMAL(10, 2) NOT NULL,
    idReserva_id INT,  -- Supongo que esta es la clave foránea a la tabla "Reserva"
    
    FOREIGN KEY (idReserva_id) REFERENCES Reserva(idReserva)  -- Asegúrate de que la relación con la tabla "Reserva" sea correcta


);