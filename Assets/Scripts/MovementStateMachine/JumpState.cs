using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager manager)
    {
        if (manager.PreviousState == manager.IdleState) manager.Controller.PlayerData.Animator.SetTrigger("IdleJump");
        if (manager.PreviousState == manager.WalkState || manager.PreviousState == manager.RunState) manager.Controller.PlayerData.Animator.SetTrigger("RunJump");
    }

    public override void UpdateState(MovementStateManager manager)
    {
        if (manager.Controller.PlayerData.IsInAir && manager.Controller.IsGrounded())
        {
            manager.Controller.PlayerData.IsInAir = false;
            if (manager.Controller.PlayerData.Direction == Vector2.zero) manager.SwitchState(manager.IdleState);
            else
            {
                if (Input.GetKey(KeyCode.LeftShift)) manager.SwitchState(manager.RunState);
                else manager.SwitchState(manager.WalkState);
            }
        }
    }

    public override void FixedUpdateState(MovementStateManager manager)
    {
        
    }

    public override void ExitState(MovementStateManager manager)
    {

    }
}
