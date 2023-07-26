INCLUDE Globals.ink

{pasaste == false: -> main| -> ganaste }

=== main ===
 Bienvenido ¿estás listo para la prueba tecnica? #speaker:Juan Iturbe #portrait:prueba_neutral #layout:izq
 Es la unica forma de ingresa al trabajo
    +[si]
        Muy bien 
        -> pregunta1
    +[no]
        Lo siento vuelve cuando quiera #portrait:prueba_triste

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
Te equivocaste, mucho exito en la siguiente vez #portrait:prueba_triste
-> END

=== ganaste === 
Lo has logrado, ahora puedes ingresar! #speaker:Juan Iturbe #portrait:prueba_feliz
~pasaste = true
->END