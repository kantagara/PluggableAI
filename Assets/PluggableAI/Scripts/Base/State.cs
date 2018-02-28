using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] Actions;
    public Transition[] Transitions;
    public Color SceneGizmoColor = Color.gray;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        foreach (var action in Actions)
            action.Act(controller);
        
    }

    private void CheckTransitions(StateController controller)
    {
        foreach (var transition in Transitions)
        {
            var desicionSucceeded = transition.Desicion.Decide(controller);

            controller.TransitionToState(desicionSucceeded ? transition.TrueState : transition.FalseState);

        }
    }
}
