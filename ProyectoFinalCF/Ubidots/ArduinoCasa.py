# -*- coding: utf-8 -*-
from ubidots import ApiClient
import serial
import time



if __name__=='__main__':
	dato=0
		

	try:  
		print ("CONECTADO...")  
		arduino = serial.Serial('COM4', 9600, timeout=2.0)  #Conexión serial a arduino
		print(arduino)
		time.sleep(1)
		arduino.flush()
		
   
	except:  
		print ("FALLO LA CONEXION")

	try:  
		print ("CONECTADO API...")  
		api = ApiClient(token='BBFF-NHtF9NFSUhmUyXpFH5RTB8KxtCoeDM')  #Conexión a Ubidots con ese Token (suministrado por Ubidots)
		
		temperatura = api.get_variable('6045337d1d847250dbee9a29')  #Se almacena el nombre de la variable con ese ID

		print(temperatura)
		print('probando si conecta')
	except:  
		print ("FALLO LA CONEXION API")
	
	#contador=0
	while True:
		temp=arduino.read() #Recibe datos de arduino  

		dato=int.from_bytes(temp,byteorder='big',signed=False) #Se recibe bytes, se convierte a Entero
		print(dato)   
		newTemp= temperatura.save_value({'value':dato})  #Se envía dato a Ubidots
		arduino.flushInput()
			
		bombilloSalaCocina= api.get_variable('604533b21d847251cc033634')  #Se almacena nombre de la variable con ese ID
		new_valueSalaCocina = bombilloSalaCocina.get_values(1)  #Recibe un diccionario
	

		bombilloBanoCuarto= api.get_variable('604533cc1d847252a0eb927c')  #Se almacena nombre de la variable con ese ID
		new_valueBanoCuarto = bombilloBanoCuarto.get_values(1)  #Recibe un diccionario

		puerta= api.get_variable('604533e71d8472513a5ca7ad')
		new_valuePuerta=puerta.get_values(1)

		ventana = api.get_variable('604533ec1d847252a0eb927d')
		new_valueVentana=ventana.get_values(1)


		if (new_valueSalaCocina[0]['value']==1):
			arduino.write(b'0')  #Se envía a arduino para encender el led
			print('encendiendo led')
		else:
			arduino.write(b'1')  #Se envía a arduino para apagar el led
			print('No enciende el led')
		if (new_valueBanoCuarto[0]['value']==1):
			arduino.write(b'2')  #Se envía a arduino para encender el led
			print('encendiendo led')
		else:
			arduino.write(b'3')  #Se envía a arduino para apagar el led
			print('No enciende el led')
		if (new_valuePuerta[0]['value']==1):
			arduino.write(b'4')  #Se envía a arduino para encender el led
			print('encendiendo led')
		else:
			arduino.write(b'5')  #Se envía a arduino para apagar el led
			print('No enciende el led')
		if (new_valueVentana[0]['value']==1):
			arduino.write(b'6')  #Se envía a arduino para encender el led
			print('encendiendo led')
		else:
			arduino.write(b'7')  #Se envía a arduino para apagar el led
			print('No enciende el led')



