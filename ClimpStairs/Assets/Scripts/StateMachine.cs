using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]State currentState;

    // Update is called once per frame
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
