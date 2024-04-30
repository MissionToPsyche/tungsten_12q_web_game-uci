using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    private float rotationSpeed = 130f; // Speed of rotation
    private float unrotateAmount = 15f; // Amount of rotation to undo per space press
    private float maxUnrotateAngle = 90f; // Maximum angle to undo per space press
    private float unrotateForce = 50f; // Force applied to unrotate

    private Rigidbody2D rb;
    private bool isUpright = true; // Flag to track if the player is upright

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply default rotation
        float rotationInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(rotationInput) < 0.1f) // If no input, apply default rotation
        {
            rb.AddTorque(rotationSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else // If there is input, apply rotation based on input
        {
            rb.AddTorque(-rotationInput * rotationSpeed * Time.deltaTime, ForceMode2D.Force);
        }

        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the player is currently upright, apply unrotate force
            if (isUpright)
            {
                rb.AddTorque(-unrotateForce, ForceMode2D.Force);
                isUpright = false;
            }
            else // If not upright, undo rotation gradually
            {
                float currentRotation = transform.eulerAngles.z;
                float remainingRotation = Mathf.Clamp(currentRotation, 0f, maxUnrotateAngle);
                float rotationToUndo = Mathf.Min(remainingRotation, unrotateAmount);
                rb.AddTorque(rotationToUndo, ForceMode2D.Force);
                isUpright = true;
            }
        }
    }
}
