INCLUDE variables_contador.ink
INCLUDE Globals.ink

{ contador_direccion:
    -0: -> main
    -1: -> postConversacionBueno
    -else: -> postConversacionMalo
}

=== main ===
#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
¡Hola! soy el encargado de ciberseguridad
#speaker: ??? #portrait: pnj_eleganteBigote_neutral #layout: izq
...
+[Insistir]
¿Hola? ¿estás muy ocupado? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
¿Disculpa? ¿Acaso no se ve? no me molestes por favor#speaker: ??? #portrait: pnj_eleganteBigote_neutral #layout: izq
~contador_direccion = 2
->DONE
+[Irse]
(Creo que está muy ocupado, hablaré con el luego)#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Hey, espera #speaker: ??? #portrait: pnj_eleganteBigote_neutral #layout: izq
Disculpa si es que no te respondí, soy Christian encargado de la contabilidad de la empresa... #speaker: Christian #portrait: pnj_eleganteBigote_neutral #layout: izq
Como ves tengo todo un desorden buscando el balance del semestre pasado... #speaker: Christian #portrait: pnj_eleganteBigote_triste #layout: izq
LLevo años pidiendo que nos movamos a algo digital, pero existen colegas que les da miedo la tecnología
Parece un chiste siendo que somos una empresa de desarrollo de software
~contador_direccion = 1

->DONE

=== postConversacionMalo ===
¿Otra vez tú? #speaker: ??? #portrait: pnj_eleganteBigote_triste #layout: izq
->DONE


=== postConversacionBueno ===
Un gusto coleguita, seguiré buscando
->DONE