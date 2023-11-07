CREATE DATABASE HotelSol;

USE hotelSol;  -- Cambia a la base de datos HotelSol_01 si no estás conectado
-- Crear la tabla 'Cliente' con columna de auto incremento
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
    cTipocliente NVARCHAR(50)
);


-- Crear la tabla 'UsuarioLogin' con clave foránea a la tabla 'Cliente'
CREATE TABLE UsuarioLogin (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    uCorreo_electronico VARCHAR(255) NOT NULL,
    uContrasena VARCHAR(255) NOT NULL,
    cIdCliente INT,  -- Suponiendo que esta columna es la clave foránea a la tabla "Cliente"
    FOREIGN KEY (cIdCliente) REFERENCES Cliente(cIdCliente)  -- Asegúrate de reemplazar "Cliente" y "cIdCliente" con los nombres reales de la tabla y la columna a la que hace referencia
);



-- Crear la tabla 'ServicioHabitacion' con su clave primaria

CREATE TABLE ServicioHabitacion (
    idServicioHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255)
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

-- Crear la tabla 'Temporada' con su clave primaria
CREATE TABLE Temporada (
    idTemporada INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    fecha_inicio DATE,
    fecha_fin DATE
);

-- Crear la tabla 'Habitacion' con claves foráneas
CREATE TABLE Habitacion (
    idHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    numero INT NOT NULL,
    tipo NVARCHAR(50) NOT NULL,
    capacidad INT,
    precio DECIMAL(10, 2),
    estado_id INT,
    temporada_id INT,
    servicio_id INT,
    pension_id INT,
    FOREIGN KEY (estado_id) REFERENCES EstadoHabitacion(idEstadoHabitacion),
    FOREIGN KEY (temporada_id) REFERENCES Temporada(idTemporada),
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
    idUsuario_id INT,
    idHabitacion_id INT,
    idServicio_id INT,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    
    FOREIGN KEY (idUsuario_id) REFERENCES UsuarioLogin(idUsuario),  -- Asegúrate de que coincida con la estructura de la tabla "UsuarioLogin"
    FOREIGN KEY (idHabitacion_id) REFERENCES Habitacion(idHabitacion),  -- Asegúrate de que coincida con la estructura de la tabla "Habitacion"
    FOREIGN KEY (idServicio_id) REFERENCES Servicio(idServicios)  -- Asegúrate de que coincida con la estructura de la tabla "Servicios"
);
-- Crear la tabla 'Factura' con su clave primaria y clave foránea
CREATE TABLE Factura (
    idFactura INT IDENTITY(1,1) PRIMARY KEY,
    numero_factura INT NOT NULL,
    fecha_emision DATE NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    idReserva_id INT,  -- Supongo que esta es la clave foránea a la tabla "Reserva"
    FOREIGN KEY (idReserva_id) REFERENCES Reserva(idReserva)  -- Asegúrate de que la relación con la tabla "Reserva" sea correcta
);


