using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, start;
    public GameObject camera;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //gets starting position of object
        start = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gets distance to move background by multiplying speed
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(start + distance, transform.position.y, transform.position.z);
    }
}
