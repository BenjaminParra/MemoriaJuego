INCLUDE Globals.ink
INCLUDE variables_mujer_contabilidad.ink
INCLUDE variables_contador.ink
INCLUDE variables_infoFinanciera.ink

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
// mujer_contabilidad_neutral
~mujer_contabilidad_inicio_conversacion = true
¡Hola! Soy el encargado de ciberseguridad. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Hola, un gusto. Disculpa que no pueda hablar mucho, el ambiente está muy tenso. No hemos podido encontrar un documento importante. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
Te recomendaría no hablarle, no tiene sentido molestarlo...
->DONE

=== segundaVariante ===
~mujer_contabilidad_inicio_conversacion = true
¡¿Qué?! ¿Molestaste a Christian cuando estaba loco por el papel? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
¿Y te respondió? Cuéntame el truco. 
Por cierto, soy Trinidad, asistente de Christian. #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
Christian me comentó que perdió un documento. ¿Suele suceder esto a menudo? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
¿Superaste la prueba para saber si eras el encargado? Ya es la tercera vez en el semestre que damos vuelta la oficina buscando un documento... #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
No sabemos cómo se pierden, quizás se van a la basura... 
Como pudiste notar, cualquier persona puede ingresar a este lugar...
~mujer_contabilidad_direccion = 1
~mujer_contabilidad_obtuvo_pista = true
~mujer_contabilidad_pista_string = "Trinidad nos comenta que se han perdido algunos documentos"
~infoFinanciera_obtuvo_pista_2 = true
~infoFinanciera_pista_string_2 = "Han habido casos de extravío de documentos"
->DONE

=== terceraVariante ===
~mujer_contabilidad_inicio_conversacion = true
¡¿Qué?! ¿Molestaste a Christian cuando estaba loco por el papel? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
Te dije explícitamente que no lo hicieras...
¿Qué es lo que buscan tan desesperadamente? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Te diría, pero ¿cómo sé exactamente que eres el encargado de ciberseguridad? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
Menos mal que junto con Christian tuvimos un curso de ciberseguridad hace un par de meses.
->previaPreguntas

->DONE

=== previaPreguntas ===
Si respondes un par de preguntas relacionadas con los activos y controles, podré contarte qué es lo que sucede. ¿Estás listo? #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
->pregunta1
->DONE

=== pregunta1 ===
A la hora de implementar un estándar de seguridad de la información en una organización, ¿debo aplicarlo completamente? Si no lo hago de esta forma, ¿no podré certificar la organización en el estándar? #speaker: ??? #portrait: mujer_contabilidad_neutral #layout: izq
+[Verdadero]
    Las organizaciones no implementarán todos los estándares mencionados anteriormente, pero estos son recursos valiosos para seleccionar las herramientas adecuadas. A medida que el programa de seguridad evoluciona, se incorporan gradualmente. Aunque cada organización es única, comparten elementos comunes como personas, procesos, datos y tecnología, y es esencial proteger cada uno de estos aspectos. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
    ->finMalo
    ->DONE

+[Falso]
    Es correcto, siguiente pregunta... #speaker: ??? #portrait: mujer_contabilidad_feliz #layout: izq
    ->pregunta2
->DONE

=== pregunta2 ===
La seguridad a través de la oscuridad se refiere a que mis enemigos no son tan listos como uno, por lo que ocultando cómo se hacen las cosas, es suficiente para proteger mis activos de información críticos. #speaker: ??? #portrait: mujer_contabilidad_neutral #layout: izq
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
    Es correcto, un enfoque Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: ??? #portrait: mujer_contabilidad_feliz #layout: izq
    ->finBueno
->DONE
+[Falso]
    Es incorrecto, un enfoque Bottom-up es menos efectivo, no abarca todos los riesgos y finalmente falla estrepitosamente. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
    ->finMalo
->DONE

=== finMalo ===
Lo siento mucho, no puedo darte más información porque no confío en ti. #speaker: ??? #portrait: mujer_contabilidad_triste #layout: izq
~mujer_contabilidad_direccion = 2
~mujer_contabilidad_obtuvo_pista = true
~mujer_contabilidad_pista_string = "Trinidad es muy estricta con revelar información de contabilidad. ¿Habrá sucedido algo malo antes?"
~infoFinanciera_obtuvo_pista_2 = true
~infoFinanciera_pista_string_2 = "Los vi desesperados y son estrictos con conversar temas del área. ¿Habrá sucedido algo malo antes?"
~contador_interacciones_restantes -= 1
->DONE

=== finBueno ===
Definitivamente eres el encargado de ciberseguridad. Mi nombre es Trinidad. #speaker: Trinidad #portrait: mujer_contabilidad_feliz #layout: izq
Ahora te contaré lo que sucede... Ya es la tercera vez en el semestre que damos vuelta la oficina buscando un documento... #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
No sabemos cómo se pierden, quizás se van a la basura... 
Como pudiste notar, cualquier persona puede ingresar a este lugar...
~mujer_contabilidad_direccion = 1
~mujer_contabilidad_obtuvo_pista = true
~mujer_contabilidad_pista_string = "Trinidad nos comenta que se han perdido algunos documentos"
~infoFinanciera_obtuvo_pista_2 = true
~infoFinanciera_pista_string_2 = "Han habido casos de extravío de documentos"
~cantidad_argumentos_infoFinanciera = cantidad_argumentos_infoFinanciera + 1
~contador_interacciones_restantes -= 1
->DONE

=== postConversacionBueno ===
Nos vemos, por favor ayúdanos a hacer más segura la empresa. #speaker: Trinidad #portrait: mujer_contabilidad_neutral #layout: izq
->DONE

=== postConversacionMalo ===
No puedo confiar en ti, nos vemos... #speaker: Trinidad #portrait: mujer_contabilidad_triste #layout: izq
->DONE
