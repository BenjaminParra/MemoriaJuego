INCLUDE Globals.ink
INCLUDE variables_pnj_sofia.ink
INCLUDE variables_documentacionProyectos.ink
{sofia_direccion:
    -0:->main
    -1:->previaPreguntas
    -2:->finalMalo
    -3:->finalBueno
    -11:->correo
}

=== correo ===
{tiempoFinalizado_sofia:
    Es muy tarde, no puedo verte #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
    -> DONE
  - else:
    Hola bienvenido ¿Que debemos hablar? #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
    Necesitaba conversar contigo debido a que necesito que me ayudes #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    Actualmente carecemos de un encargado para el establecimiento y mantenimiento del inventario de los activos de la empresa #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    Es por esto que el encargado de realizarlo serás tú. 
    Ante cualquier duda, puedes contactarme...
    ->postCorreo
    ->DONE
}

=== postCorreo ==
Todo va de maravilla #speaker: Sofia #portrait: pnj_sofia_feliz #layout: izq
->DONE
=== main ===
~sofia_inicio_conversacion = true
¡Hey! ¿Eres el encargado de ciberseguridad? #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
Soy Sofía, y aunque conozco algo relacionado con la ciberseguridad debido a un curso que hice en mi empresa anterior,
necesito comunicarte algunas cosas sobre la documentación de los proyectos. #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
Pero... ¿Crees que podrás entender lo que tengo que decir?
Me gustaría asegurarme, así que quiero hacerte algunas preguntas. ¿Te parece?
+[Si]
~contador_interacciones_restantes -= 1
->pregunta1
+[No]
Vuelve cuando estés listo para hablar. #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
~contador_interacciones_restantes -= 1
~sofia_direccion = 1
->DONE

=== previaPreguntas ===
Ah, eres tú. ¿Estás listo?
+[Si]
->pregunta1
+[No]
Vuelve cuando estés listo para hablar. #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
->DONE

=== pregunta1 ===
¿Cuáles son algunas consideraciones clave para almacenar de manera segura la documentación de proyectos de software? #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
+[Minimizar el uso de contraseñas y confiar en la autenticación por IP.]
Incorrecto, la minimización del uso de contraseñas no es una práctica segura, y confiar en la autenticación por IP por sí sola no es suficiente. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE
+[Aplicar cifrado y autenticación sólida para evitar el acceso no autorizado.]
Interesante idea... #speaker: Sofia #portrait: pnj_sofia_feliz #layout: izq
->pregunta2
+[Publicar los documentos en un servidor web interno.]
Eso no garantiza la seguridad ni la protección adecuada. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE

=== pregunta2 ===
¿Cuál es el propósito principal del cifrado en la protección de la documentación de proyectos confidenciales? #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
+[Prevenir la exposición de información confidencial en caso de una brecha de seguridad.]
Bien dicho... #speaker: Sofia #portrait: pnj_sofia_feliz #layout: izq
->pregunta3
+[Facilitar el acceso a los documentos para los empleados.]
Incorrecto... El cifrado es esencial en la protección de datos confidenciales y previene la exposición de información en caso de una violación de seguridad. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE
+[Ralentizar el acceso a los documentos para aumentar la seguridad.]
Incorrecto... El cifrado no tiene el propósito de ralentizar el acceso, sino de proteger la información. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE

=== pregunta3 ===
¿Cuáles son las mejores prácticas para gestionar permisos de acceso a la documentación de proyectos en una organización? #speaker: Sofia #portrait: pnj_sofia_neutral #layout: izq
+[Asignar permisos de solo lectura a todos los empleados para facilitar el acceso.]
Lo que dices no es un enfoque efectivo ni seguro. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE
+[Otorgar acceso sin restricciones a todos los documentos para ahorrar tiempo.]
¿De verdad? Lo que dices es arriesgado y poco controlado. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->finalMalo
->DONE
+[Establecer permisos basados en roles y revisar regularmente los accesos para mantener la relevancia.]
Excelente. #speaker: Sofia #portrait: pnj_sofia_feliz #layout: izq
->postPreguntas
->DONE

=== postPreguntas ===
¡Increíble! Realmente me sorprendiste. #speaker: Sofia #portrait: pnj_sofia_feliz #layout: izq
Veo que hablamos el mismo idioma, y quiero pedirte que nos ayudes. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
Últimamente no tenemos ninguna garantía de la integridad de nuestra documentación de proyectos.
He oído casos donde los ciberdelincuentes roban archivos y no tenemos respaldo ni cifrado... #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
~sofia_pista_string = "Sofía nos comenta que no existe respaldo ni cifrado de la documentación de los proyectos"
~sofia_obtuvo_pista = true
~documentacion_obtuvo_pista_2 = true
~documentacion_pista_string_2 = "No existe respaldo ni cifrado de la documentación de los proyectos"

~cantidad_argumentos_documentacionProyectos = cantidad_argumentos_documentacionProyectos + 1
~sofia_direccion = 3
->finalBueno
->DONE

=== finalMalo ===
Lo siento, no puedo contarte lo que sucede... No me entenderías. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
~sofia_pista_string = "Sofía nos iba a comentar algo sobre la documentación de los proyectos"
~sofia_obtuvo_pista = true
~sofia_direccion = 2
~documentacion_obtuvo_pista_2 = true
~documentacion_pista_string_2 = "Existen falencias según un trabajador"
->DONE

=== finalBueno ===
Ten en consideración lo que te acabo de decir, por favor. #speaker: Sofia #portrait: pnj_sofia_triste #layout: izq
->DONE