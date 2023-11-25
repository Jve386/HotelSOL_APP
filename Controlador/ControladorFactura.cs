using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.DBFR;
using System.Data.Entity;



namespace Controlador
{
    public class ControladorFactura
    {
        public List<Modelo.DBFR.Factura> ObtenerFacturas()
        {
            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var facturas = db.Factura
                    .ToList();

                return facturas;
            }
        }

        public void BtnCrearFactura_Click(int idReserva)
        {     
            try
            {
                using (var dbContext = new Modelo.DBFR.HotelSol_03Entities())
                {
                    // Sacamos la reserva para hacer la factura
                    Reserva reserva = dbContext.Reservas.Find(idReserva);

                    if (reserva != null)
                    {
                        // Cargamos el servicio (hay que hacerlo así o da problemas)
                        dbContext.Entry(reserva).Reference(r => r.Servicio).Load();

                        // Accedemos al servicio
                        Servicio servicio = reserva.Servicio;

                        // Creamos la factura, llamando a los métodos para generar el número y el precio de la factura.
                        Factura nuevaFactura = new Factura
                        {
                            numero_factura = GenerarNumFactura(),
                            fecha_emision = DateTime.Today,
                            totalFactura = CalculateTotalFactura(reserva.total, servicio?.precio),
                            idReserva_id = idReserva
                        };

                        // Guardar factura a la BD
                        dbContext.Factura.Add(nuevaFactura);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        
                        Console.WriteLine($"No matching reserva found for IdReserva: {idReserva}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (logging, etc.)
                Console.WriteLine($"Error creating factura: {ex.Message}");
            }
        }

        public List<ModeloFactura.FacturaViewModel> ObtenerFacturasViewModel()
        {
            using (var db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var facturas = db.Factura
                    .Select(f => new ModeloFactura.FacturaViewModel
                    {
                        // Propiedades factura (se pueden añadir mas)
                        idFactura = f.idFactura,
                        numero_factura = f.numero_factura,
                        fecha_emision = f.fecha_emision,
                        totalFactura = (float)f.totalFactura,
                        idReserva_id = (int)f.idReserva_id,
                        
                    })
                    .ToList();

                return facturas;
            }
        }

        private int GenerarNumFactura()
        {
            try
            {
                using (var dbContext = new Modelo.DBFR.HotelSol_03Entities())
                {
                    // Comprobamos que exista por lo menos una factura en la BD
                    if (dbContext.Factura.Any())
                    {
                        // Buscamos la última factura existente
                        int ultimoNumFactura = dbContext.Factura.Max(f => f.numero_factura);

                        // Calculamos el num Factura
                        int numero_factura = ultimoNumFactura + 1;

                        return numero_factura;
                    }
                    else
                    {
                        // Devuelve 1 si no la encuentra
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting new invoice number: {ex.Message}");
                throw;
            }
        }

        private decimal CalculateTotalFactura(decimal total, decimal? precio)
        {
            decimal totalFactura = total;

            if (precio.HasValue)
            {
                totalFactura += precio.Value;
            }

            return totalFactura;
        }

        public void ActualizarFactura(int idFactura, decimal nuevoTotal)
        {
            try
            {
                using (var dbContext = new Modelo.DBFR.HotelSol_03Entities())
                {
                    // Buscamos la factura actual
                    Factura factura = dbContext.Factura.Find(idFactura);

                    if (factura != null)
                    {
                        // Actualizamos el importe.
                        factura.totalFactura = nuevoTotal;

                        // Guardar Cambios
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"No matching factura found for IdFactura: {idFactura}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating total for factura: {ex.Message}");
                throw;
            }
        }
    }
}
    