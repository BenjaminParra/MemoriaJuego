INCLUDE Globals.ink

{bienvenida_completada != 0: -> main| -> completada }

=== main ===
 Bienvenido, tu debes ser el nuevo encargado de ciberseguridad#speaker: Recepcionista #portrait:recepcionista_neutral #layout:izq
 -Deberías ir a conocer a los demas #speaker: Recepcionista #portrait:recepcionista_neutral #layout:izq
 -¿Ya terminaste ? #speaker: Recepcionista #portrait:recepcionista_neutral #layout:izq
 /*
 
    +[Si]
        Muy bien 
        -> pregunta1
    +[No]
        Lo siento vuelve cuando quieras #portrait:recepcionista_triste
        ->DONE
    +[No lo sé]
        Procura estar seguro y no me hagas perder el tiempo #portrait:recepcionista_triste   
      */  
    

-> END        
        


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
        -> completada
-> END


=== error ===
Te equivocaste, mucho éxito en la próxima vez #portrait:prueba_triste
-> END

=== completada === 
Veo que conociste toda la empresa, ahora ve a tu lugar de trabajo #speaker: Recepcionista #portrait:recepcionista_feliz #layout:izq
~bienvenida_completada = true
->END