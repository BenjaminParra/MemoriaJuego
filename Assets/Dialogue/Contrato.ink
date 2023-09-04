INCLUDE Globals.ink
INCLUDE variables_jefe.ink
#speaker:Contrato #portrait:contrato #layout:izq

{contrato_direccion:
-0: ->primeraParte
-1: ->finContrato
-else: que
}

~jefe_direccion = 2

=== primeraParte ===
La jornada de trabajo será de 09:00 am a 18:00 pm, la asistencia se anota en el libro.
    +[¿En un libro?]
     ¿En un libro? Debería haber un control biométrico #speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
    ~contrato_obtuvo_pista_1 = true
    ~contrato_pista_1_string = "Solo utilizan un libro para marcar"
     ->segundaParte
    +[Me parece bien]
     ->segundaParte
->DONE

=== segundaParte ===
Contamos con servidores, si necesitas acceder a ellos recuerda pedirle la llave al personal de aseo.#speaker:Contrato #portrait:contrato #layout:izq
    +[¿Acceso deliberado?]
    ¿Puedo simplemente pedirla? Debería haber mas seguridad #speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
    ~contrato_obtuvo_pista_2 = true
    ~contrato_pista_2_string = "Acceso con una llave de acceso libre"
     ->terceraParte
     +[Me parece bien]
     ->terceraParte
->DONE


=== terceraParte ===
Respecto a los trabajos asignados, confíamos en que no serán revelados. Somos una familia#speaker:Contrato #portrait:contrato #layout:izq
    +[¿Confidencialidad?]
    ¿No existe pacto de confidencialidad? Que confiados #speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
    ~contrato_obtuvo_pista_3 = true
    ~contrato_pista_3_string = "Parece no existir un pacto de confidencialidad"
     ->finContrato
     +[Me parece bien]
     ->finContrato

->DONE

=== finContrato === 
Esperamos que estés a gusto#speaker:Contrato #portrait:contrato #layout:izq
Veo que no son muy detallista en este contrato#speaker:Personaje Principal #portrait:personaje_principal_neutral #layout:der
~contrato_direccion = 1
~jefe_direccion = 2
->DONE