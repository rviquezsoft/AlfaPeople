# AlfaPeople
馃憢 Hola,saludos,  se intent贸 utilizar lo mejor posible los principios S.O.L.I.D, tambi茅n se uso herencia y polimorfismo para resolver el enunciado , los datos de las rutas de entrada y salida se leen del archivo appsettings.json . Se realiza la aplicaci贸n con .NET Core 3.1 y Visual Studio MAC 2022.

# Enunciado:
<br>1. MANEJO DE ARCHIVOS
<br>Aspectos para evaluar: Programaci贸n Orientada a Objetos, Programaci贸n Funcional, Manejo de archivos, serializaci贸n y deserializaci贸n.
<br>Se requiere realizar una aplicaci贸n de consola que se utilice para realizar prototipos de funciones y clases que posteriormente sean migradas a otro tipo de proyecto.
<br>Se requiere que la aplicaci贸n lea archivo XML.
<br>Los archivos contenidos en un directorio de entrada que contiene los archivos XML se guardar谩n en una lista de objetos.
<br>Esta lista de objetos deber谩 ser mostrada en pantalla en formato JSON. Posteriormente esta lista de objetos deber谩 ser guardada en un archivo JSON.
<br>La aplicaci贸n debe tener un valor de configuraci贸n para el directorio de entrada para los archivos XML y de salida para los archivos JSON.
<br>La aplicaci贸n debe tener una configuraci贸n con una ruta de entrada para colocar un directorio v谩lido, para poder trabajar se proporcionan los archivos que se encuentran en la carpeta ARCHIVOS
<br>Informaci贸n de los archivos
<br>Los archivos contienen informaci贸n de pedidos de venta y pedidos de compra, con datos de encabezado y l铆neas.
<br>Los productos deben manejar la siguiente informaci贸n: C贸digo producto, Nombre, Almac茅n, Talla, Color y Estilo, sin embargo, para cada una de las l铆neas de pedido de venta o compra tienen informaci贸n distinta, en l铆nea del pedido de venta se incluir谩 cantidad venta y unidad de venta, para el pedido de compra se manejar谩 cantidad compra y unidad de compra.
<br>Tip: aunque se puede utilizar funcionalidades para deserializar los XML y convertirlo en clases, se evaluar谩 que existan suficientes clases que permitan escalabilidad para posteriores cambios.
