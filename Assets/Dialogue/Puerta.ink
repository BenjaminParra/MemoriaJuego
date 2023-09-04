INCLUDE Globals.ink

{aprobo_prueba == false: -> main| -> ganaste }

=== main ===
 Bienvenido, para ver si eres apto para este trabajo deberás superar una prueba técnica#speaker:Mario Ruiz #portrait:prueba_neutral #layout:izq
 ¿Estás listo ? 
 +[Si]
    Muy bien 
        ->pregunta1
    +[No]
        Lo siento vuelve cuando quieras #portrait:prueba_triste
        ->DONE
    +[No lo sé]
        Procura estar seguro y no me hagas perder el tiempo #portrait:prueba_triste  
        ->END        
        


=== pregunta1 ===
La definición de "Red utilizada para comunicación a corta distancia entre dispositivos" corresponde a:
+[LAN]
        Muy bien!
        ->pregunta2
    +[WAN]
        ->error
    +[PAN]
        ->error

->END


=== pregunta2 ===
¿Qué tecnologías se pueden utilizar en una WAN?
    +[ATM]
        ->error
    +[Frame relay]
        ->error
    +[Todas las anteriores]
        Correcto
        ->ganaste
->END


=== error ===
Te equivocaste, mucho éxito en la próxima vez #portrait:prueba_triste
->END

=== ganaste === 
Lo has logrado, ahora puedes ingresar #speaker:Mario Ruiz #portrait:prueba_feliz
~aprobo_prueba = true
->END