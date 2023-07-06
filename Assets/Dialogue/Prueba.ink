VAR pokemoncito = ""
-> main
=== main ===
Wich pokemon do you choose?
    + [Charmander]
     ~ pokemoncito = "charmander"
        Elegiste a {pokemoncito}, excelente tipo fuego
        -> END
       // -> chosen("Charmander")
    + [Bulbasaur]
    ~ pokemoncito = "Bulbasaur"
    Elegiste a {pokemoncito}, excelente tipo planta
        //-> chosen("Bulbasaur")
        -> END
    + [Squirtle]
    ~ pokemoncito = "Squirtle"
    Elegiste a {pokemoncito}, excelente tipo agua
        //-> chosen("Squirtle")

/*
//=== chosen(pokemon) ===
You chose {pokemon}!*/
-> END