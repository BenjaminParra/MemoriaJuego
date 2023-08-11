INCLUDE Globals.ink
#speaker:Jefe #portrait:jefe_neutral #layout:izq
{direccion_2:
- 0:    ->primeraInteraccion
- 1: -> segundaInteraccion
- 2: -> terceraInteraccion
- 3: -> finPrimerDialogo
- else: que

}
=== primeraInteraccion === 
¡Hola! Tú debes ser el encargado de ciberseguridad
Te doy bienvenida a la familia #speaker:Jefe #portrait:jefe_neutral #layout:izq
Primero lo primero
Te presento tu contrato, estará en tu inventario
Ahí se almacenarán diversos objetos que vayas encontrando
Revísalo y me comentas si tienes alguna duda
~direccion_2 = 2

-> DONE


=== segundaInteraccion ===
¿Qué? ¿no has revisado el contrato? 
¿Estás seguro? deberías revisarlo
-> DONE

=== terceraInteraccion ===
Y ¿Qué te pareció?
¿Alguna duda?
+[Si]
 -> preguntas

+[No]
-> final
->END


=== preguntas ===
* [Control biométrico]
    ¿Para marcar entradas? No, solo tenemos uno donde deben anotarse
    -> preguntas
* [Claúsula de confidencialidad]
    ¿Para que es eso? si acá todos somos familia, confio en mis colaboradores
    -> preguntas
* [Accesos restringidos]
    La verdad todos tenemos una especie de llave maestra
    -> preguntas
    
* -> final 
 
->END

=== final ===
Perfecto, no se que debas hacer ni que haces
pero ve a hacer tus cosas por ahí. 
Nos vemos
~direccion_2 = 3
-> END

=== finPrimerDialogo ===
ZZZ... ¿Qué? ¿Yo durmiendo? Estaba meditando
-> DONE