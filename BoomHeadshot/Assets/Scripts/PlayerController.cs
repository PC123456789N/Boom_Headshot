using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    private Rigidbody rb;

    public int bulletVelocity;
    private bool shotFired;

    //for bullet
    private Rigidbody bulletRB;
    private Vector3 hitPos;


    [SerializeField]private Transform camPos;
    [SerializeField]private GameObject chocoBullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shotFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        if (!shotFired && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3000f)) 
            {
                Debug.Log("Acertou: " + hit.collider.name);

                // Exemplo: acessar posição
                hitPos = hit.point;
                // hit.collider.gameObject;
            }
            
            
            GameObject bullet = Instantiate(chocoBullet, camPos.position, camPos.rotation);
            bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = camPos.forward * bulletVelocity;
            shotFired = true;

            
        }

        if (shotFired && Vector3.Distance(bulletRB.position, hitPos) < 2f)
                {
                    bulletRB.linearVelocity = Vector3.zero;
                    Debug.Log("Rigidbody parado.");
                    shotFired = false;
                }
        ;
        
    }
}
