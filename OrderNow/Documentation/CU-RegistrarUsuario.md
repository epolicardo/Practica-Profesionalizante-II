[Atras](UseCases.md)

### Código: CU-00
# Titulo: <span style="color:#B4CD93">Registrar Usuario</span>.
- **Versión del documento:** 1.0.0
- **Descripción:** Se dará de alta un usuario en el sistema.
- **Secuencia Normal:** 
    - **Secuencia de Pasos:**
        1. El usuario ingresa a la pantalla correspondiente
        2. Selecciona en la opción Registrarme
        3. Sera redirigido a la pagina de registro
        4. Ingresara los datos requeridos para el alta de la cuenta
           1. Estos datos son los minimos requeridos:
              1. Correo electronico
              2. Contraseña
              3. Repeticion de contrasena
              4. Fecha de Nacimiento
              5. Nombre y Apellido (opcionales)
        5. Se enviara un correo para confirmar el alta de la cuenta
        6. Mediante el correo, debera utilizar el link de confirmacion para dicha activacion
        7. Una vez que el usuario accede al link, el usuario queda completamente activado.
        
- **Secuencia Alternativa:**
    - **Secuencia de Pasos:**
      - No aplica.
      - Valida si el usuario ya existe
      - 
        1. ~~El usuario ingresa a la pantalla correspondiente~~
        2. ~~Selecciona en la opción Alta de Cliente~~
        3. ~~Asi hacemos el tachado, que podria usarse para deprecar algo~~
        
    
- **Dependencias:** Aca van las dependencias
- **Precondición:**
- **PostCondición:**
- **Excepciones:**
- **Comentarios:**
  - Solo se podra activar una cuenta de usuario por cada correo electronico ingresado.

        1. ~~Asi hacemos el tachado, que podria usarse para deprecar algo~~