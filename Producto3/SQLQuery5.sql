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
    estado_id INT,
   
    servicio_id INT,
    pension_id INT,
    FOREIGN KEY (estado_id) REFERENCES EstadoHabitacion(idEstadoHabitacion),
    FOREIGN KEY (servicio_id) REFERENCES ServicioHabitacion(idServicioHabitacion),
    FOREIGN KEY (pension_id) REFERENCES Pension(idPension)
);

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


-- Crear la tabla 'Factura' con su clave primaria y clave foránea
CREATE TABLE Factura (
    idFactura INT IDENTITY(1,1) PRIMARY KEY,
    numero_factura INT NOT NULL,
    fecha_emision DATE NOT NULL,
    totalFactura DECIMAL(10, 2) NOT NULL,
    idReserva_id INT,  -- Supongo que esta es la clave foránea a la tabla "Reserva"
    
    FOREIGN KEY (idReserva_id) REFERENCES Reserva(idReserva)  -- Asegúrate de que la relación con la tabla "Reserva" sea correcta


);