using UnityEngine;
using UnityEngine.UI;

public class POVcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float camSencitivity = 4f;
    public bool mouseLock;
    public bool ads;
    private float camVerticalRotation;

    [SerializeField] private GameObject sight, win, lose;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseLock = true;
        ads = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseLock)
        {
            float mouseX = Input.GetAxis("Mouse X") * camSencitivity;
            float mouseY = Input.GetAxis("Mouse Y") * camSencitivity;

            camVerticalRotation -= mouseY;
            camVerticalRotation = Mathf.Clamp(camVerticalRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(camVerticalRotation, 0f, 0f);
            
            player.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleLockMouse();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ADS();

        }
        else if(Input.GetMouseButtonUp(1))
        {
            ADS();
        }

        
        if (GameController.instance.GetScore() >= 3)
        {
            win.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (GameController.instance.GetShots() >= 8)
        {
            lose.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ToggleLockMouse()
    {
        if (!mouseLock)Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
        Cursor.visible = mouseLock;
        mouseLock = !mouseLock;
    }

    public void ADS()
    {
        if (!ads)
        {
            Camera.main.fieldOfView = 5f; 
            sight.SetActive(true); 
            camSencitivity = 0.5f;
        }
        else {
            Camera.main.fieldOfView = 60f; 
            sight.SetActive(false); 
            camSencitivity = 4f;
        }
        ads = !ads;
    }
}
