INCLUDE Globals.ink

{pista_1_pnj_eleganteBigote == false: -> main|-> fin}


=== main ===
~conversado_1 = true
Hola tú eres el nuevo #speaker:Don Genaro #portrait:pnj_eleganteBigote_neutral #layout:izq

-¿Eres el de ciberseguridad? 
    +[Sí, espero que estés listo para los cambios]
        ¡¿Cambios?! ¡No me gustan los cambios! #portrait:pnj_eleganteBigote_triste #layout:izq
        
        ->DONE
    +[Sí, estoy conociendo a los colaboradores]
    Te ves agradable, entiendo que existe la posibilidad de cambios 
    -> interaccion2    
    
 
->END
=== interaccion2 ===
Me dan miedo los cambios... #portrait:pnj_eleganteBigote_triste
    +[Tranquilo, no afectaran de manera negativa, son mas los beneficios]
        -> fin
    +[Si, ¡habrán cambios drasticos!]
        No eres tan agradable como parecías... #portrait:pnj_eleganteBigote_triste
        
~conversado_1 = true
->END

=== fin ===
Muchas gracias por la tranquilidad que me has dado, ya estaba pensando en borrar la base de datos #speaker:Don Genaro #portrait:pnj_eleganteBigote_neutral #layout:izq
- Como no existe una clave para acceder a ella 

-Lo cambios me llevan a tomar medidas desesperadas

~pista_1_pnj_eleganteBigote = true
~pista_1 = "Don Genaro comenta que no existe un acceso restringido a las bases de datos"
~bienvenida_completada = bienvenida_completada - 1

->END