INCLUDE Globals.ink
Hola! #speaker:Jefe #portrait:jefe_neutral #layout:izq
{direccion_1:
- 0:    ->main
- else: que

}

=== main ===
¿Como te has sentido en el trabajo?
+ [Feliz]
    Genial! eso me pone contento #portrait:jefe_feliz
+ [Triste]
    Oh, eso me pone triste #portrait:jefe_triste

- Realmente, es un tipo raro #speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der

Bueno ¿Tienes algo mas que decir? #speaker:Jefe #portrait:jefe_neutral #layout:izq
+ [Si]
    -> main
+ [No]
    Entonces, adios!
    -> END