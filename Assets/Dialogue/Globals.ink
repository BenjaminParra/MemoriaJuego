// Variable booleana que controla si se aprobó la prueba.
VAR aprobo_prueba = false


// Variable numérica que depende de la cantidad de NPCs interactuables.
// Esta variable controla el acceso al puesto de trabajo del usuario.
VAR contador_interacciones_restantes = 3

// Variable booleana que controla el acceso al puesto de trabajo del usuario.
VAR abrir_oficina = false

VAR abrir_acceso = false

/*
-------------------------------------------------------------------
                    Variables pistas
-------------------------------------------------------------------
*/
// pnj_donGenaro

// Variable booleana que indica si se ha obtenido una pista o no.
VAR donGenaro_obtuvo_pista = false

// Variable booleana que indica si se ha iniciado una conversación con el NPC.
VAR donGenaro_inicio_conversacion = false

// Variable de tipo string que almacena la pista.
VAR donGenaro_pista_string = "Debería conversar con esta persona"

// Variable numérica que actúa como identificador de la pista.
VAR donGenaro_id = 0

// Variable numérica que se utiliza para guiar la conversación en el archivo "ink",
// permitiendo usar una estructura "switch case" para dirigir a cada sección del diálogo.
VAR donGenaro_direccion = 0

//________________________________________________________________________________________





//________________________________________________________________________________
//---------------------------Contrato----------------------------------------------
//____________________________________________________________________________________
// contrato pista 1
// Variable booleana que indica si se ha obtenido una pista o no.
VAR contrato_obtuvo_pista_1 = false

// Variable de tipo string que almacena la pista.
VAR contrato_pista_1_string = "No veo nada raro"


// contrato pista 2
// Variable booleana que indica si se ha obtenido una pista o no.
VAR contrato_obtuvo_pista_2 = false
// Variable de tipo string que almacena la pista.
VAR contrato_pista_2_string = "No veo nada raro"

// contrato pista 3
// Variable booleana que indica si se ha obtenido una pista o no.
VAR contrato_obtuvo_pista_3 = false

// Variable de tipo string que almacena la pista.
VAR contrato_pista_3_string = "No veo nada raro"

// Variable numérica que se utiliza para guiar la conversación en el archivo "ink",
// permitiendo usar una estructura "switch case" para dirigir a cada sección del diálogo.
VAR contrato_direccion = 0

//_____________________________________________________________
// --------------- Variables para el informe -----
// _________________________________________________
VAR verdadero = true
VAR once = 11
// pista_servidores
VAR pista_servidores =false

// pista_listadoClientes
VAR pista_listadoClientes = false

VAR pista_documentacionProyectos = false

VAR pista_servicioWeb = false 

VAR pista_infoFinanciera = false


//_____________________________________________________________
// --------------- Variables para la asignacion de presupuesto -----
// _________________________________________________

VAR dinero_asignado = 500
VAR presupuesto_asignado = false

//_____________________________________________________________________________
//----------------- Variables para conocer cantidas de argumentos por activos
//________________________________________________________________________________
VAR cantidad_argumentos_servidores = 0

VAR cantidad_argumentos_servicioWeb = 0

VAR cantidad_argumentos_infoFinanciera = 0

VAR cantidad_argumentos_documentacionProyectos = 0

VAR cantidad_argumentos_listadoClientes = 0

