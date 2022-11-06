using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]State currentState;

    void Update()
    {
        RunStateMachine();
    }

    void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
