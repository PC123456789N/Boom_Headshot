using UnityEngine;

public class POVcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float camSencitivity = 4f;
    public bool mouseLock;
    public bool ads;
    private float camVerticalRotation;
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
        if(!ads){Camera.main.fieldOfView = 30f; Debug.Log("enter ads");}
        else{Camera.main.fieldOfView = 60f; Debug.Log("exit ads");}
        ads = !ads;
    }
}
