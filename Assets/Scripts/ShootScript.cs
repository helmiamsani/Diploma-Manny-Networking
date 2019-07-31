using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootScript : NetworkBehaviour
{
    // Public:
    // Amount of bullets that can be fired per second
    public float fireRate = 1f;
    // Range that the bullet can travel
    public float range = 100f;
    // LayerMask of which layer to hit
    public LayerMask mask;

    // Private:
    // Timer for the fireRate
    private float fireFactor = 0f;
    // Reference to the camera child
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponentInChildren<Camera>();
        if(cam != null)
        {
            mainCamera = cam;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    void Cmd_PlayerShot(string _id)
    {
        Debug.Log("Player" + _id + "has been shot!");
    }

    [Client]
    void Shoot()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetButton("Fire1"))
        {
            if(Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log("Shoot Something!!!");
            }    
        }
    }
}
