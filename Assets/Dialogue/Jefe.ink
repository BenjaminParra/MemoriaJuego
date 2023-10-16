INCLUDE Globals.ink
INCLUDE preguntas_activos.ink
#speaker:Jefe #portrait:jefe_neutral #layout:izq
#speaker:Jefe #portrait:jefe_neutral #layout:izq
{jefe_direccion:
    - 0:    ->primeraInteraccion //bienvenida
    - 1:    ->segundaInteraccion // no ha visto el contrato
    - 2:    ->terceraInteraccion // el jugador vio el contrato
    - 3:    ->finPrimerDialogo // cuando el jugador ya conversó con el jefe
    - 4:    ->main 
    - 5: -> preguntaActivos
    - else: que
}

=== primeraInteraccion === 
¡Hola! Tú debes ser el encargado de ciberseguridad.
Te doy la bienvenida a la familia.#speaker:Jefe #portrait:jefe_neutral #layout:izq
Primero lo primero,
Te presento tu contrato, estará en la mesa.
Revísalo y si tienes alguna duda, coméntamelo.
~jefe_direccion = 1
~jefe_inicio_conversacion = true
-> DONE

=== segundaInteraccion ===
¿Qué? ¿No has revisado el contrato?
¿Estás seguro? Deberías revisarlo.
Recuerda que está en la mesa.
-> DONE

=== terceraInteraccion ===
Y, ¿Qué te pareció?
¿Tienes alguna duda?
+[Si]
 -> asignaNumero
+[No]
-> final
->END

=== despliegaPreguntas ===
{preguntas_ID:
- 123: -> preguntas123
- 12: -> preguntas12
- 13: -> preguntas13
- 1: -> preguntas1
- 2: -> preguntas2
- 3: -> preguntas3
- 0: -> final
- 23: -> preguntas23
}
->DONE

=== asignaNumero ===

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_2 == true && contrato_obtuvo_pista_3 == false :
~preguntas_ID = 12
->despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == false :
~preguntas_ID = 13
->despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == true :
~preguntas_ID = 123
->despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == false && contrato_obtuvo_pista_2 == false :
~preguntas_ID = 123
->despliegaPreguntas
}

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == false && contrato_obtuvo_pista_2 == true :
~preguntas_ID = 2
->despliegaPreguntas
}

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == false :
~preguntas_ID = 3
->despliegaPreguntas
}
->DONE

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == true :
~preguntas_ID = 23
->despliegaPreguntas
}
->DONE

=== preguntas1 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    ->preguntas1
* ->final 
->END

=== preguntas2 ===
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    ->preguntas2
* ->final 
->END

=== preguntas3 ===
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    ->preguntas3
* ->final 
->END

=== preguntas12 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    ->preguntas12
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    ->preguntas12
* -> final 
->END

=== preguntas13 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    ->preguntas13
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    ->preguntas13
* -> final 
->END

=== preguntas123 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    ->preguntas123
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    -> preguntas123
* [Accsos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    ->preguntas123
* -> final 
->END

=== preguntas23 ===
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    ->preguntas23
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    ->preguntas23
* ->final 
->END

=== final ===
Perfecto, no sé qué debas hacer ni en qué trabajas,
pero ve a hacer tus cosas por ahí. 
Nos vemos.
~abrir_acceso = true
~jefe_direccion = 3
-> END

=== finPrimerDialogo ===
ZZZ... ¿Qué? ¿Yo durmiendo? Estaba meditando.
~jefe_direccion = 4
-> DONE

=== previaPreguntasActivos === 
{contador_interacciones_restantes == 0:
->preguntaActivos
-else:
->finPrimerDialogo
}
-> DONE

=== preguntaActivos ===
¡Hola! Veo que has conocido a la empresa, ¿tienes alguna duda?#speaker:Jefe #portrait:jefe_neutral #layout:izq
+[Activos]
    Quería saber cuáles crees que son los activos de información esenciales para la empresa. #speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
    ->activos
+[Nada]
    Veo que no tienes nada que decir, vuelve cuando quieras. #speaker:Jefe #portrait:jefe_neutral #layout:izq
->DONE

=== activos === 
Mmm... ahora que lo dices, nunca lo había pensado. Creo que los más importantes son: Información de los clientes y código fuente. #speaker:Jefe #portrait:jefe_neutral #layout:izq
¿Se me olvidará algo?
De ser así, enviame un informe de tu listado de activos.
Este informe lo podrás crear en tu estación de trabajo.
El encargado anterior nunca pudo hacer uso de sus herramientas.
Creo que no pasaba ciertos desafíos.
->DONE

=== servidores ===
Es verdad, no tenemos ningún acceso restringido a la sala de servidores. #speaker:Jefe #portrait:jefe_neutral #layout:izq
Deberíamos considerarlo, ya que ahí almacenamos la información de los clientes.
-> DONE