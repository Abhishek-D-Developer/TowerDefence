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
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is the beginning of a touch
            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position to world space
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0f; // Ensure the z-coordinate is appropriate for your scene

                // Raycast to check if the touch is on the ground
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero, Mathf.Infinity, groundLayer);

                if (hit.collider != null)
                {
                    // Open the weapon panel
                    //weaponPanel.SetActive(true);
                }
            }
        }
    }
}
