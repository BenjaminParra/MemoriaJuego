INCLUDE variables_personal_aseo_1.ink
INCLUDE Globals.ink

{personal_aseo_1_direccion:
    - 0: ->main
    - 1: ->primeraInteraccion
    - else: ->postConversacion
}

=== main ===
#speaker: ??? #portrait: personal_aseo_1_neutral #layout: izq
¡Hola, soy María! ¿Cómo estás? Soy la encargada del área de aseo.#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
~personal_aseo_1_direccion = 1
->primeraInteraccion
->DONE

=== primeraInteraccion ===
Escuché que llegaría el encargado de ciberseguridad.#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
Dicen que suele involucrarse en muchas áreas de la empresa.
    +[Presentarse como el encargado]
    Soy el encargado, jajaja.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    Ay, no, qué vergüenza, mejor no sigo hablando. speaker: María #portrait: personal_aseo_1_triste #layout: izq
    ~personal_aseo_1_direccion = 2
    ~contador_interacciones_restantes = contador_interacciones_restantes - 1
    ~personal_aseo_1_inicio_conversacion = true
    ->DONE
    +[No decir nada]
    Veo que eres callado.#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
    ->segundaInteraccion
->DONE

=== segundaInteraccion ===
Me resultas confiable...#speaker: María #portrait: personal_aseo_1_feliz #layout: izq
¿Sabes qué es lo que odio? Limpiar un área específica.
Llena de migas, tazones, papeles con claves y cosas así...
+[¿Papeles con claves?]
¿Mencionaste papeles con claves?#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
¿Por qué haces tantas preguntas?#speaker: María #portrait: personal_aseo_1_triste #layout: izq
¡No diré nada más! Seguro eres el encargado de ciberseguridad.
~personal_aseo_1_direccion = 2
~personal_aseo_1_pista_string = "Existe un área con claves escritas en papeles."
~personal_aseo_1_obtuvo_pista = true
~contador_interacciones_restantes = contador_interacciones_restantes - 1
~personal_aseo_1_inicio_conversacion = true
->DONE
+[Interesante información]
Si vieras las veces que han buscado sus claves como locos.#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
El área es la de informáticos...
~personal_aseo_1_pista_string = "El área de informáticos tiene claves escritas en papeles."
~personal_aseo_1_obtuvo_pista = true
->terceraInteraccion
->DONE

=== terceraInteraccion ===
Ahora que lo pienso...#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
Dijeron que el encargado llevaba un polerón burdeo...
¿Eres... eres tú?#speaker: María #portrait: personal_aseo_1_triste #layout: izq
+[Tranquilizar]
Sí, pero tranquila, no estás en problemas.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
De hecho, esta conversación es personal...
Has sido de gran ayuda...
~contador_interacciones_restantes = contador_interacciones_restantes - 1
->despedida
+[Mostrarse molesto]
Estoy molesto, hablaremos más tarde.#speaker: Personaje Principal #portrait: personaje_principal_triste #layout: der
~contador_interacciones_restantes = contador_interacciones_restantes - 1
~personal_aseo_1_inicio_conversacion = true
->DONE

=== despedida ===
Te pido disculpas por lo que dije de ti.#speaker: María #portrait: personal_aseo_1_triste #layout: izq
Espero que podamos llevarnos bien.
~personal_aseo_1_direccion = 2
~personal_aseo_1_inicio_conversacion = true
->postConversacion
->DONE

=== postConversacion ===
#speaker: María #portrait: personal_aseo_1_neutral #layout: izq
Seguiré limpiando. Un gusto.
->DONE