using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class controlGestionUsuarios
    { 
        public IEnumerable<Modelos.UserViewModel> GetList() {

            using (Modelos.EF.HotelSol_03Entities db = new Modelos.EF.HotelSol_03Entities())
            {
                IEnumerable<Modelos.UserViewModel> listaUsuarios = (from d in db.UsuarioLogin
                                                                   select new Modelos.UserViewModel
                                                                   {
                                                                       idUsuario = d.idUsuario,
                                                                       uCorreo_electronico = d.uCorreo_electronico
                                                                   }).ToList();
                return listaUsuarios;
                    
            }
            

            
        }
    }
       
}
/*  public void mostrarUsuarios()
        {
            try
            {
                // Obtener la lista de usuarios desde el controlador
                IEnumerable<UserViewModel> listaUsuarios = mainController.GetList();

                // Asignar la lista al origen de datos del DataGridView
                dataGridView.DataSource = listaUsuarios;

                // Opcional: si deseas ajustar automáticamente las columnas del DataGridView
                dataGridView.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }*/