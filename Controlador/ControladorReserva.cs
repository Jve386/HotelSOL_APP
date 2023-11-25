using Modelo;
using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
  
    public class ControladorReserva
    {
        /// <summary>
        /// Función que obtiene una reserva nueva
        /// </summary>
        /// <summary>
        /// Funcion que devuelve Reservas FALTA SOLO DEJAR LAS ACTIVAS, DE MOMENTO ES PARA MOSTAR ALGO TODAS 
        /// </summary>
        /// <returns>
        public List<ReservaViewModel> ObtenerReservas()
        {
            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var reservas = db.Reserva
                    .Include(r => r.Habitacion)
                    .Include(r => r.Habitacion.EstadoHabitacion) // Incluye la relación con el estado de la habitación
                    .Include(r => r.Habitacion.ServicioHabitacion) // Incluye la relación con el servicio de habitación
                    /*.Include(r => r.UsuarioLogin.Cliente) */// Incluye la relación con el cliente
                    .Select(r => new ReservaViewModel
                    {
                        IdReserva = r.idReserva,
                        IdUsuarioId = (int)r.idUsuario_id,
                        IdHabitacionId = (int)r.idHabitacion_id,
                        IdServicioId = (int)r.idServicio_id,
                        FechaInicio = r.fecha_inicio,
                        FechaFin = r.fecha_fin,
                        Total = r.total,
                        NumeroHabitacion = r.Habitacion.numero,
                        NombreCliente = r.Cliente.cNombre,
                        Apellido1Cliente = r.Cliente.cApellido1,
                        Apellido2Cliente = r.Cliente.cApellido2,
                        EdadCliente = r.Cliente.cEdad,
                        PaisCliente = r.Cliente.cPais,
                        CiudadCliente = r.Cliente.cCiudad,
                        CalleCliente = r.Cliente.cCalle,
                        ZipcodeCliente = r.Cliente.cZipcode,
                        TipoCliente = r.Cliente.cTipoCliente,
                        EstadoHabitacion = r.Habitacion.EstadoHabitacion.nombre,
                        ServicioNombre = r.Habitacion.ServicioHabitacion.nombre
                    })
                    .ToList();

                return reservas;
            }
        }
        public IEnumerable<HabitacionViewModel> GetServicioHabitaciones(int? idHabitacion)
        {
            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var habitacionesQuery = db.Habitacion.AsQueryable();

                if (idHabitacion.HasValue)
                {
                    habitacionesQuery = habitacionesQuery.Where(h => h.idHabitacion == idHabitacion.Value);
                }

                var habitaciones = habitacionesQuery
                    .Select(h => new HabitacionViewModel
                    {
                        IdHabitacion = h.idHabitacion,
                        Numero = h.numero,
                        Tipo = h.tipo,
                        Capacidad = h.capacidad ?? 0,
                        Precio = h.precio ?? 0,
                        Estado = new EstadoHabitacionViewModel
                        {
                            IdEstadoHabitacion =(int) h.estado_id,
                            Nombre = h.EstadoHabitacion.nombre
                        },
                        Servicio = new ServicioHabitacionViewModel
                        {
                            IdServicioHabitacion = (int)h.servicio_id,
                            Nombre = h.ServicioHabitacion.nombre,
                            Descripcion = h.ServicioHabitacion.descripcion,
                            Opcion1 = h.ServicioHabitacion.opcion1,
                            Opcion2 = h.ServicioHabitacion.opcion2,
                            Opcion3 = h.ServicioHabitacion.opcion3,
                            Opcion4 = h.ServicioHabitacion.opcion4,
                            Opcion5 = h.ServicioHabitacion.opcion5,
                            Opcion6 = h.ServicioHabitacion.opcion6,
                            Opcion7 = h.ServicioHabitacion.opcion7
                        },
                        
                    })
                    .ToList();

                return habitaciones;
            }
        }
        /// <summary>
        /// Funcion que devuelve la lista de Habitaciones
        /// </summary>
        /// <returns>Devuelve una lista Reserva CON TODOS LOS DATOS POSIBLES DE SU GRUPO PENSION, TEMPORADA,ESTADOHABITACIÓN, SERVICIO, SERVICIO HABITACIÓN
        ///   ESTO ESTA EN MODELO ReservaViewModel,HabitacionViewModel,TemporadaViewModel,ServicioHabitacionViewModel, PensionViewModel
        /// </returns>
        public IEnumerable<HabitacionViewModel> GetListaHabitaciones(int? idHabitacion)
        {
            using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var query = from h in db.Habitacion
                            join eh in db.EstadoHabitacion on h.estado_id equals eh.idEstadoHabitacion
                            /*join t in db.Temporada on h.temporada_id equals t.idTemporada*/
                            join sh in db.ServicioHabitacion on h.servicio_id equals sh.idServicioHabitacion
                            join p in db.Pension on h.pension_id equals p.idPension
                            select new HabitacionViewModel
                            {
                                IdHabitacion = h.idHabitacion,
                                Numero = h.numero,
                                Tipo = h.tipo,
                                Capacidad = h.capacidad ?? 0,
                                Precio = h.precio ?? 0,
                                Estado = new EstadoHabitacionViewModel
                                {
                                    IdEstadoHabitacion = eh.idEstadoHabitacion,
                                    Nombre = eh.nombre
                                },
                                /*Temporada = new TemporadaViewModel
                                {
                                    IdTemporada = t.idTemporada,
                                    Nombre = t.nombre,
                                    FechaInicio = t.fecha_inicio ?? DateTime.MinValue,
                                    FechaFin = t.fecha_fin ?? DateTime.MinValue
                                },*/
                                /*Servicio = new ServicioHabitacionViewModel*/
                               /*{
                                    IdServicioHabitacion = sh.idServicioHabitacion,
                                    Nombre = sh.nombre,
                                    Descripcion = sh.descripcion,
                                    Opcion1 = sh.opcion1,
                                    Opcion2 = sh.opcion2,
                                    Opcion3 = sh.opcion3,
                                    Opcion4 = sh.opcion4,
                                    Opcion5 = sh.opcion5,
                                    Opcion6 = sh.opcion6,
                                    Opcion7 = sh.opcion7
                                },*/
                                Pension = new PensionViewModel
                                {
                                    IdPension = p.idPension,
                                    Nombre = p.nombre,
                                    Descripcion = p.descripcion
                                }
                            };

                if (idHabitacion.HasValue)
                {
                    query = query.Where(h => h.IdHabitacion == idHabitacion);
                }

                var data = query.ToList();

                // Verificar si data está vacío
                if (data.Count == 0)
                {
                    // No ejecutar el return, simplemente regresar una lista vacía
                    return new List<HabitacionViewModel>();
                }

                return data;
            }
        }
        /*--------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------grupo cambiar fechas actualizar reserva            ---------------------------*/
        /*--------------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// FUNCION LLAMADA DESDE PRINCIPAL RecorrerListaIdReserva()
        /// </summary>
        /// <returns>MODIFICA LA BASE DE DATOS DE ESTADO HABITACIONES CONTROLA LA FECHA Y CAMBIA EL ESTADO DE LA HABITACIÓN</returns>
        public void ActualizarEstadoReserva(int idReserva)
        {
            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var reserva = db.Reserva.FirstOrDefault(r => r.idReserva == idReserva);
                if (reserva != null)
                {
                    bool enCurso = ReservaEnCurso(reserva.fecha_inicio, reserva.fecha_fin);
                    var habitacion = db.Habitacion.FirstOrDefault(h => h.idHabitacion == reserva.idHabitacion_id);
                    if (habitacion != null)
                    {
                        habitacion.estado_id = enCurso ? ObtenerIdEstadoOcupado() : ObtenerIdEstadoLibre();
                        db.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// FUNCION LLAMADA DESDE AQUÍ CONTOLADORrESERVA ACTUALIZARESTADORESERVA()
        /// </summary>
        /// <returns>Devuelve un bOOLEANO</returns>
        public bool ReservaEnCurso(DateTime fechaInicio, DateTime fechaFin)
        {
            DateTime fechaActual = DateTime.Now;

            // Verificar si las fechas de la reserva están en el pasado (caducadas)
            if (fechaInicio <= fechaActual && fechaFin < fechaActual)
            {
                // La reserva ha caducado
                return false;
            }

            // Verificar si las fechas de la reserva están en el futuro (reserva futura)
            if (fechaInicio > fechaActual)
            {
                // La reserva es para el futuro y aún no ha comenzado
                return false;
            }

            // La reserva está en curso (las fechas están dentro del rango actual)
            return true;
        }
        // Lógica para obtener el ID del estado "Ocupado" desde la base de datos o algún valor predefinido.
        public int ObtenerIdEstadoOcupado()
        {
          return 2; // Suponiendo que 1 es el ID del estado "Ocupado".
        }
        // Lógica para obtener el ID del estado "Libre" desde la base de datos o algún valor predefinido.
        public int ObtenerIdEstadoLibre()
        {
            
            return 1; // Suponiendo que 2 es el ID del estado "Libre".
        }
        /// <summary>
        /// Funcion que devuelve LISTA DE INTEGERS El id reserva 
        /// </summary>
        /// <returns>Devuelve una lista Reserva</returns>
        public List<int> ObtenerListaIdReserva()
        {
            List<int> listaIdReserva = new List<int>();

            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                try
                {
                    // Consultar la base de datos para obtener los ID de reserva.
                    listaIdReserva = db.Reserva.Select(r => r.idReserva).ToList();
                }
                catch (Exception ex)
                {
                    
                    return listaIdReserva = null;
                }
            }

            return listaIdReserva;
        }
        /*-------------------------------- grupo cambiar fechas actualizar reserva            --------------------------*/
        /*--------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------------*/

    }

    //}
}
