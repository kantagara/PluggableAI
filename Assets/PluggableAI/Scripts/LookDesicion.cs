using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Desicions/Look")]
public class LookDesicion : Desicion
{
    public override bool Decide(StateController controller)
    {
        return Look(controller);
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);

        if (!Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius,
                controller.eyes.forward, out hit, controller.enemyStats.lookRange) ||
            !hit.collider.CompareTag("Player")) return false;

        controller.ChaseTarget = hit.transform;
        return true;

    }
}
