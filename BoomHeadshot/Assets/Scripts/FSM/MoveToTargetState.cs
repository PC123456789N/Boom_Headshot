using UnityEngine;

public class MoveToTargetState : FSMInterface
{
    private readonly Transform NPCpos;
    private readonly Rigidbody rb;
    private readonly Animator anima;
    private readonly Transform target;
    private readonly FiniteStateMachine FSM;

    public MoveToTargetState(Transform pos, Rigidbody body, Animator anim, Transform t, FiniteStateMachine fsm)
    {
        NPCpos = pos;
        rb = body;
        anima = anim;
        target = t;
        FSM = fsm;
    }

    public void Enter()
    {
        anima?.SetBool("Walking", true);
    }

    public void Tick()
    {
        if (target == null)
        {
            FSM.ChangeState(new IdleState(NPCpos, rb, anima, FSM));
            return;
        }

        float dist = Vector3.Distance(NPCpos.position, target.position);

        if (dist <= 1.2f)
        {
            anima?.SetBool("Walking", false);
            rb.linearVelocity = Vector3.zero;

            if (target != null) {
                GameObject.Destroy(target.gameObject);
                GameController.instance.IncreaseShots();
                GameController.instance.IncreseScore();
            }

            FSM.ChangeState(new DanceState(NPCpos, rb, anima));
            return;
        }


        Vector3 dir = (target.position - NPCpos.position).normalized;
        NPCpos.forward = dir;
        rb.linearVelocity = dir * 4f;
    }

    public void Exit()
    {
        anima?.SetBool("Walking", false);
        rb.linearVelocity = Vector3.zero;
    }
}
