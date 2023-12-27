INCLUDE Globals.ink
INCLUDE preguntas_activos.ink

#speaker: Jefe #portrait: jefe_neutral #layout: izq

{jefe_direccion:
    - 0: -> primeraInteraccion
    - 1: -> segundaInteraccion
    - 2: -> terceraInteraccion
    - 3: -> finPrimerDialogo
    - 4: -> main
    - 5: -> preguntaActivos
    - 6: -> comunicaActivos
    - else: que
}

=== primeraInteraccion ===
¡Hola! Tú debes ser el encargado de ciberseguridad.
Te doy la bienvenida a la familia. #speaker: Jefe #portrait: jefe_neutral #layout: izq
Primero lo primero, te presento tu contrato, estará en la mesa. Revísalo y si tienes alguna duda, coméntamelo.
~jefe_direccion = 1
~jefe_inicio_conversacion = true
-> DONE

=== segundaInteraccion ===
¿Qué? ¿No has revisado el contrato? ¿Estás seguro? Deberías revisarlo. Recuerda que está en la mesa.
-> DONE

=== terceraInteraccion ===
Y, ¿Qué te pareció? ¿Tienes alguna duda?
+[Si]
 -> asignaNumero
+[No]
-> final
-> END

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
-> DONE

=== asignaNumero ===
{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_2 == true && contrato_obtuvo_pista_3 == false:
~preguntas_ID = 12
-> despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == false:
~preguntas_ID = 13
-> despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == true:
~preguntas_ID = 123
-> despliegaPreguntas
}

{contrato_obtuvo_pista_1 == true && contrato_obtuvo_pista_3 == false && contrato_obtuvo_pista_2 == false:
~preguntas_ID = 123
-> despliegaPreguntas
}

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == false && contrato_obtuvo_pista_2 == true:
~preguntas_ID = 2
-> despliegaPreguntas
}

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == false:
~preguntas_ID = 3
-> despliegaPreguntas
}
-> DONE

{contrato_obtuvo_pista_1 == false && contrato_obtuvo_pista_3 == true && contrato_obtuvo_pista_2 == true:
~preguntas_ID = 23
-> despliegaPreguntas
}
-> DONE

=== preguntas1 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    -> preguntas1
* -> final
-> END

=== preguntas2 ===
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    -> preguntas2
* -> final
-> END

=== preguntas3 ===
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    -> preguntas3
* -> final
-> END

=== preguntas12 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    -> preguntas12
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    -> preguntas12
* -> final
-> END

=== preguntas13 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    -> preguntas13
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    -> preguntas13
* -> final
-> END

=== preguntas123 ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse.
    -> preguntas123
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    -> preguntas123
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    -> preguntas123
* -> final
-> END

=== preguntas23 ===
* [Confidencialidad]
    ¿Para qué es eso? Si acá todos somos familia, confío en mis colaboradores.
    -> preguntas23
* [Accesos restringidos]
    La verdad, todos tenemos una especie de llave maestra.
    -> preguntas23
* -> final
-> END

=== final ===
Perfecto, no sé qué debas hacer ni en qué trabajas, pero ve a hacer tus cosas por ahí. Nos vemos. Ahora puedes ingresar a la oficina
~abrir_acceso = true
~jefe_direccion = 3
-> END

=== finPrimerDialogo ===
ZZZ... ¿Qué? ¿Yo durmiendo? Estaba meditando.
~jefe_direccion = 4
-> DONE

=== previaPreguntasActivos ===
{contador_interacciones_restantes == 0:
-> preguntaActivos
-else:
-> finPrimerDialogo
}
-> DONE

=== preguntaActivos ===
¡Hola! Veo que has conocido a la empresa, ¿tienes alguna duda? #speaker: Jefe #portrait: jefe_neutral #layout: izq
+[Activos]
    Quería saber cuáles crees que son los activos de información esenciales para la empresa. #speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
    -> activos
+[Nada]
    Veo que no tienes nada que decir, vuelve cuando quieras. #speaker: Jefe #portrait: jefe_neutral #layout: izq
-> DONE

