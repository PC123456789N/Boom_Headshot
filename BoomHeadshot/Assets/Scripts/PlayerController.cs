using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    float speed = 5f;
    private Rigidbody rb, bulletRB;

    public int bulletVelocity;
    private bool shotFired;
    private Vector3 hitPos;

    [SerializeField] private Transform camPos;
    [SerializeField] private GameObject chocoBullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setShotFired(false);
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

            if (Physics.Raycast(ray, out hit, 3000f) && !hit.collider.CompareTag("inivisiwall"))
            {
                hitPos = hit.point;
            }

            GameObject bullet = Instantiate(chocoBullet, camPos.position, camPos.rotation);
            bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = camPos.forward * bulletVelocity;
            setShotFired(true);
        }

        if (shotFired && Vector3.Distance(bulletRB.position, hitPos) < 2f)
        {
            bulletRB.linearVelocity = Vector3.zero;
            setShotFired(false);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setShotFired(bool state)
    {
        shotFired = state;
    }
}
