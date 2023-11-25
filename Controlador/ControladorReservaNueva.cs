using Modelo;
using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorReservaNueva
    {
        /// <summary>
        ///  //Llamada devuelve funcion con los clientes para la reserva todos los datos
        /// </summary> 
        /// <returns>Una lista de clientes</returns>
        public List<ClienteViewModel> GetListaClientes()
        {
            try
            {
                using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
                {
                    var listaClientes = db.Cliente
                        .Select(c => new ClienteViewModel
                        {
                            IdCliente = c.cIdCliente,
                            Nombre = c.cNombre,
                            Apellido1 = c.cApellido1,
                            Apellido2 = c.cApellido2,
                            Edad = (int)c.cEdad,
                            Pais = c.cPais,
                            Ciudad = c.cCiudad,
                            Calle = c.cCalle,
                            Zipcode = c.cZipcode,
                            CorreoElectronico =c.cCorreoElectronico,
                            TipoCliente= c.cTipoCliente
                            // Agrega más propiedades según sea necesario
                        })
                        .ToList();

                    // Asegurar que la lista no sea null
                    return listaClientes ?? new List<ClienteViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción y proporcionar un mensaje, devuelvo null
               return new List<ClienteViewModel>();
            }
        }
        /// <summary>
        /// CONTADOR PARA RESERVAS LA IDEA ES COMPROBAR LAS RESTRIGCIONES.
        /// </summary>
        /// <returns>EL NÚMERO DE RESERVAS QUE EXISTE</returns>
        public int ContadorReservas()
        {
            try
            {
                using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
                {
                    DateTime fechaActual = DateTime.Now;

                    int cantidadReservas = db.Reserva
                        .Count(r => r.fecha_inicio <= fechaActual && r.fecha_fin >= fechaActual);

                    // Devolver el contador de reservas
                    return cantidadReservas;
                }
            }
            catch (Exception ex)
            {
               
                // Puedes lanzar la excepción nuevamente o devolver un valor predeterminado según tu lógica
                return -1; // O cualquier otro valor predeterminado
            }
        }
        /// <summary>
        /// LISTA QUE DEVUELVE  LOS POSIBLES SERVICIOS PARA SELECCIONAR
        /// </summary>
        /// <returns></returns>
        public List<ModeloReservoNuevoServicio> GetListaServicios()
        {
            try
            {
                using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
                {
                    var listaServicios = db.Servicio
                        .Select(s => new ModeloReservoNuevoServicio
                        {
                            IdServicios = s.idServicios,
                            Nombre = s.nombre,
                            Descripcion = s.descripcion,
                            Precio = s.precio,
                            // Agrega más propiedades según sea necesario
                        })
                        .ToList();

                    // Asegurar que la lista no sea null
                    return listaServicios ?? new List<ModeloReservoNuevoServicio>();

                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción y proporcionar un mensaje ,devuelvo null
                return new List<ModeloReservoNuevoServicio>();
            }
        }
        /// <summary>
        /// CONSULTA COMPLICADA CONTROL LAS FECHAS DE LAS RESERVAS MUESTRA LA LISTA DE LAS HABITACIONES LIBRES.
        /// </summary>
        /// <returnsUNA LISTA CON LAS HABITACIONES LIBRES SEGUN EL PERIODO DE FECHAS</returns>
        public List<HabitacionViewModel> GetlistaHabitacionesLibresPorFecha(DateTime fechaIn, DateTime fechafin) {

            DateTime fechaInicio = fechaIn;/* Obtener fecha de inicio */
            DateTime fechaFin = fechafin;/* Obtener fecha de fin */

            using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
            {
                // Obtener todas las reservas que se superponen con el rango de fechas
                var reservasEnRango = db.Reserva
                    .Where(r => !(r.fecha_inicio >= fechaFin || r.fecha_fin <= fechaInicio))
                    .Select(r => r.idHabitacion_id)
                    .ToList();

                // Obtener todas las habitaciones que no tienen reservas en el rango de fechas
                var habitacionesDisponibles = db.Habitacion
                    .Where(h => !reservasEnRango.Contains(h.idHabitacion))
                    .ToList();
                List<HabitacionViewModel> habitacionesViewModel = habitacionesDisponibles
                    .Select(h => new HabitacionViewModel
                        {
                        IdHabitacion = h.idHabitacion,
                        Numero = h.numero,
                        Tipo = h.tipo,
                        Capacidad = h.capacidad ?? 0,
                        Precio = h.precio ?? 0,
                        Estado = new EstadoHabitacionViewModel
                        {
                            IdEstadoHabitacion = (int)h.estado_id,
                            Nombre = h.EstadoHabitacion.nombre
                        },
                    })
                      .ToList();

                return habitacionesViewModel;
                
            }
           


        }
        /// <summary>
        /// Llamada a función para insertar NUEVA RESERVA
        /// </summary>
        /// <returns> Devuelve si satisfactorio</returns>
        
        public void SetDatosReserva(int v1, int idCliente, int idHabitacion, int idServicio, DateTime nfechaIni, DateTime nfechaFin, int v2, int v3, string v4)
        {
            using (Modelo.DBFR.HotelSol_03Entities dbContext = new Modelo.DBFR.HotelSol_03Entities())
            {
                Reserva reserva = new Reserva
                {
                    idUsuario_id = v1,
                    cIdCliente_id = idCliente,
                    idHabitacion_id = idHabitacion,
                    idServicio_id = idServicio,
                    fecha_inicio = nfechaIni,
                    fecha_fin = nfechaFin,
                    total = v2,
                    temporada = (byte?)v3,
                    pension = v4
                };

                dbContext.Reserva.Add(reserva);
                dbContext.SaveChanges();
            
            
            }
        }
    }
}
