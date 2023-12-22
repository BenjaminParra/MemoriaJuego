INCLUDE Globals.ink
INCLUDE variables_hector.ink
INCLUDE variables_listadoClientes.ink

{hector_direccion:
    - 0: -> main
    - 1: -> postConversacion
}

=== main ===
~hector_inicio_conversacion = true
~contador_interacciones_restantes -= 1
¿Hola? Todo está bien, se te ve algo incómodo... #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Hola, ¿De verdad se me nota? #speaker: ??? #portrait: pnj_hector_triste #layout: izq
Soy Hector, encargado del post venta y últimamente he recibido llamadas de clientes pidiendo una rebaja en nuestros servicios porque otra empresa les ofreció exactamente el mismo servicio a un precio más bajo. #speaker: Hector #portrait: pnj_hector_triste #layout: izq
Esto no debería estar ocurriendo.

¿Tienes más información al respecto? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der

Sí, parece que estos clientes mencionaron detalles específicos de sus contratos y acuerdos con nosotros. #speaker: Hector #portrait: pnj_hector_triste #layout: izq
Detalles que, en teoría, solo nosotros deberíamos conocer. Parece que alguien más está accediendo a información confidencial de nuestros clientes.
~hector_obtuvo_pista = true
~hector_inicio_conversacion = true
~hector_pista_string = "Hector nos cuenta que clientes piden rebaja debido a que la competencia le ofrece planes similares a bajo costo"

~listadoClientes_obtuvo_pista_1 = true
~listadoClientes_pista_string_1 = "Existe una posible filtración de datos de clientes"
~cantidad_argumentos_listadoClientes = cantidad_argumentos_listadoClientes + 1

Gracias por informarme. Esto podría ser una señal de que hemos tenido una posible filtración de datos de clientes. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Deberíamos investigar de inmediato.
~hector_direccion = 1
-> postConversacion

-> DONE

=== postConversacion ===
Espero que me puedas ayudar por favor. #speaker: Hector #portrait: pnj_hector_neutral #layout: izq
-> DONE
