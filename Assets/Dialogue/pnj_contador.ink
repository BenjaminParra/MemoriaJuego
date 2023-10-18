INCLUDE Globals.ink
INCLUDE variables_contador.ink


{contador_direccion:
    - 0: ->primeraParte
    - 1: ->postConversacionBueno
    - 2: ->postConversacionMalo
}

=== primeraParte ===
    ~contador_inicio_conversacion = true
    ¡Hola! soy el encargado de ciberseguridad #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    ... #speaker: ??? #portrait: pnj_sombrero_neutral #layout: izq
    +[Insistir]
        ¿Hola? ¿estás muy ocupado? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
        ¿Disculpa? ¿Acaso no se ve? no me molestes por favor#speaker: ??? #portrait: pnj_sombrero_neutral #layout: izq
        ~contador_direccion = 2
        ~contador_pista_string = "Se veía demasiado ocupado y deseperado"
        ~contador_obtuvo_pista = true
        ->END
    +[Irse]
        (Creo que está muy ocupado, hablaré con el luego)#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
        Hey, espera #speaker: ??? #portrait: pnj_sombrero_neutral #layout: izq
        Disculpa si es que no te respondí, soy Christian encargado de la contabilidad de la empresa... #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
        ->previaPreguntas

        ->END

=== postConversacionMalo ===
¿Otra vez tú? #speaker: ??? #portrait: pnj_sombrero_neutral #layout: izq
->DONE


=== postConversacionBueno ===
Un gusto coleguita, seguiré buscando #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
->DONE

=== previaPreguntas ===
Si me respondes un par de preguntas relacionadas con los activos y controles podré contarte que es lo que sucede ¿estás listo? #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
->pregunta1
->DONE

=== pregunta1 ===
A la hora de implementar un estándar de seguridad de la información en una organización, lo debo aplicar completamente. Si no lo aplico de esta forma, no podré certificar la organización en el estándar.#speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
+[Verdadero]
    Es falso, las organizaciones no implementarán todos los estándares mencionados anteriormente, pero estos son recursos valiosos para seleccionar las herramientas adecuadas. A medida que el programa de seguridad evoluciona, se incorporan gradualmente. Aunque cada organización es única, comparten elementos comunes como personas, procesos, datos y tecnología, y es esencial proteger cada uno de estos aspectos. #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
    ~contador_direccion = 2
        ~contador_pista_string = "Se veía demasiado ocupado y deseperado"
        ~contador_obtuvo_pista = true
    ->DONE

+[Falso]
    Es correcto, siguiente pregunta... #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
    ->pregunta2
->DONE

===pregunta2 ===
La seguridad a través de la oscuridad se refiere a que mis enemigos no son tan listos como uno, por lo que ocultando el como se hacen las cosas, es suficiente para proteger mis activos de información críticos. #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
+[Verdadero]
Es correcto, sigamos con la última pregunta... #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izqzq
Como ves tengo todo un desorden buscando el balance del semestre pasado... 
        LLevo años pidiendo que nos movamos a algo digital, pero existen colegas que les da miedo la tecnología
        Parece un chiste siendo que somos una empresa de desarrollo de software
        ->pregunta3
->DONE
+[Falso]
Incorrecto, seguridad a través de la oscuridad (se asume que mis enemigos no son tan listos como uno). #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
~contador_direccion = 2
        ~contador_pista_string = "Se veía demasiado ocupado y deseperado"
        ~contador_obtuvo_pista = true
->DONE
=== pregunta3 ===
El programa de seguridad debe estar respaldado totalmente por la alta dirección de la organización. Ya que esto refleja preocupación de esta sobre la protección de sus activos sensibles, entregar los recursos necesarios y que se sigan los lineamientos emanados. #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
+[Verdadero]
    Es correcto, un acercamiento Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
    
        ~contador_direccion = 1
        ~contador_pista_string = "La empresa cuenta con la información financiera en papel y sin respaldo."
        ~contador_obtuvo_pista = true
    ->postConversacionBueno
->DONE
+[Falso]
    Es Incorrecto, un acercamiento Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: Christian #portrait: pnj_sombrero_neutral #layout: izq
    ~contador_direccion = 2
        ~contador_pista_string = "Se veía demasiado ocupado y deseperado"
        ~contador_obtuvo_pista = true
->DONE