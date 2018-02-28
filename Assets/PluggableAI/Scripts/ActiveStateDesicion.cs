using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Desicions/ActiveState")]
public class ActiveStateDesicion : Desicion {

    public override bool Decide(StateController controller)
    {
        return controller.ChaseTarget.gameObject.activeSelf;
    }


}
