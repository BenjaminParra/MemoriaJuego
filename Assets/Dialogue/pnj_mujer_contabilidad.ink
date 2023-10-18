INCLUDE Globals.ink
INCLUDE variables_mujer_contabilidad.ink
INCLUDE variables_contador.ink

{mujer_contabilidad_direccion:
    -0: ->primeraParte
    -1: ->postConversacionBueno
    -2: ->postConversacionMalo
}

=== primeraParte ===
{contador_direccion:
 -0: ->primerVariante
 -1: ->segundaVariante
 -2: ->terceraVariante
}
->DONE

=== primerVariante ===
//mujer_contabilidad_neutral
~mujer_contabilidad_inicio_conversacion = true
¡Hola! soy el encargado de ciberseguridad #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Hola un gusto, disculpa que no pueda hablarte pero el ambiente está muy tenso, no hemos podido encontrar un documento importante #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
Te recomendaría no hablarle, no tiene sentido molestarlo...
->DONE


=== segundaVariante ===
~mujer_contabilidad_inicio_conversacion = true
¡¿Qué?! ¿Molestaste a Christian cuando estaba loco por el papel? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
¿Y te respondió? cuentame el truco 
Por cierto, soy Trinidad, asistente de Christian #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
Christian me comentó que perdió un documento ¿Suele suceder esto a menudo?#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
¿Superaste la prueba para saber si eras el encargado? Ya es tercera vez en el semestre que damos vuelta la oficina buscando un documento... #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
No sabemos como se pierden, quizás se van a la basura... 
Como pudiste notar cualquier persona puede ingresar a este lugar...
->DONE

=== terceraVariante ===
~mujer_contabilidad_inicio_conversacion = true
¡¿Qué?! ¿Molestaste a Christian cuando estaba loco por el papel? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
Te dije explicitamente que no lo hicieras...
¿Que es lo que buscan tan desesperadamente?#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Te diría, pero ¿Como sé exactamente que eres el encargado de ciberseguridad? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
->previaPreguntas

->DONE

=== previaPreguntas ===
Si me respondes un par de preguntas relacionadas con los activos y controles podré contarte que es lo que sucede ¿estás listo? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
->pregunta1
->DONE

=== pregunta1 ===
A la hora de implementar un estándar de seguridad de la información en una organización, lo debo aplicar completamente. Si no lo aplico de esta forma, no podré certificar la organización en el estándar.#speaker: ??? #portrait: mujer_contabilidad_neutral #layout: izq
+[Verdadero]
    Las organizaciones no implementarán todos los estándares mencionados anteriormente, pero estos son recursos valiosos para seleccionar las herramientas adecuadas. A medida que el programa de seguridad evoluciona, se incorporan gradualmente. Aunque cada organización es única, comparten elementos comunes como personas, procesos, datos y tecnología, y es esencial proteger cada uno de estos aspectos. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
    ->DONE
    ->finMalo

+[Falso]
    Es correcto, siguiente pregunta... #speaker: ??? #portrait: mujer_contabilidad_feliz #layout: izq
    ->pregunta2
->DONE

===pregunta2 ===
La seguridad a través de la oscuridad se refiere a que mis enemigos no son tan listos como uno, por lo que ocultando el como se hacen las cosas, es suficiente para proteger mis activos de información críticos. #speaker: ??? #portrait: mujer_contabilidad_neutral #layout: izq
+[Verdadero]
Es correcto, sigamos con la última pregunta... #speaker: ??? #portrait: mujer_contabilidad_feliz #layout: izq
->pregunta3
->DONE
+[Falso]
Incorrecto, seguridad a través de la oscuridad (se asume que mis enemigos no son tan listos como uno). #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
->finMalo
->DONE

->DONE

=== pregunta3 ===
El programa de seguridad debe estar respaldado totalmente por la alta dirección de la organización. Ya que esto refleja preocupación de esta sobre la protección de sus activos sensibles, entregar los recursos necesarios y que se sigan los lineamientos emanados. #speaker: ??? #portrait: mujer_contabilidad_neutral #layout: izq
+[Verdadero]
    Es correcto, un acercamiento Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: ??? #portrait: mujer_contabilidad_feliz #layout: izq
    ->finBueno
->DONE
+[Falso]
    Es Incorrecto, un acercamiento Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
    ->finMalo
->DONE


=== finMalo ===
Lo siento mucho, no puedo darte más información debido a que no confío en ti. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
~mujer_contabilidad_direccion = 2
~mujer_contabilidad_obtuvo_pista = true
~mujer_contabilidad_pista_string = "Trinidad es muy estricta con revelar información de contabilidad, ¿Habrá sucedido algo malo antes"
->DONE


=== finBueno ===
Definitivamente eres el encargado se ciberseguridad. Mi nombre es Trinidad. #speaker: Trinidad #portrait: mujer_contabilidad_feliz #layout: izq
Ahora te contaré lo que sucede... Ya es tercera vez en el semestre que damos vuelta la oficina buscando un documento... #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
No sabemos como se pierden, quizás se van a la basura... 
Como pudiste notar cualquier persona puede ingresar a este lugar...
~mujer_contabilidad_direccion = 1
~mujer_contabilidad_obtuvo_pista = true
~mujer_contabilidad_pista_string = "Trinidad nos comenta que no existe una restricción para ingresar a la oficina de contabilidad"
->DONE


===postConversacionBueno===
Nos vemos, por favor ayudanos a hacer mas segura la empresa. #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
->DONE

=== postConversacionMalo ===
No puedo confiar en ti, nos vemos... #speaker: Trinidad #portrait: mujer_contabilidad_triste #layout: izq
->DONE






















->DONE