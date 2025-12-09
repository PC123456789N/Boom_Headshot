using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    private Rigidbody rb;

    [SerializeField] private int bulletVelocity = 200;

    [SerializeField] private Transform camPos;
    [SerializeField] private GameObject chocoBullet;
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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(chocoBullet, camPos.position, camPos.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = camPos.forward * bulletVelocity;
        }
        ;
    }
}
