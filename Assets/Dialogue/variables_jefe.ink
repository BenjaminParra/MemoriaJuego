// pnj_Jefe
// Variable booleana que indica si se ha obtenido una pista o no.
VAR jefe_obtuvo_pista = false

// Variable booleana que indica si se ha iniciado una conversación con el NPC.
VAR jefe_inicio_conversacion = false

// Variable de tipo string que almacena la pista.
VAR jefe_pista_string = "Debería conversar con esta persona"

// Variable numérica que actúa como identificador de la pista.
VAR jefe_id = 1

// Variable numérica que se utiliza para guiar la conversación en el archivo "ink",
// permitiendo usar una estructura "switch case" para dirigir a cada sección del diálogo.
VAR jefe_direccion = 4

// Variable numérica que permite al jugador saber qué preguntas puede realizar.
VAR preguntas_ID = 0


//Bonificador al presupuesto de activos
VAR bonificador_activos = 1.0

//Variable numérica que se utiliza para guiar la conversación en el archivo "ink",
// permitiendo usar una estructura "switch case" para dirigir a cada sección d
VAR preguntas_activos_direccion = 0

VAR actualizoBonificacion = true
