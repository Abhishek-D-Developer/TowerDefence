using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] GameObject weaponPanel;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0)) // Change 0 to the desired mouse button index
        {
            // Raycast to get the object under the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object has the BoxScript attached
                TurretArea boxScript = hit.collider.GetComponent<TurretArea>();

                // If the script is found, do something with it
                if (boxScript != null)
                {
                    // Access methods or properties of the BoxScript
                    boxScript.occupied = true;
                    GameObject obj = Instantiate(weaponPanel, boxScript.turretSpawnPos.localPosition, Quaternion.identity);
                }
            }
        }
    }
}
