INCLUDE Globals.ink
INCLUDE variables_leonardo.ink
INCLUDE variables_listadoClientes.ink

{leonardo_direccion:
    - 0: -> main
}

=== main ===
Hola, ¿Eres el encargado de ciberseguridad? #speaker: ??? #portrait: pnj_leonardo_neutral #layout: izq
~contador_interacciones_restantes -= 1
Soy Leonardo y trabajo en el área de soporte de post-venta. #speaker: Leonardo #portrait: pnj_leonardo_triste #layout: izq

¿Has escuchado acerca de la posible filtración de datos del listado de clientes? Acabo de descubrir que un ex-empleado todavía tiene acceso a la base de datos de clientes y está consultando información de los mismos. #speaker: Leonardo #portrait: pnj_leonardo_neutral #layout: izq

~leonardo_obtuvo_pista = true
~leonardo_inicio_conversacion = true
~leonardo_pista_string = "Leonardo nos informa sobre la posible filtración de datos del listado de clientes y el acceso de un ex-empleado a la base de datos de clientes."
~listadoClientes_obtuvo_pista_2 = true
~listadoClientes_pista_string_2 = "Existen accesos habilitados a la base de datos para ex-empleados"
~leonardo_direccion = 1
~cantidad_argumentos_listadoClientes = cantidad_argumentos_listadoClientes + 1

Gracias por la información. Deberíamos investigar esto inmediatamente. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der

-> DONE
