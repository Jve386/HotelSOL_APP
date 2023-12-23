import xmlrpc.client
import pyodbc
import threading
from decimal import Decimal

def obtener_habitaciones_y_subir_a_odoo():
    try:
        # Configuración para la base de datos MSSQL
        mssql_connection_string = 'DRIVER={SQL Server};SERVER=DESKTOP-IJ8D8R0\\SQLEXPRESS;DATABASE=HotelSol_03;Integrated Security=True'
        query_obtener_habitaciones = 'SELECT idHabitacion, numero, tipo, capacidad, precio, estado_id, servicio_id, pension_id FROM Habitacion'

        # Configuración de la conexión a Odoo
        odoo_url = 'https://rocket-team.odoo.com/'
        odoo_db = 'rocket-team'
        odoo_username = 'jdelavegae@uoc.edu'
        odoo_password = 'e496e1c5c238ca58b0365843db31de41ddf72c9b'

        # Conectar a MSSQL
        conn = pyodbc.connect(mssql_connection_string)
        cursor = conn.cursor()
        cursor.execute(query_obtener_habitaciones)
        habitaciones_mssql = cursor.fetchall()

        # Inicio de sesión en Odoo
        common = xmlrpc.client.ServerProxy(f'{odoo_url}/xmlrpc/2/common')
        models = xmlrpc.client.ServerProxy(f'{odoo_url}/xmlrpc/2/object')
        uid = common.authenticate(odoo_db, odoo_username, odoo_password, {})

        print("Conexión exitosa. UID del usuario:", uid, "\n")

        # Iterar sobre las habitaciones obtenidas de MSSQL
        for habitacion_mssql in habitaciones_mssql:
            # Convertir instancias de Decimal a float
            habitacion_mssql = list(map(lambda x: float(x) if isinstance(x, Decimal) else x, habitacion_mssql))
            idHabitacion, numero, tipo, capacidad, precio, estado_id, servicio_id, pension_id = habitacion_mssql

            # Crear una habitación en Odoo (adaptar el modelo según tu modelo en Odoo)
            habitacion_id_odoo = models.execute_kw(odoo_db, uid, odoo_password, 'x_habitaciones', 'create', [{
                # 'name': f'Habitación {numero}',
                'x_numero': numero,
                'x_name': tipo,
                'x_capacidad': capacidad,
                'x_precio': precio,
                'x_estado_id': estado_id,
                'x_servicio_id': servicio_id,
                'x_pension_id': pension_id,
            }])

            # Imprimir información de la habitación subida
            print(f"Habitación subida a Odoo. ID en MSSQL: {idHabitacion}, ID en Odoo: {habitacion_id_odoo}")

        # Cerrar conexiones
        conn.close()

    except Exception as e:
        print(f"Ocurrió un error: {e}")

# Crear un hilo para ejecutar la función en segundo plano
hilo = threading.Thread(target=obtener_habitaciones_y_subir_a_odoo)
hilo.start()

# El programa principal sigue ejecutándose aquí
input("A continuación se mostrarán las habitaciones. Recuerda pulsar ENTER para cerrar la ventana.\n")
