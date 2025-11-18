using UnityEngine;

public class POVcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float camSencitivity = 4f;
    public bool mouseLock;
    private float camVerticalRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Catches Inputs
        float InputX = Input.GetAxis("Mouse X")*camSencitivity;
        float InputY = Input.GetAxis("Mouse Y")*camSencitivity;

        //Process Input into Movement (Camera Moves Up and Down!)
        camVerticalRotation -= InputY;
        camVerticalRotation = Mathf.Clamp(camVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * camVerticalRotation;

        //Process Input into Movement(Character Moves Left and Right, Dragging the Camera)

        player.Rotate(Vector3.up * InputX);
    }

    public void ToggleLockMouse(bool locked)
    {
        if (!locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            locked = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            locked = false;
        }

    }
}
