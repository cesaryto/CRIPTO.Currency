# CRIPTO.Currency
Prueba tecnica

- Creación BD 

  El archivo de migraciones para crear la BD se encuentra en el proyecto
  Currency.Database y la cadena de conexión se configura en appsettings.json

  para llenar la BD se ejecuta el servicio y se hace la solicitud POST a

  http://localhost:31900/currencies

 con el content json

 {
	"TaskType" : 0
 }

 el cual obtiene los datos de coinlore.com

-Para obtener los datos a hoy de las cripto monedas de coinlore.com

 se realiza la peticion GET

 http://localhost:31900/currencies sin content

-Para obtener una cripto moneda se realiza la petición GET

 http://localhost:31900/currencies/GetById/90

-Para obtener la conversion de dolares a criptomoneda se realiza la peticion GET

 http://localhost:31900/currencies/convert 

 con el content json

 {
    "id":90,
    "usd":40000
 }
