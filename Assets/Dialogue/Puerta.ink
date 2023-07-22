INCLUDE Globals.ink

{pasaste == false: -> main| -> ganaste }

=== main ===
 Bienvenido ¿estás listo para la prueba tecnica? #speaker:Jefe #portrait:jefe_neutral #layout:izq
    +[si]
        Muy bien 
        -> pregunta1
    +[no]
        Lo siento vuelve cuando quiera #portrait:jefe_triste

-> END        
        


=== pregunta1 ===
¿Que pokemon es fantasma?
    +[Gengar]
        Muy bien!
        ->pregunta2
    +[Machop]
        ->error
    +[Seal]
        ->error

->END


=== pregunta2 ===
¿Que pokemon es el compañero fiel de ash?
    +[Raichu]
        ->error
    +[Pichu]
        ->error
    +[Pikachu]
        Correcto
        -> ganaste
-> END


=== error ===
Te equivocaste, mucho exito en la siguiente vez #portrait:jefe_triste
-> END

=== ganaste === 
Lo has logrado, ahora puedes ingresar! #speaker:Jefe #portrait:jefe_feliz
~pasaste = true
->END