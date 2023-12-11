INCLUDE Globals.ink
INCLUDE variables_boris_barba.ink
INCLUDE variables_servidores.ink
INCLUDE variables_control_1_1.ink

{boris_direccion:
    - 0: -> primeraParte
    - 1: -> previaPreguntas
    - 2: ->postConversacionBueno
    - 3: ->postConversacionMalo
    - 11: -> saludo
}

=== saludo ===
Soy Boris, esta es la reunión #speaker: Boris #portrait: pnj_boris_neutral #layout: izq
->DONE
=== primeraParte ===
//pnj_boris_feliz
~boris_inicio_conversacion = true
¿Qué haces aquí? No me digas que eres el encargado de ciberseguridad, siempre intrometido en las áreas#speaker: ??? #portrait: pnj_boris_neutral #layout: izq

... (No puede ser, debe ser el ingeniero de sistemas) #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der

Soy Boris, el ingeniero en sistemas... ¿Que haces aquí? #speaker: Boris #portrait: pnj_boris_neutral #layout: izq

Me encuentro conociendo a la empresa y sus actividades diarias #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der

Ni loco podría contarte nada de lo que sucede en mi área, no he conocido a un encargado de ciberseguridad confiable... #speaker: Boris #portrait: pnj_boris_neutral #layout: izq

Como no hemos tenido un encargado de ciberseguridad he tenido que estudiar mucho respecto a la seguridad de la información...

~boris_direccion = 1
->previaPreguntas
->DONE

=== previaPreguntas ===
¿Crees que tienes mas conocmiento que yo? ¿Podrías superar una pequeña prueba que preparé? #speaker: Boris #portrait: pnj_boris_neutral #layout: izq
Estas preguntas están relacionadas con el manejo de la seguridad de la información y la seguridad física de acceso a los servidores, basadas en los principios de ISO 27001
    +[Si]
    ->pregunta1
    +[No]
        Ok, vuelve cuando estés listo...
        ->DONE

->DONE

=== pregunta1 ===
¿Cuál es el propósito de un plan de respuesta a incidentes según ISO 27001? #speaker: Boris #portrait: pnj_boris_neutral #layout: izq
    +[Evitar cualquier incidente de seguridad.]
        Incorrecto, la respuesta correcta es "Restablecer servicios de TI lo más rápido posible después de un incidente." #speaker: Boris #portrait: pnj_boris_triste #layout: izq
        ->DONE
    +[Restablecer servicios de TI lo más rápido posible después de un incidente.]
        Correcto, un plan de respuesta a incidentes según ISO 27001 tiene como objetivo garantizar una recuperación rápida y eficiente de los servicios de TI en caso de un incidente de seguridad. #speaker: Boris #portrait: pnj_boris_feliz #layout: izq
        ->pregunta2
    +[Realizar auditorías de seguridad periódicas.]   
        Incorrecto, la respuesta correcta es "Restablecer servicios de TI lo más rápido posible después de un incidente." #speaker: Boris #portrait: pnj_boris_triste #layout: izq
        ->DONE
->DONE



=== pregunta2 ===
En el contexto de la seguridad de la información en servidores, ¿qué debería ser una prioridad para prevenir la pérdida de datos? #speaker: Boris #portrait: pnj_boris_neutral #layout: izq
    +[Cifrado de datos en tránsito.]
        Incorrecto, aunque el cifrado es importante la respuesta correcta es "Respaldo de datos regulares y seguros." #speaker: Boris #portrait: pnj_boris_triste #layout: izq
        ->DONE
    +[Implementar sistemas de monitoreo continuo.]   
        Incorrecto, aunque el monitoreo es importante la respuesta correcta es "Respaldo de datos regulares y seguros." #speaker: Boris #portrait: pnj_boris_triste #layout: izq
        ->DONE
    +[Respaldo de datos regulares y seguros.]
        Correcto, aunque el cifrado y el monitoreo son importantes, realizar respaldos de datos regulares y almacenarlos de manera segura es fundamental para prevenir la pérdida de datos en caso de incidentes o fallas.#speaker: Boris #portrait: pnj_boris_feliz #layout: izq
        ->pregunta3

->DONE

=== pregunta3 ===
¿Qué acción es crucial para garantizar la seguridad física de los servidores de una empresa? #speaker: Boris #portrait: pnj_boris_neutral #layout: izq
    +[Realizar auditorías regulares de seguridad.] 
    Incorrecto, aunque las auditorías de seguridad son importantes, la respuesta correcta es "Limitar el acceso físico a ubicaciones clave". #speaker: Boris #portrait: pnj_boris_triste #layout: izq
    ->DONE
    +[Mantener un registro detallado de las amenazas cibernéticas.]
    Incorrecto, aunque el registro de amenazas es importante, la respuesta correcta es "Limitar el acceso físico a ubicaciones clave". #speaker: Boris #portrait: pnj_boris_triste #layout: izq
    ->DONE
    +[Limitar el acceso físico a ubicaciones clave.]
    Correcto, aunque las auditorías de seguridad y el registro de amenazas son importantes, restringir el acceso físico es fundamental para evitar intrusiones no autorizadas en las instalaciones de servidores.#speaker: Boris #portrait: pnj_boris_feliz #layout: izq
    
->DONE

=== postConversacionBueno ===
Me has dejado sin palabras... #speaker: Boris #portrait: pnj_boris_feliz #layout: izq
Realmente estoy enfrente de un excelente profesional, espero que nos ayudes a lidiar con todos los problemas
Gracias, para eso estoy trabajando ¿Puedo ayudarte en algo? #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
Ahora que lo dices... #speaker: Boris #portrait: pnj_boris_triste #layout: izq
Primero, no estamos realizando auditorías de seguridad regulares en nuestros servidores para identificar posibles vulnerabilidades o actividades sospechosas.
~servidores_obtuvo_pista_1 = true
~servidores_pista_string_1 = "No se realizan auditorías de seguridad para identificar vulnerabilidades"

También he notado que no estamos realizando un seguimiento adecuado de las actualizaciones de software en nuestros servidores. Algunos de los sistemas operativos y aplicaciones podrían estar desactualizados y vulnerables a amenazas conocidas.
~servidores_obtuvo_pista_2 = true
~servidores_pista_string_2 = "El software de los servidores se encuantra desactualizado"


->DONE

=== postConversacionMalo === 
Lamentable #speaker: Boris #portrait: pnj_boris_feliz #layout: izq
~control_1_1_persona_finalizado = true
->DONE

















