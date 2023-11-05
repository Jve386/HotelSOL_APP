using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class MainController
    {
        public IEnumerable<Modelo.UserViewModel> GetList() {

            using (Modelo.EF.HotelSol_01Entities db = new Modelo.EF.HotelSol_01Entities()) 
            {
                IEnumerable<Modelo.UserViewModel> lst = (from d in db.UsuarioLogin
                                                        select new Modelo.UserViewModel
                                                        {
                                                            Id = d.idUsuario,
                                                            Email = d.uCorreo_electronico
                                                        }).ToList();
                return lst;
            }
        }
    }
}
