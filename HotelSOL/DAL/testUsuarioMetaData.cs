using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelSOL.DAL
{
    [Serializable]
    [XmlRoot("login_test")]
    public class testUsuarioMetaData
    {
        [XmlElement("usuario")]
        public string usuario { get; set; }
        [XmlElement("contrasena")]
        public string contrasena { get; set; }
    }
    [MetadataType(typeof(testUsuarioMetaData))]
    public partial class login_test
    {

    }

}
