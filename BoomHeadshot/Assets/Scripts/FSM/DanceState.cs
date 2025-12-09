using UnityEngine;

public class DanceState : FSMInterface
{
    private readonly Transform NPCpos;
    private readonly Rigidbody rb;
    private readonly Animator anima;

    public DanceState(Transform pos, Rigidbody body, Animator anim)
    {
        NPCpos = pos;
        rb = body;
        anima = anim;
    }

    public void Enter()
    {
        anima.SetBool("Walking", false);
        anima.SetBool("Dancing", true);
        rb.linearVelocity = Vector3.zero;
    }

    public void Tick()
    {
        rb.linearVelocity = Vector3.zero;
    }

    public void Exit()
    {
        anima.SetBool("Dancing", false);
    }
}
