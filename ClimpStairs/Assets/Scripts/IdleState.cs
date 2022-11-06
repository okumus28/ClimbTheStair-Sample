using UnityEngine;

public class IdleState : State
{
    public RunState runState;
    public Animator characterAnimator;
    public override State RunCurrentState()
    {
        if (Input.GetMouseButton(0))
        {
            return runState;
        }
        else
        {
            characterAnimator.SetBool("Running", false);
            CharacterStats.Instance.StaminaRegenaration();
            return this;
        }
    }
}
