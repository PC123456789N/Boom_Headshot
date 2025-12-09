using UnityEngine;

public class shot : MonoBehaviour
{
    private Vector3 lastPosition;
    private float timeLimit = 0f;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position == lastPosition)
        {
            timeLimit += Time.deltaTime;
            if (timeLimit >= 5f)
            {
                Destroy(gameObject);
                PlayerController.instance.setShotFired(false);
            }
        }
        else
        {
            timeLimit = 0f;
            lastPosition = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inivisiwall"))
        {
            Destroy(gameObject);
            PlayerController.instance.setShotFired(false);
        }
    }
}
