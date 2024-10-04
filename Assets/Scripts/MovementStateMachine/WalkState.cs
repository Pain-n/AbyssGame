using UnityEngine;

public class WalkState : MovementBaseState
{
    private float turnSmoothVelocity;

    public override void EnterState(MovementStateManager manager)
    {
        manager.Controller.PlayerData.Animator.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.C)) manager.SwitchState(manager.CrouchState);
        if (Input.GetKeyDown(KeyCode.LeftShift)) manager.SwitchState(manager.RunState);
        if (Input.GetKeyDown(KeyCode.Space)) manager.SwitchState(manager.JumpState);
        if (manager.Controller.PlayerData.Direction.magnitude < 0.1f) manager.SwitchState(manager.IdleState);
    }

    public override void FixedUpdateState(MovementStateManager manager)
    {
        if (manager.Controller.PlayerData.Direction != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(manager.Controller.PlayerData.Direction.x, manager.Controller.PlayerData.Direction.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(manager.Controller.PlayerData.RB.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, manager.Controller.PlayerData.SmoothRotationTime);
            manager.Controller.PlayerData.RB.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            manager.Controller.PlayerData.RB.velocity = moveDirection.normalized * manager.Controller.PlayerData.MoveSpeed * Time.fixedDeltaTime;
        }
    }

    public override void ExitState(MovementStateManager manager)
    {
        manager.Controller.PlayerData.Animator.SetBool("Walking", false);
    }
}
