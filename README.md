# AlfaPeople
👋 Hola,saludos,  se intentó utilizar lo mejor posible los principios S.O.L.I.D, también se uso herencia y polimorfismo para resolver el enunciado , los datos de las rutas de entrada y salida se leen del archivo appsettings.json . Se realiza la aplicación con .NET Core 3.1 y Visual Studio MAC 2022.

# Enunciado:
<br>1. MANEJO DE ARCHIVOS
<br>Aspectos para evaluar: Programación Orientada a Objetos, Programación Funcional, Manejo de archivos, serialización y deserialización.
<br>Se requiere realizar una aplicación de consola que se utilice para realizar prototipos de funciones y clases que posteriormente sean migradas a otro tipo de proyecto.
<br>Se requiere que la aplicación lea archivo XML.
<br>Los archivos contenidos en un directorio de entrada que contiene los archivos XML se guardarán en una lista de objetos.
<br>Esta lista de objetos deberá ser mostrada en pantalla en formato JSON. Posteriormente esta lista de objetos deberá ser guardada en un archivo JSON.
<br>La aplicación debe tener un valor de configuración para el directorio de entrada para los archivos XML y de salida para los archivos JSON.
<br>La aplicación debe tener una configuración con una ruta de entrada para colocar un directorio válido, para poder trabajar se proporcionan los archivos que se encuentran en la carpeta ARCHIVOS
<br>Información de los archivos
<br>Los archivos contienen información de pedidos de venta y pedidos de compra, con datos de encabezado y líneas.
<br>Los productos deben manejar la siguiente información: Código producto, Nombre, Almacén, Talla, Color y Estilo, sin embargo, para cada una de las líneas de pedido de venta o compra tienen información distinta, en línea del pedido de venta se incluirá cantidad venta y unidad de venta, para el pedido de compra se manejará cantidad compra y unidad de compra.
<br>Tip: aunque se puede utilizar funcionalidades para deserializar los XML y convertirlo en clases, se evaluará que existan suficientes clases que permitan escalabilidad para posteriores cambios.
