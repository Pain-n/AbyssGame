public abstract class MovementBaseState
{
    public abstract void EnterState(MovementStateManager manager);
    public abstract void UpdateState(MovementStateManager manager);
    public abstract void FixedUpdateState(MovementStateManager manager);
    public abstract void ExitState(MovementStateManager manager);
}
