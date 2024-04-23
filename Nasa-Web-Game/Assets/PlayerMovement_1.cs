using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float rotationAmount = 1f; // Amount of rotation per space bar press

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Rotate the player
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }
}