=== activos ===
Mmm... ahora que lo dices, nunca lo había pensado. Creo que los más importantes son: Información de los clientes y código fuente. #speaker: Jefe #portrait: jefe_neutral #layout: izq
¿Se me olvidará algo? De ser así, envíame un informe de tu listado de activos. Este informe lo podrás crear en tu estación de trabajo. El encargado anterior nunca pudo hacer uso de sus herramientas. Creo que no pasaba ciertos desafíos.
-> DONE

=== servidores ===
Es verdad, no tenemos ningún acceso restringido a la sala de servidores. #speaker: Jefe #portrait: jefe_neutral #layout: izq
Deberíamos considerarlo, ya que ahí almacenamos la información de los clientes.
-> DONE

=== comunicaActivos ===
Vi que enviaste un informe de activos #speaker: Jefe #portrait: jefe_neutral #layout: izq
{pista_servicioWeb:
    Veo que seleccionaste el servicio web como activo con {cantidad_argumentos_servicioWeb} de argumentos.
    {cantidad_argumentos_servicioWeb == 0:
    Sin embargo, el presupuesto adicional será 0 debido a que no tienes ningún argumento.
    -else:
    El presupuesto adicional que se otorgará por los argumentos dados es de {calculaPresupuestoUnitario(cantidad_argumentos_servicioWeb)}.
    ~dinero_asignado += calculaPresupuestoUnitario(cantidad_argumentos_servicioWeb)
    }
}

{pista_servidores:
    Veo que seleccionaste los servidores como activo con {cantidad_argumentos_servidores} de argumentos.
    {cantidad_argumentos_servidores == 0:
    Sin embargo, el presupuesto adicional será 0 debido a que no tienes ningún argumento.
    -else:
    El presupuesto adicional que se otorgará por los argumentos dados es de {calculaPresupuestoUnitario(cantidad_argumentos_servidores)}.
    ~dinero_asignado += calculaPresupuestoUnitario(cantidad_argumentos_servidores)
    }
}

{pista_listadoClientes:
    Veo que seleccionaste el listado de clientes como activo con {cantidad_argumentos_listadoClientes} de argumentos.
    {cantidad_argumentos_listadoClientes == 0:
    Sin embargo, el presupuesto adicional será 0 debido a que no tienes ningún argumento.
    -else:
    El presupuesto adicional que se otorgará por los argumentos dados es de {calculaPresupuestoUnitario(cantidad_argumentos_listadoClientes)}.
    ~dinero_asignado += calculaPresupuestoUnitario(cantidad_argumentos_listadoClientes)
    }
}

{pista_infoFinanciera:
    Veo que seleccionaste la información financiera como activo con {cantidad_argumentos_infoFinanciera} de argumentos.
    {cantidad_argumentos_infoFinanciera == 0:
    Sin embargo, el presupuesto adicional será 0 debido a que no tienes ningún argumento.
    -else:
    El presupuesto adicional que se otorgará por los argumentos dados es de {calculaPresupuestoUnitario(cantidad_argumentos_infoFinanciera)}.
    ~dinero_asignado += calculaPresupuestoUnitario(cantidad_argumentos_infoFinanciera)
    }
}

{pista_documentacionProyectos:
    Veo que seleccionaste la documentación de los proyectos como activo con {cantidad_argumentos_documentacionProyectos} de argumentos.
    {cantidad_argumentos_documentacionProyectos == 0:
    Sin embargo, el presupuesto adicional será 0 debido a que no tienes ningún argumento.
    -else:
    El presupuesto adicional que se otorgará por los argumentos dados es de {calculaPresupuestoUnitario(cantidad_argumentos_documentacionProyectos)}.
    ~dinero_asignado += calculaPresupuestoUnitario(cantidad_argumentos_documentacionProyectos)
    }
}
->presupuestoFinal
-> DONE

=== function calculaPresupuestoUnitario(cantidadArgumentos) ===

~ return cantidadArgumentos * 100

=== presupuestoFinal ===
La dirección determinó que los activos esenciales para la empresa son: servidores, listado de clientes, documentación de proyectos, información financiera y los servicios de alojamiento web. #speaker: Jefe #portrait: jefe_neutral #layout: izq
Como base tu presupuesto para realizar operaciones será de 100 por cada activo, es decir, 500 #speaker: Jefe #portrait: jefe_neutral #layout: izq
Considerando bonificaciones y demases el presupuesto asignado es de {dinero_asignado}
~presupuesto_asignado = true
-> DONE
