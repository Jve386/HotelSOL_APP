import xml.etree.ElementTree as ET
import pyodbc
import xmlrpc.client
import threading


def obtener_clientes_y_subir_a_odoo():
     
    try:
         
        # Configuración para la base de datos MSSQL
        mssql_connection_string = 'DRIVER={SQL Server};SERVER=DESKTOP-IJ8D8R0\\SQLEXPRESS;DATABASE=HotelSol_03;Integrated Security=True'
        query_obtener_clientes = 'SELECT cIdCliente,cNombre,cApellido1,cEdad,cPais,cCiudad,cCalle,cZipcode,cCorreoElectronico,cTipoCliente FROM Cliente'

        # Configuración de la conexión a Odoo
        odoo_url = 'https://rocket-team.odoo.com/'
        odoo_db = 'rocket-team'
        odoo_username = 'jdelavegae@uoc.edu'
        odoo_password = 'e496e1c5c238ca58b0365843db31de41ddf72c9b'

        # Conectar a MSSQL
        conn = pyodbc.connect(mssql_connection_string)
        cursor = conn.cursor()
        cursor.execute(query_obtener_clientes)
        clientes_mssql = cursor.fetchall()

        # Inicio de sesión
        common = xmlrpc.client.ServerProxy('{}/xmlrpc/2/common'.format(odoo_url))
        models = xmlrpc.client.ServerProxy('{}/xmlrpc/2/object'.format(odoo_url))
        uid = common.authenticate(odoo_db, odoo_username, odoo_password, {})

        print("Conexión exitosa. UID del usuario:", uid,"\n")

        # Conectar a Odoo
        common = xmlrpc.client.ServerProxy(f"{odoo_url}/xmlrpc/2/common")
        uid = common.authenticate(odoo_db, odoo_username, odoo_password, {})
        models = xmlrpc.client.ServerProxy(f"{odoo_url}/xmlrpc/2/object")

        for cliente_mssql in clientes_mssql:
                    cIdCliente, cNombre, cApellido1, cEdad, cPais, cCiudad, cCalle, cZipcode, cCorreoElectronico, cTipoCliente = cliente_mssql
                    # Buscar el ID del país en Odoo por el nombre del país
                    country_id = models.execute_kw(odoo_db, uid, odoo_password,
                                                'res.country', 'search',
                                                [[('name', '=', cPais)]])
                    if country_id:
                        country_id = country_id[0]

                    partner_search_domain = [('name', '=', cNombre)]
                    existing_partner_ids = models.execute_kw(odoo_db, uid, odoo_password,
                                                    'res.partner', 'search',
                                                    [partner_search_domain])
                    if existing_partner_ids:
                        # Si ya existe, omitir la creación y mostrar un mensaje
                        print(f"Socio ya existe en Odoo. ID en MSSQL: {cIdCliente}, ID en Odoo: {existing_partner_ids[0]}")
                    else:
                
        
                        # Crear un socio en Odoo
                        partner_id = models.execute_kw(odoo_db, uid, odoo_password,
                                                    'res.partner', 'create',
                                                    [{
                                                        'is_company': False,
                                                        'name': cNombre,
                                                        'parent_name': cApellido1,
                                                        'country_id': country_id,
                                                        'city': cCiudad,
                                                        'street': cCalle,
                                                        'zip': cZipcode,
                                                        'email': cCorreoElectronico
                                                    }])
                        
                        # Imprimir información del cliente subido
                        print(f"Cliente subido a Odoo. ID en MSSQL: {cIdCliente}, ID en Odoo: {partner_id}")

        # Cerrar conexiones
        conn.close()

    except Exception as e:
        print(f"Ocurrió un error: {e}")
    
        # Aquí podrías agregar cualquier código adicional que desees ejecutar en caso de error.

# Crear un hilo para ejecutar la función en segundo plano
hilo = threading.Thread(target=obtener_clientes_y_subir_a_odoo)
hilo.start()

# El programa principal sigue ejecutándose aquí
input("A continuación se mostrarán los clientes. Recuerda pulsar ENTER para cerrar la ventana.\n")