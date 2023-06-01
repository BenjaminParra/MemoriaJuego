using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Activar Camino Movimiento")]
public class AccionActivarCaminoMovimiento : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        //si es que no hay referencia
        if (controller.EnemigoMovimiento == null) 
        {
            return;
        }

        controller.EnemigoMovimiento.enabled = true;
    }
}
