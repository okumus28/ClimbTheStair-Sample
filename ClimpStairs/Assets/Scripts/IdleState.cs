using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public RunState runState;
    public Animator characterAnimator;

    public override State RunCurrentState()
    {
        if (Input.GetMouseButton(0))
        {
            //characterAnimator.SetBool("Running", false);
            return runState;
        }
        else
        {
            characterAnimator.SetBool("Running", false);
            return this;
        }

    }
}
