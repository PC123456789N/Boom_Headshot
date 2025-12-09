using UnityEngine;
public class IdleState : FSMInterface
{
    private readonly Transform NPCpos;
    private readonly Rigidbody rb;
    private readonly Animator anima;
    private FiniteStateMachine FSM;
    public IdleState(Transform pos, Rigidbody body, Animator anim, FiniteStateMachine fsm)
    {
        NPCpos = pos;
        rb = body;
        anima = anim;
        FSM = fsm;
    }

    float countdown = 0f;

    public void Enter()
    {
        anima.SetBool("Walking", false);
        countdown = Random.Range(1f, 4f);
    }

    public void Tick()
    {
        Collider[] hits = Physics.OverlapSphere(NPCpos.position, 8f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("ChocoBullet"))
            {
                FSM.ChangeState(new MoveToTargetState(NPCpos, rb, anima, hit.transform, FSM));
                return;
            }
        }

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            return;
        }

        int action = Random.Range(0, 3);

        if (action == 0)
        {
            anima.SetBool("Walking", false);
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            anima.SetBool("Walking", true);
            NPCpos.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            rb.linearVelocity = NPCpos.forward * 3f;
        }

        countdown = Random.Range(1f, 4f);
    }

    public void Exit()
    {
        rb.linearVelocity = Vector3.zero;
    }
}