using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LookScript : NetworkBehaviour
{
    // Public:
    // Sensitivity of the mouse
    public float mouseSensitivity = 2.0f;
    // Minimum & Maximum Y axis (degrees)
    public float minimumY = -90f;
    public float maximumY = 90f;

    // Private:
    // Yaw of the camera (Rotation on Y)
    private float rotationY = 0f;
    // Pitch of the camera (Rotation on X)
    private float rotationX = 0f;
    // Main camera reference
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Lock the mouse
        Cursor.lockState = CursorLockMode.Locked;
        // Make cursor invisible
        Cursor.visible = false;
        // Gets reference to the camera inside of this gameobject
        Camera cam = GetComponentInChildren<Camera>();
        if(cam != null)
        {
            mainCamera = cam.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            // Update input for local player only
            HandleInput();
        }
    }

    private void OnDestroy()
    {
        // Release the cursor
        Cursor.lockState = CursorLockMode.None;
        // Make cursor visible
        Cursor.visible = true;
    }

    void HandleInput()
    {
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationX += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; ;

        rotationX = Mathf.Clamp(rotationX, minimumY, maximumY);
    }
}
