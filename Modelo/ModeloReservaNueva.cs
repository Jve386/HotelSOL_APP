using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloReservaNueva
    {
        public int idReserva { get; set; }
        public UsuarioLogin idUsuario_id { get; set; }
        public Cliente cIdCliente_id { get; set; }
        public Habitacion idHabitacion_id { get; set; }
        public Servicio idServicio_id { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public decimal total { get; set; }
        /*public Nullable<byte> temporada { get; set; }*/
        public string pension { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual UsuarioLogin UsuarioLogin { get; set; }
    }
    public class ModeloReservaNuevaCliente
    {
        public int cIdCliente { get; set; }
        public string cNombre { get; set; }
        public string cApellido1 { get; set; }
        public string cApellido2 { get; set; }
        public Nullable<int> cEdad { get; set; }
        public string cPais { get; set; }
        public string cCiudad { get; set; }
        public string cCalle { get; set; }
        public string cZipcode { get; set; }
        public string cCorreoElectronico { get; set; }
        public string cTipoCliente { get; set; }
    }

    public class ModeloReservoNuevoServicio{

        public int IdServicios { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio { get; set; }

    }
    public class InsertReserva
    {
        public int idReserva { get; set; }
        public int idUsuario_id { get; set; }
        public int cIdCliente_id { get; set; }
        public int idHabitacion_id { get; set; }
        public int idServicio_id { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public decimal total { get; set; }
        public Nullable<byte> temporada { get; set; }
        public string pension { get; set; }
    }



}
