INCLUDE Globals.ink

{contador_interacciones_restantes != 0: ->main| ->completada }

=== main ===
Bienvenido, debes ser el nuevo encargado de ciberseguridad. #speaker: Recepcionista #portrait: recepcionista_neutral #layout: izq
Deberías ir a conocer a los demás. #speaker: Recepcionista #portrait: recepcionista_neutral #layout: izq
¿Ya terminaste? #speaker: Recepcionista #portrait: recepcionista_neutral #layout: izq

->END

=== completada === 
Veo que has conocido toda la empresa. Ahora dirígete a tu lugar de trabajo. #speaker: Recepcionista #portrait: recepcionista_feliz #layout: izq
~abrir_oficina = true

->END