using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager manager)
    {

    }

    public override void UpdateState(MovementStateManager manager)
    {
        if(manager.Controller.PlayerData.Direction.magnitude > 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) manager.SwitchState(manager.RunState);
            else manager.SwitchState(manager.WalkState);
        }
        if (Input.GetKeyDown(KeyCode.C)) manager.SwitchState(manager.CrouchState);
        if (Input.GetKeyDown(KeyCode.Space)) manager.SwitchState(manager.JumpState);
    }

    public override void FixedUpdateState(MovementStateManager manager)
    {

    }

    public override void ExitState(MovementStateManager manager)
    {

    }
}
