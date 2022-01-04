using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float minX = 0;
    public float maxX = 0;
    public float minY = 0;
    public float maxY = 0;
    public float XSpeed = 0;
    public float YSpeed = 0;
    int rtx = 1;
    int rty = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rtx = transform.position.x <= minX ? 1 : transform.position.x >= maxX ? -1 : rtx;
        rty = transform.position.y <= minY ? 1 : transform.position.y >= maxY ? -1 : rty;
        transform.Translate(XSpeed * rtx * Time.deltaTime, YSpeed * rty * Time.deltaTime, 0);
    }
}
