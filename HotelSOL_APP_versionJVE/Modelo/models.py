from odoo import models, fields, api
import xml.etree.ElementTree as ET

class Cliente(models.Model):
    _name = 'x_clientes'
    _description = 'Tabla de Clientes'

    cIdCliente = fields.Integer(string='ID Cliente')
    cNombre = fields.Char(string='Nombre')
    cApellido1 = fields.Char(string='Apellido 1')
    cApellido2 = fields.Char(string='Apellido 2')
    cEdad = fields.Integer(string='Edad')
    cPais = fields.Char(string='País')
    cCiudad = fields.Char(string='Ciudad')
    cCalle = fields.Char(string='Calle')
    cZipcode = fields.Char(string='Código Postal')
    cCorreoElectronico = fields.Char(string='Correo Electrónico')
    cTipoCliente = fields.Selection([
        ('regular', 'Regular'),
        ('premium', 'Premium')],
        string='Tipo de Cliente')

class XMLLoader(models.TransientModel):
    _name = 'xml.loader'
    _description = 'Cargar Datos desde XML'

    xml_file_path = 'C:\\Users\\Naguru\\source\\repos\\HotelSOL_APP\\HotelSOL_APP_versionJVE\\Modelo\\xml\\clientes.xml'  # Ruta directa del archivo XML
    
    @api.model
    def cargar_datos_desde_xml(self):
        raiz = ET.parse(self.xml_file_path).getroot()
        
        url = 'https://rocket-team.odoo.com/'
        db = 'rocket-team'
        username = 'jdelavegae@uoc.edu'
        password = 'e496e1c5c238ca58b0365843db31de41ddf72c9b'
        
        common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(url))
        models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(url))
        uid = common.authenticate(db, username, password, {})
        
        for cliente in raiz.findall('./ArrayOfClienteXmlItem/ClienteXmlItem'):
            values = {
                'cNombre': cliente.find('cNombre').text,
                'cApellido1': cliente.find('cApellido1').text,
                'cApellido2': cliente.find('cApellido2').text,
                'cEdad': int(cliente.find('cEdad').text) if cliente.find('cEdad') is not None else False,
                'cPais': cliente.find('cPais').text,
                'cCiudad': cliente.find('cCiudad').text,
                'cCalle': cliente.find('cCalle').text,
                'cZipcode': cliente.find('cZipcode').text,
                'cCorreoElectronico': cliente.find('cCorreoElectronico').text,
                'cTipoCliente': cliente.find('cTipoCliente').text,
            }

            try:
                self.env['x_clientes'].create(values)
                print("Registro creado exitosamente.")
            except Exception as e:
                print(f"Error al crear el registro: {e}")
