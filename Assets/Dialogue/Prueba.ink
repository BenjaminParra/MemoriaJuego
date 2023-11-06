VAR pais = ""
-> main
=== main ===
¿A qué país vas a ir?
    + [Brasil]
     ~ pais = "Brasil"
        {pais}, el país del fútbol
        -> END
    + [Argentina]
    ~ pais = "Argentina"
        {pais}, hay que aprovechar el cambio monetario
        -> END
    + [Perú]
    ~ pais = "Perú"
        {pais}, deberías visitar Machu Picchu

-> END
