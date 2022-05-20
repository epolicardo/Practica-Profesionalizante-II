# Entrevista a cliente
## Alumno: Emiliano Policardo
## Fecha: 10/10/2018
### Materia: Practica Profesionalizante II

<p style="font-family: times, serif; font-size:24pt; font-style:italic">
 Titulo del proyecto: OrderNow
</p>

[Casos de uso](UseCases.pdf)

## Que desea hacer?

Tengo una idea de negocio que me gustaría implementar.

### De que se trata?

Un sistema de ordenes en comercios gastronómicos, que permita al cliente realizar su orden desde la web, con la opción de pagar con tarjeta de crédito, debito o efectivo y otros medios de pago, tanto para consumir en el local como para retirar desde el local.
Además, que este sistema tenga un apartado para la gestión en el comercio, tanto de las ordenes, los pagos y los productos.


**Que se quiere lograr con este proyecto?**

Para los consumidores, mejorar el tiempo y calidad en la atención al momento de salir a cenar o consumir algún producto o servicio

Para los comerciantes, mejorar la oferta de su servicio, incremetar ventas, reducir costos operativos y mejorar la organizacion de sus comercios, brindando gestion de ventas, pedidos, demoras, permitiendo asi optimizar los recursos de su empresa y tener una mejor atenci�n a sus clientes.

**Desea que su proyecto incluya publicidades para generar ingreos extras?**

Si, me interesa utilizar algun formato, no invasivo de publicidad, para generar ingresos extras.
Se me ocurren dos formas de Monetizacion:
- La publicidad será en la pantalla del perfil del usuario, mostrando los comercios patrocinados en el panel de recomendados, donde competiran en lugar con los calificados por los usuarios.
- Se cobrará por cantidad de productos en la plataforma. Los comercios contrarán con un minimo gratis.
- En la landing page los comercios podrán estar presentes como patrocinados.

**En que dispositivos desea que pueda ser utilizado?**

Mi intención es que los usuarios consumidores accedan a una página web leyendo un QR desde su dispositivo movil, ya sea celular o tablet.
Con respecto al sistema de gestion para el comercio, seria suficiente con el acceso a traves del navegador de una computadora.

**Desea que su sistema se traduzca a otros idiomas?**

Si, al menos que cuente con la version en inglés, pero que en el futuro, pueda ser mostrado en otros idiomas, agregando algún componente adicional.

**Que presupuesto tiene destinado al MVP del proyecto?**

Dispongo de 4 notas para aprobar la materia.

**Cual es el plazo estimado en que desea este proyecto?**

Para el MVP, el plazo es de 7 meses.



Desde el punto de vista operativo:

Que hace el cocinero con el sistema?
Solo recibe un ticket impreso con una comanda por duplicado, que luego de completar el pedido, entrega una parte de la comanda a administracion, y la otra la guarda para control.
Que hace el mozo con la app?
No utiliza la app.
Que hace el administrativo?
En el modulo de administracion, se reciben las ordenes realiadas por los clientes.
Cada orden sera puesta en cola de espera, para luego ser preparada.
Cuando llega una orden, se imprime automaticamente un ticket de [Comanda](Comanda.md), el cual incluye 3 cuerpos iguales, 
uno para la barra/administracion para preparar copas, utensillos y bebidas, y las otras dos para la cocina, de las cuales, una vez completada la preparacion, devolveran los platos con una parte de ese comprobante, quedando para control uno en la cocina y uno en la adm. para verificacion.
(Discriminar productos de cocina y de barra)
Se preparan las bebidas y los utensillos, se entregan al mozo para entregar en mesa.
El mozo va y entrega los productos de barra, 

Cuando la cocina completa el producto, lo entrega en barra y ahi se marca como completada la preparacion y entrega del pedido. (Al confirmar la saco de cola de espera para mover las posteriores ordenes, Podria existir una marca de entrega paracial en la orden.)
Permitir que la orden tenga estado de 
preparacion, 
parcialmente entregada,
 completada, 
 en espera o 
 cancelada.
 luego vuelve con los productos de cocina

Errores 


-Entrega parcial en curso (Entrego primero la bebida)

Que hace el propietario?
Como propietario, me interesa poder utilizar el sistema para ver estadisticas, datos de venta, y a partir de este
tipo de informacion, ser capaz de realizar toma de deciciones para mejorar la calidad de la atencion e incrementar las 
ganancias.
- Necesito ver:
	- Los productos mas vendidos del ultimo mes
	- Los productos menos vendidos
    - Los horarios en que mas ordenes se generan
    - Promedio de tiempo para la entrega de ordenes.

Ingreso en www.ordernow.com.ar
Selecciono el boton Registrarme
Ingreso mis credenciales
De esta forma, estaria viendo los datos de mi usuario personal.
Seleccionando la opcion correspondiente seria enviado al "Perfil Comercial".
A continuacion veo la informacion mas relevante en un dashboard relativa al comercio.
Si quiero ver informacion especifica de los productos por ejemplo, ingresando a la seccion de productos, deberia ver un dashboard
exclusivo para los productos, lo mismo para cada seccion del sistema.
Los primeros pasos son: 
Cargar los diferentes productos.
CArgar empleados?
Cargar mesas?
Cargar formas de pago?
Puntos de venta?



