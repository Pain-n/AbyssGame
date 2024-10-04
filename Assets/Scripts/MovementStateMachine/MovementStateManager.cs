using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public PlayerController Controller;

    private MovementBaseState CurrentState;
    public MovementBaseState PreviousState { get; private set; }

    public IdleState IdleState = new IdleState();
    public WalkState WalkState = new WalkState();
    public RunState RunState = new RunState();
    public CrouchState CrouchState = new CrouchState();
    public JumpState JumpState = new JumpState();

    void Start()
    {
        CurrentState = IdleState;
        PreviousState = CurrentState;
        CurrentState.EnterState(this);
    }

    void Update()
    {
        CurrentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        CurrentState.FixedUpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        CurrentState.ExitState(this);
        PreviousState = CurrentState;
        CurrentState = state;
        CurrentState.EnterState(this);
    }
}
