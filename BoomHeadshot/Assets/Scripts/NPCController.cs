using UnityEngine;

public class NPCController : MonoBehaviour
{
    private FiniteStateMachine FSM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FSM = new FiniteStateMachine();

        var Idle = new IdleState(transform, GetComponent<Rigidbody>(), GetComponent<Animator>(), FSM);
        FSM.ChangeState(Idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FSM.Tick();
    }
}
