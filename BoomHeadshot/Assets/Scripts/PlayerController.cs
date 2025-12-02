using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    private Rigidbody rb;

    [SerializeField]private GameObject shotPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        if(Input.GetMouseButtonDown(0));
    }
}
