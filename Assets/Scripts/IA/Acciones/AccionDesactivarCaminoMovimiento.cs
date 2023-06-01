using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Desactivar Camino Movimiento")]
public class AccionDesactivarCaminoMovimiento : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        //si es que no hay referencia
        if (controller.EnemigoMovimiento == null)
        {
            return;
        }

        controller.EnemigoMovimiento.enabled = false;
    }
}
