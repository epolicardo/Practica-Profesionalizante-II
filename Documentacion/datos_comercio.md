# Datos de un comercio

Un comercio podría contener los siguientes datos:

- Nombre
- [Domicilio](.domicilios.md)
- Imagen representativa
- Icono
- Horario de atención
- URL de acceso (ContractURL)
- Mensaje promocional
- CUIT
- Nombre legar o Razon Social
- Telefono
- Contacto Comercial
- Es franquicia?
- Lista de usuarios
- Lista de Productos
- Lista de Formas de Pago
- Lista de Proveedores
- Estadisticas (Ventas, compras, demoras, valor por ticket, etc)    



        
        
        
        
        
        
        
        string Name 
        Addresses Address 
        string ImageURL 
        string ContractURL 
        string PromoMessage 
        bool IsFrachise { get; 
        string CUIT 
        string LegalName 
        string Phone 
        People CommercialContact 
        List<People> Users 
        List<Products> ProductsList 
        List<PaymentMethods> PaymentMethods 