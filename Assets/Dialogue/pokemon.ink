INCLUDE Globals.ink
{pokemon_name == "": -> main|-> already_chose}

=== main ===
¿Cual pokemon eliges?
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")


=== chosen(pokemon) ===
~pokemon_name = pokemon
¡Elegiste a {pokemon}!
-> END

=== already_chose ===
You already choose {pokemon_name}
-> END


