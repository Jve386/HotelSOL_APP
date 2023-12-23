import xmlrpc.client
import pyodbc
import threading
from decimal import Decimal

def obtener_productos_y_subir_a_odoo():
    try:
        # Configuración para la base de datos MSSQL
        mssql_connection_string = 'DRIVER={SQL Server};SERVER=DESKTOP-IJ8D8R0\\SQLEXPRESS;DATABASE=HotelSol_03;Integrated Security=True'
        query_obtener_productos = 'SELECT idProducto, nombre, cantidad, precio, fecha_ingreso FROM productos'

        # Configuración de la conexión a Odoo
        odoo_url = 'https://rocket-team.odoo.com/'
        odoo_db = 'rocket-team'
        odoo_username = 'jdelavegae@uoc.edu'
        odoo_password = //poner contrasena

        # Conectar a MSSQL
        conn = pyodbc.connect(mssql_connection_string)
        cursor = conn.cursor()
        cursor.execute(query_obtener_productos)
        productos_mssql = cursor.fetchall()

        # Inicio de sesión en Odoo
        common = xmlrpc.client.ServerProxy(f'{odoo_url}/xmlrpc/2/common')
        models = xmlrpc.client.ServerProxy(f'{odoo_url}/xmlrpc/2/object')
        uid = common.authenticate(odoo_db, odoo_username, odoo_password, {})

        print("Conexión exitosa. UID del usuario:", uid, "\n")

        for producto_mssql in productos_mssql:
            idProducto, nombre, cantidad, precio, fecha_ingreso = producto_mssql

            # Verificar si el producto ya existe en Odoo por el nombre
            existing_product_ids = models.execute_kw(odoo_db, uid, odoo_password, 'product.template', 'search',
                                                     [[['name', '=', nombre]]])

            if not existing_product_ids:
                # Convertir instancias de Decimal a float
                producto_mssql = list(map(lambda x: float(x) if isinstance(x, Decimal) else x, producto_mssql))
                idProducto, nombre, cantidad, precio, fecha_ingreso = producto_mssql

                # Crear el producto en Odoo solo si no existe
                producto_id_odoo = models.execute_kw(odoo_db, uid, odoo_password, 'product.template', 'create', [{
                    'id': idProducto,
                    'name': nombre,
                    'x_cantidad': cantidad,
                    'x_precio': precio,
                    'create_date': fecha_ingreso,
                }])

                print(f"Producto subido a Odoo. ID en MSSQL: {idProducto}, ID en Odoo: {producto_id_odoo}")
            else:
                print(f"El producto '{nombre}' ya existe en Odoo. No se subirá nuevamente.")

        # Cerrar conexiones
        conn.close()

    except Exception as e:
        print(f"Ocurrió un error: {e}")

# Crear un hilo para ejecutar la función en segundo plano
hilo = threading.Thread(target=obtener_productos_y_subir_a_odoo)
hilo.start()

# El programa principal sigue ejecutándose aquí
input("A continuación se mostrarán los productos. Recuerda pulsar ENTER para cerrar la ventana.\n")
