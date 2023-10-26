
/* PARA BORRAR LA DATABASE ENTERA Y HACER PRUEBAS
use master;
DROP DATABASE HotelSOL;*/


use HotelSOL;


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

