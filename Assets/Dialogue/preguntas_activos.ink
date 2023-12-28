INCLUDE variables_jefe.ink
=== main ===

{preguntas_activos_direccion:
-0: ->preludio
-1: ->pregunta_activos_1
-2: ->pregunta_activos_2
-3: ->pregunta_activos_3
-4: ->fin_preguntasActivos
}

->DONE
=== preludio ===
Hola quería conversar con usted para comentarle respecto a los activos de la empresa.#speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
¿Activo? Me suena ese concepto ¿Me puedes explicar? #speaker:Jefe #portrait:jefe_triste #layout:izq
~preguntas_activos_direccion = 1
-> main
=== pregunta_activos_1 ===
Un activo es cualquier cosa de valor para una empresa que requiera protección, incluyendo, software, _________ y activos empresariales.#speaker: Personaje Principal #portrait: personaje_principal_neutral #layout: der
+[Maquinaria]
    La maquinaria es un tipo de activo empresarial #speaker:Sistema #portrait:Incorrecta #layout:izq
    Se ha penalizado en un 0.1 el multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_triste #layout:izq
    ~preguntas_activos_direccion = 2
    ->funcion_restar_bonificacion

+[Información]
    ¿Información? Interesante, me hace sentido #speaker:Jefe #portrait:jefe_neutral #layout:izq
    Se ha añadido un 0.1 al multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_feliz #layout:izq
    ~preguntas_activos_direccion = 2
    ->funcion_sumar_bonificacion

+[Clientes]
    ¿Clientes? sé que son importantes, pero ¿estos no se consideran un tipo de activos empresariales? #speaker:Sistema #portrait:Incorrecta #layout:izq
//La idea es que luego de cada pregunta se presente bonificación para que
// el jefe nos de recursos
Se ha penalizado en un 0.1 el multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_triste #layout:izq
    ~preguntas_activos_direccion = 2
    ->funcion_restar_bonificacion
-> DONE

=== pregunta_activos_2 ===
Los activos importantes para la empresa solo son los que generan valor monetario y de bajo costo por proteger.#speaker:Jefe #portrait:jefe_feliz #layout:izq
+[Verdadero]
No todos los activos empresariales se traducen directamente en valor monetario#speaker:Sistema #portrait:Incorrecta #layout:izq
Algunos activos pueden ser difíciles de cuantificar en términos monetarios pero aún así son importantes para el éxito a largo plazo de la empresa.
 Se ha penalizado en un 0.1 el multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_triste #layout:izq
~preguntas_activos_direccion = 3
->funcion_restar_bonificacion
+[Falso]
No todos los activos empresariales se traducen directamente en valor monetario#speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
Algunos activos pueden ser difíciles de cuantificar en términos monetarios pero aún así son importantes para el éxito a largo plazo de la empresa.
~preguntas_activos_direccion = 3
Se ha añadido un 0.1 al multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_feliz #layout:izq
    ->funcion_sumar_bonificacion
->DONE

=== pregunta_activos_3 ===
Entiendo, entonces los activos serían solo las aplicaciones y dispositivos que tenemos en la empresa. #speaker:Jefe #portrait:jefe_feliz #layout:izq
+[Verdadero]
Lo que describe solo contempla lo que es Activos de software y de hardware#speaker:Sistema #portrait:Incorrecta #layout:izq
Pero no se puede dejar de lado lo que es activos de información
Los cuales comprenden la información almacenada en bases de datos y
sistemas de archivos, tanto locales como remotos en la nube.
 Se ha penalizado en un 0.1 el multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_triste #layout:izq
~preguntas_activos_direccion = 4
->funcion_restar_bonificacion

+[Falso]
Lo que describe solo contempla lo que es Activos de software y de hardware#speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
Pero no se puede dejar de lado lo que es activos de información
Los cuales comprenden la información almacenada en bases de datos y
sistemas de archivos, tanto locales como remotos en la nube.
~preguntas_activos_direccion = 4
Se ha añadido un 0.1 al multiplicador de bonificación de presupuesto#speaker:Sistema #portrait:emoji_feliz #layout:izq
->funcion_sumar_bonificacion
~actualizoBonificacion = false
->DONE


=== funcion_restar_bonificacion===
{bonificador_activos == 1 || bonificador_activos < 1.1 :
    ~bonificador_activos = 1 
  - else:
    ~bonificador_activos = bonificador_activos - 0.1
}
->main


=== funcion_sumar_bonificacion===
~bonificador_activos = bonificador_activos + 0.1
->main

=== fin_preguntasActivos ===
Perfecto ahora me queda un poco mas claro lo que son los activos...#speaker:Jefe #portrait:jefe_feliz #layout:izq

->DONE