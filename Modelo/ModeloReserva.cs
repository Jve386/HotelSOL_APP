using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    /*internal class ModeloReserva
    {*/


    /// <summary>
    /// Representa una reserva en el sistema.
    /// </summary>
    public class ReservaViewModel
    {
        public int IdReserva { get; set; }
        public int IdUsuarioId { get; set; }
        public int IdHabitacionId { get; set; }
        public int IdServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Total { get; set; }
        public int NumeroHabitacion { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1Cliente { get; set; }
        public string Apellido2Cliente { get; set; }
        public Nullable<int> EdadCliente { get; set; }
        public string PaisCliente { get; set; }
        public string CiudadCliente { get; set; }
        public string CalleCliente { get; set; }
        public string ZipcodeCliente { get; set; }
        public string TipoCliente { get; set; }
        public string EstadoHabitacion { get; set; }
        public string ServicioNombre { get; set; }
    }


    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdCliente { get; set; }
        public ICollection<ReservaViewModel> Reservas { get; set; }
    }
    public class ClienteViewModelReserva
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public string Zipcode { get; set; }
        public string Tipocliente { get; set; }


    }
    public class HabitacionViewModel
    {
        public int IdHabitacion { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int Capacidad { get; set; }
        public decimal Precio { get; set; }
        public EstadoHabitacionViewModel Estado { get; set; }
        public TemporadaViewModel Temporada { get; set; }
        public ServicioHabitacionViewModel Servicio { get; set; }
        public PensionViewModel Pension { get; set; }
    }

    public class ServicioViewModel
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }

    public class ServicioHabitacionViewModel
    {
        public int IdServicioHabitacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Opcion1 { get; set; }
        public string Opcion2 { get; set; }
        public string Opcion3 { get; set; }
        public string Opcion4 { get; set; }
        public string Opcion5 { get; set; }
        public string Opcion6 { get; set; }
        public string Opcion7 { get; set; }
    }

    public class EstadoHabitacionViewModel
    {
        public int IdEstadoHabitacion { get; set; }
        public string Nombre { get; set; }
    }

    public class PensionViewModel
    {
        public int IdPension { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class TemporadaViewModel
    {
        public int IdTemporada { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    

        ///-----------------------------------------------------------------------------------------------------------///



        //}
    }


