using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour {


	public EnemyStats enemyStats;
	public Transform eyes;
    public State CurrentState;
    public State RemainState;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Complete.TankShooting tankShooting;
	[HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int NextWayPoint;
    [HideInInspector] public Transform ChaseTarget;
    [HideInInspector] public float StateTimeElapsed;
	private bool aiActive;


	void Awake () 
	{
		tankShooting = GetComponent<Complete.TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

    void Update()
    {
        if (!aiActive) return;

        CurrentState.UpdateState(this);
    }

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} else 
		{
			navMeshAgent.enabled = false;
		}
	}

    void OnDrawGizmos()
    {
        if (CurrentState == null || eyes == null) return;
        Gizmos.color = CurrentState.SceneGizmoColor;
        Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != RemainState)
        {
            CurrentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountdownElapsed(float duration)
    {
        StateTimeElapsed += Time.deltaTime;
        return StateTimeElapsed >= duration;
    }

    private void OnExitState()
    {
        StateTimeElapsed = 0;
    }
}