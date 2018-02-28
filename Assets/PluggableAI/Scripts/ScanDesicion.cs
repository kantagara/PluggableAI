using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Desicions/Scan")]
public class ScanDesicion : Desicion
{
    public override bool Decide(StateController controller)
    {
       return Scan(controller);
    }

    private bool Scan(StateController controller)
    {
        controller.navMeshAgent.isStopped = true;
        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
        return  controller.CheckIfCountdownElapsed(controller.enemyStats.searchDuration);
    }
}
