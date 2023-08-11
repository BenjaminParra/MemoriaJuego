INCLUDE Globals.ink

{direccion_1:
- 0:    ->main
- 1:    ->finBueno
- 2:    -> finMalo
- else: que

}


=== main ===
~conversado_1 = true
Hola tú eres el nuevo #speaker:Don Genaro #portrait:pnj_eleganteBigote_neutral #layout:izq

-¿Eres el de ciberseguridad? 
    +[Sí, espero que estés listo para los cambios]
        ¡¿Cambios?! ¡No me gustan los cambios! #portrait:pnj_eleganteBigote_triste #layout:izq
        ~pista_1 = "No logré obtener nada interesante, pero parece asustado"
        ~direccion_1 = 2
        ~bienvenida_completada = bienvenida_completada - 1
        ->DONE
    +[Sí, estoy conociendo a los colaboradores]
    Te ves agradable, entiendo que existe la posibilidad de cambios 
    -> interaccion2    
    
 
->END
=== interaccion2 ===
Me dan miedo los cambios... #portrait:pnj_eleganteBigote_triste
    +[Tranquilo, no afectaran de manera negativa, son mas los beneficios]
        -> finBueno
    +[Si, ¡habrán cambios drasticos!]
        No eres tan agradable como parecías... #portrait:pnj_eleganteBigote_triste
        ~bienvenida_completada = bienvenida_completada - 1
        ->finMalo
        ~direccion_1 = 2
        
~conversado_1 = true
->END

=== finBueno ===
Muchas gracias por la tranquilidad que me has dado, ya estaba pensando en borrar la base de datos #speaker:Don Genaro #portrait:pnj_eleganteBigote_neutral #layout:izq
- Como no existe una clave para acceder a ella 

-Lo cambios me llevan a tomar medidas desesperadas
~direccion_1 = 1
~pista_1_pnj_eleganteBigote = true
~pista_1 = "Don Genaro comenta que no existe un acceso restringido a las bases de datos"
~bienvenida_completada = bienvenida_completada - 1

->END

=== finMalo ===
No me vuelvas a hablar por favor#speaker:Don Genaro #portrait:pnj_eleganteBigote_neutral #layout:izq
~direccion_1 = 2

->END