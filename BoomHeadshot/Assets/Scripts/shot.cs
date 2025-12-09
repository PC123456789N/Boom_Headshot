using UnityEngine;

public class shot : MonoBehaviour
{
    private Rigidbody rb;
    private bool canColide;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canColide = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.2f){canColide = true;}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canColide)
        {
            //rb.isKinematic = true;
            Debug.Log("Colided with" + other.name);    
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("invisiwall"))
        {
            Debug.Log("WABLUA.");
            Destroy(gameObject);    
        }
        
    }
}
