using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, start;
    private GameObject camera;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Virtual Camera");
        start = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(start + distance, transform.position.y, transform.position.z);
    }
}
