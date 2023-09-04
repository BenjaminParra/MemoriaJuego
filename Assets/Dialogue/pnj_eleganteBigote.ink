INCLUDE Globals.ink

{donGenaro_direccion:
    - 0: ->main
    - 1: ->finBueno
    - 2: ->finMalo
    - else:que
}

=== main ===
~donGenaro_inicio_conversacion = true
¡Hola! Tú eres el nuevo, ¿verdad?#speaker: Don Genaro #portrait: pnj_eleganteBigote_neutral #layout: izq
-¿Eres el encargado de ciberseguridad?
    +[Comunicar cambios]
    Sí, espero que estés listo para los cambios.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    ¡¿Cambios?! ¡No me gustan los cambios!#speaker: Don Genaro #portrait: pnj_eleganteBigote_triste #layout: izq
        ~donGenaro_pista_string = "No pude obtener algo interesante, pero parece asustado."
        ~donGenaro_direccion = 2
        ~contador_interacciones_restantes = contador_interacciones_restantes - 1
        ->DONE
    +[Conociendo oficina]
    Sí, estoy conociendo a los colaboradores.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    Te ves agradable, entiendo que existe la posibilidad de cambios.#speaker: Don Genaro #portrait: pnj_eleganteBigote_triste #layout: izq
    ->interaccion2

->END

=== interaccion2 ===
Me dan miedo los cambios...#speaker: Don Genaro #portrait: pnj_eleganteBigote_triste #layout: izq
    + [Explicar beneficios]
    Tranquilo, no afectarán de manera negativa, hay más beneficios.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
        ->finBueno
    + [Cambios drásticos]
    Sí, habrá cambios drásticos.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
        No eres tan agradable como parecías...#speaker: Don Genaro #portrait: pnj_eleganteBigote_triste #layout: izq
        ~contador_interacciones_restantes = contador_interacciones_restantes - 1
        ~donGenaro_pista_string = "No pude obtener algo interesante, pero parece asustado."
        ->finMalo
        ~donGenaro_direccion = 2
->END

=== finBueno ===
Muchas gracias por la tranquilidad que me has dado.#speaker: Don Genaro #portrait: pnj_eleganteBigote_neutral #layout: izq
-¿Sabías que existe un acceso liberado a la base de datos?
~pista_servidores = true
~donGenaro_direccion = 1
~donGenaro_obtuvo_pista = true
~donGenaro_pista_string = "Don Genaro comenta que no existe un acceso restringido a las bases de datos."
~contador_interacciones_restantes = contador_interacciones_restantes - 1
->END

=== finMalo ===
No me vuelvas a hablar, por favor.#speaker: Don Genaro #portrait: pnj_eleganteBigote_neutral #layout: izq
~donGenaro_direccion = 2
->END