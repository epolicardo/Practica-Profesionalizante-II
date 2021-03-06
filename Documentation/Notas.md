[Atrás](/README.MD)
Al leer el qr voy a la pagina del comercio.
  - Debo mostrar si el comercio ya esta aniadido a los favoritos del usuario


# Van a ser necesarios muchos endpoints distintos para manejar cada funcionalidad con los .Include de Linq

- **Cualquier persona puede darse de alta como usuario de la plataforma.**
    
    Un usuario se puede dar de alta automaticamente para crear su perfil de usuario. Solo será necesaria una 
    validación mediante correo electrónico.
  - Desde el perfil de usuario se debe poder:
    - Ver los datos de su perfil.
    - Ver los comercios recomendados, publicitados, favoritos y ultimos visitados.
    - Registrar sus formas de pago preferidas
    - Recomendar comercios a sus amigos.
    - Otorgar calificaciones tanto a productos como a comercios, teniendo en cuenta:
      - Calidad del Servicio
      - Precio
      - Tiempo de espera
      - etc.

- **Cualquier persona puede usar su cuenta de usuario para dar de alta un comercio de la plataforma.**
    
    Para dar de alta un comercio será necesario que el usuario con perfil ya existente, proveea un nombre, una descripción, domicilio, una imagen y otros datos.
    Una vez provistos los datos, dicho comercio será validado y aprobado por administradores del sistema, para comenzar su operacion en la plataforma.
    Una vez aprobado, el comercio será visible en el sistema.

- El perfil comercial podrá:
  - Crear productos para ese comercio
  - Editar productos
  - Editar los datos del comercio
  - Permitir ratear el comercio,
  - permitir ratear lo consumido
  - Ver un dashboard con las métricas mas importantes de su comercio, como:
    - Cantidad de ordenes
    - Tiempo promedio de entregas (Promedio de ordenes)
    - Cantidad de pedidos en espera

La oferta del comercio será accesible mediante una url de contrato (URL que se incluirá en el QR).
    

## Que funcionalidades se incluirán en el MVP?
El MVP debe incluir las siguientes funcionalidades:
- Landing Page del proyecto
    
    * Desde el punto de vista de usuario regular: *
      - Aplicación web responsive, que permita el acceso a la aplicación desde cualquier dispositivo.
      - Ver la oferta del comercio
      - Permitir agregar productos a la orden
      - Realizar el pago de la orden mediante
      - Crear perfil del usuario
      - Editar el perfil del usuario

- 
    * Desde el punto de vista de usuario comercial: *
      - Aplicación web responsive, que permita el acceso a la aplicación desde cualquier dispositivo.
      - Dashboard
      - Ver la oferta del comercio
      - Permitir agregar productos a la orden
      - Realizar el pago de la orden mediante
      - Crear perfil del usuario
      - Editar el perfil del usuario
-   
    * 

## Fuera del alcance del MVP

- Multi lenguaje.
- Integracion con redes sociales
- Integracion con pasarelas de pago
- 
  


Dentro del dashboard tendra las opciones necesarias para toda la gestion del comercio:
- Gestion de ordenes
    - Alta de productos del comercio
    - Modificaci�n de productos del comercio
    - Alta de lugares disponibles (N�meros de mesa, puestos de comida, etc)
    - Modificar [datos del comercio](datos_comercio.md)

  - Registro de usuarios
  - Registro de Productos
  - Registro de Comercios
- 



-----------



Casos para probar de la api con respecto al cliente:
- Devolver los datos para la portada
- Mostrar producto por id
- Mostrar Listado Productos por Categoria
- Mostrar todos los productos
- Listar Sugeridos y Ofertas segun disponibilidad de stock
- Agregar producto a orden
- Mostrar productos en la orden
- Quitar un producto de la orden
- Editar producto en la orden ( Podria removerlo y volver a agregarlo)
- Sumar productos en la orden (Mostrar importe total)
- Devolver foto de usuario para icono de cuenta
- Activar favoritos por usuario
- Mostrar favoritos
- Listar metodos de pago habilitados en el comercio
- Investigar plataformas de pago (MP, Lemon, Paypal, etc)  
- 
    []: # Language: markdown
    []: # Path: Documentacion\index.md
Referencia: https://datosgobar.github.io/georef-ar-api/
- https://apis.datos.gob.ar/georef/api/provincias
    
    Los productos seran cargados como unidades o porciones, para asi poder hacer el descuento correspondiente del stock.
    Por ejemplo, para una pizza cuatro quesos de 8 porciones, voy a utilizar los siguientes productos:

     <br>
    
    # ULTIMO MOMENTO: 
    ### Se cambia la metodologia del sistema, se cargaran porciones de productos pre preparados para su venta.
    El proceso de produccion de la cocina queda exceptuado, se lo considera como proveedor de productos listos para su preparacion.
    EJ: Porcion de lasagna, con salsa aparte
    -   Porcion de dos canelones
    -


    <br>
    <br>
   
   ### Cuatro quesos
    1 Masa de pizza grande
    1 Porcion de salsa de pizza
    1 porcion de muzarella
    1 porcion de roquefort
    1 porcion de gruyere
    10 porcion de fontina

    Si pidio con bordes rellenos, se utiliza 
    1 porcion adicional de muzarella


  EN el ejemplo de Canelones, es una porcion de canelones mas una de salsa.
  ---
  

  Recetas con porciones:
  ### Pizza Muzarella
    1 Masa de pizza grande
    1 Porcion de salsa de pizza
    4 porcion de muzarella
    1 Porcion de Aceitunas
    Oregano
  
  ### Pizza Napolitana
    1 Masa de pizza grande
    1 Porcion de salsa de pizza
    4 porcion de muzarella
    1 Porcion de Aceitunas
    1 porcion de tomate
    Albaca
   
  ### Canelones (1 porciones)
    1 Porcion de Canelones
    1 Porcion de Queso Rallado

    - Salsa Adicional
      - 1 Porcion de Filetto

  ### Lasagna (6 porciones)
    1 Porcion de Tapas
    1 Porcion de Queso Rallado
    1 Porcion de Acela
    2 Porcion de Jamon (200grs)
    2 Porcion de Queso Muzarella (200grs)

    - Salsa Adicional
      - 1 Porcion de Filetto



  ## Locro

5kg Acelga
3Kg Muza
2 Kg Jamon

RecetaProducto  
id
Nombre
List<Product>


DetalleReceta
IdReceta
IdProducto
Cantidad

1 4Q
2P Ln
1P Can



| Id | Prod | Cant |
----------------
| 1 | Pizza Muza | 3|


La pizza 4 quesos es vendible, y tiene receta, por lo cual no valida su stock.
Una vez que se agrega a una orden un producto con receta, debo disparar un control para validar si es posible su preparacion segun los ingredientes de su receta.
Si uno de sus ingredientes no esta disponible, no se podrá agregar a la orden, mostrando un cartel que informe que el producto no esta disponible.
