
public class FiniteStateMachine
{
    public FSMInterface AtualState {get; private set; }

    public void ChangeState(FSMInterface NovoState)
    {
        AtualState?.Exit();
        AtualState = NovoState;
        AtualState.Enter();
    }

    public void Tick()
    {
        AtualState?.Tick();
    }
}
