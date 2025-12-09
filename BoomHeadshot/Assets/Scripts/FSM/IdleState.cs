using UnityEngine;
public class IdleState : FSMInterface
{
    private readonly Transform NPCpos;
    private readonly Rigidbody rb;
    private readonly Animator anima;
    float countdown = 0f;
    float detectRadius = 8f;
    private FiniteStateMachine FSM;
    public IdleState(Transform pos, Rigidbody body, Animator anim, FiniteStateMachine fsm)
    {
        NPCpos = pos;
        rb = body;
        anima = anim;
        FSM = fsm;
    }

    public void Enter()
    {
        anima.SetBool("Walking", false);
        countdown = Random.Range(1f, 4f);
    }

    public void Tick()
    {
        Collider[] hits = Physics.OverlapSphere(NPCpos.position, detectRadius);
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
            NPCpos.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            rb.linearVelocity = NPCpos.forward * 3;
        }

        countdown = Random.Range(1f, 4f);
    }

    public void Exit()
    {
        rb.linearVelocity = Vector3.zero;
    }
}