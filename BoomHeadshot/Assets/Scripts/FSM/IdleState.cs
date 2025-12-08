using UnityEngine;
public class IdleState : FSMInterface
{
    private readonly Transform NPCpos;
    private readonly Rigidbody rb;
    private readonly Animator anima;
    int moveChance;
    bool canMove = true;
    float countdown = 2f;
    public IdleState(Transform NewNPCpos, Rigidbody newRb, Animator newAnima)
    {
        NPCpos = NewNPCpos;
        rb = newRb;
        anima = newAnima;
    }

    public void Enter()
    {
        Debug.Log("esta no Idle");
    }
    public void Tick()
    {
        if(countdown > 0f)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            moveChance = Random.Range(0,3);
            if(moveChance == 1)
            {
                canMove = false;
                Debug.Log("chance Happened");
                anima.SetBool("Walking", true);
                NPCpos.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
                rb.linearVelocity = NPCpos.forward * 3;
                countdown = 2f;
            } 
            else if(moveChance == 0)
            {
                canMove = false;
                Debug.Log("chance stopped");
                anima.SetBool("Walking", false);
                NPCpos.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
                rb.linearVelocity = NPCpos.forward * 0;
                countdown = 2f;
            }
        }

        
    }

    public void Exit()
    {
        Debug.Log("Saiu do Idle");
    }
}