/*
    Knot
    -> Seccion

=== Seccion ===
    esto es una seccion
-> DONE
*/


/*
    Eleccion Basicas
    Te gusta el cine?
* Si
    A mi igual!    
* No
    Oh, ya no me agradas
*/

/*
    Loops
    -> main 

=== main ===
¿Que pokemon te gusta?
    *[Charmander]
        Elegiste a Charmander!
        ->main
    *[Bulbasaur]
        Elegiste a Bulbasaur!
        ->main
    *[Squirtle]
        Elegiste a squirtle!
        ->main
    * ->  //de esta forma es la ultima opcion del while
    
->DONE
*/
/*
    Ejemplo de dialogo profe
    
    -> main 

=== main ===
¿Que pokemon te gusta?
    *[Charmander]
        Elegiste a Charmander!
        ->FuncionSalida
    *[Bulbasaur]
        Elegiste a Bulbasaur!
        ->main
    *[Squirtle]
        Elegiste a squirtle!
        ->main
    * -> funcion //de esta forma es la ultima opcion del while
    
->DONE

=== funcion ===
esto es una respuesta
-> funcion2 
->DONE

=== funcion2 ===
jiji
->DONE

=== FuncionSalida ===
Lo siento no puedes seguir
-> END
*/

/*
    Sticky choice
    -> main 

=== main ===
¿Que pokemon te gusta?
    +[Charmander]
        Elegiste a Charmander!
        ->main  
    +[Bulbasaur]
        Elegiste a Bulbasaur!
        ->main
    +[Squirtle]
        Elegiste a squirtle!
        ->main
    * ->  //de esta forma es la ultima opcion del while
    
->DONE
*/

/*
    Variable
    VAR miNumero  = 5 esto es global
    temp miNumeroTemporal = 5 es temporal solo vive en el area que se declara
    CONST miConstante = 5 es constante
    Las variables pueden ser bool true o false
                             -> main 
                             string "texto"
    VAR numero = 0
-> main 

=== main ===
¿Que pokemon te gusta?
    *[Charmander]
    //~pokemon = "Charmander" //de esta forma se modifica variable
    //~numero = numero + 1
        ->elegido ("charmander")
    *[Bulbasaur]
        ->elegido("Bulbasaur")
    *[Squirtle]
       ->elegido("Squirtle")
    * ->  //de esta forma es la ultima opcion del while
    
->DONE


=== elegido(pokemon) ===
Elegiste a {pokemon}
-> END
*/


/*
    Waves es algo complejo
    VAR numero = 0
-> main 

=== main ===
Que clima te gusta?
    * Soleado
        Segura?
         * * Si, de verdad
         * * La verdad no lo se
         - - oh, ok
    * Nublado

- Que genial    
-> DONE
*/

/*
    Condicion con bool
    VAR miVariable = true

{miVariable:
    This is written if yourVariable is true.
  - else:
    Otherwise this is written.
}
-----------------------------------------
    Condicion con numeros
    VAR miVariable = 5

{miVariable < 6:
    This is written if yourVariable is true.
  - else:
    Otherwise this is written.
}

---------------------------------------
    Condicion llevandolo a otra seccion
    
    VAR miVariable = 7

{miVariable < 6:
    This is written if yourVariable is true.
  - else:
    ->hola
}
=== hola ===
Wena
-> DONE
--------------------------------------------
    Otra forma de scribir unos if
    VAR miVariable = 7

{miVariable < 5:
    This is written if yourVariable is true.
  - else:
    Otherwise this is written.
}

------------------------------------
    Switch Case
    VAR miVariable = 2

{miVariable:
- 0:    0
- 1:    1
- 2:    -> hola
- else: que

}



=== hola ===
Wena
-> DONE
*/

/*
    Funciones
    {sumar(5,9)}
// numero random entre 1 y 5 {RANDOM(1,5)}
// cuantos interacciones llevo {TURNS()} creo que es para eso
=== function sumar(a,b) ===
~ return a + b

*/

