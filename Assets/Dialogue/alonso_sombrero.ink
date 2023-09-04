INCLUDE variables_alonso_sombrero.ink
INCLUDE Globals.ink

{ alonso_sombrero_direccion:
    - 0: ->main
    - 1: ->primeraInteraccion
    - 2: ->postConversacionBueno
    - else: ->postConversacionMalo
}

=== main ===
#speaker: ??? #portrait: pnj_sombrero_neutral #layout: izq
¡Hola! Soy Alonso. Mi sexto sentido me dice que eres el experto en ciberseguridad...
Como ves, pertenezco al área de informáticos... #speaker: Alonso #portrait: pnj_sombrero_neutral #layout: izq
~alonso_sombrero_direccion = 1
->primeraInteraccion
->DONE

=== primeraInteraccion ===
¿Has tenido la oportunidad de conocer a los demás y explorar la empresa? #speaker: Alonso #portrait: pnj_sombrero_neutral #layout: izq
¿Qué te ha parecido?
+[Todo perfecto]
    Todo está perfecto, no tengo ninguna queja en absoluto. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    ¡¿Todo perfecto?! ¿Y tú dices que eres el encargado de ciberseguridad? #speaker: Alonso #portrait: pnj_sombrero_triste #layout: izq
    ~alonso_sombrero_direccion = 3
    ~alonso_sombrero_pista_string = "Alonso parece molesto. ¿Será que hay cosas que no están bien en la empresa?"
    ~alonso_sombrero_inicio_conversacion = true
    ~contador_interacciones_restantes = contador_interacciones_restantes - 1
    ->DONE
+[Algunos problemas]
    Existen algunos problemas en el área de ciberseguridad. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    ¡Por fin! Finalmente alguien reconoce las deficiencias. #speaker: Alonso #portrait: pnj_sombrero_feliz #layout: izq
    ->segundaInteraccion
->DONE

=== segundaInteraccion ===
¿Sabes qué? ¿Puedo contarte algo? #speaker: Alonso #portrait: pnj_sombrero_neutral #layout: izq
Es muy sospechoso que cada vez que estamos a punto de presentar una innovación,
de repente la competencia también presenta exactamente la misma innovación.
¿Será que hay una filtración de información? ¿O nos estarán espiando?
~alonso_sombrero_obtuvo_pista = true
~alonso_sombrero_pista_string = "Alonso nos comenta que existe una extraña coincidencia en cada proyecto publicado. ¿Cómo obtiene la competencia esa información?"
~alonso_sombrero_inicio_conversacion = true
~alonso_sombrero_direccion = 2
~contador_interacciones_restantes = contador_interacciones_restantes - 1
->postConversacionBueno
->DONE

=== postConversacionBueno ===
Procura hablar despacio para que la competencia no nos escuche... hablamos después. #speaker: Alonso #portrait: pnj_sombrero_neutral #layout: izq
->DONE

=== postConversacionMalo ===
Espero que poco a poco te des cuenta de las deficiencias que existen en esta empresa... ¡Necesito aliados! #speaker: Alonso #portrait: pnj_sombrero_neutral #layout: izq
->DONE
