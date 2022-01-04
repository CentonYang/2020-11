using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 2;
    public Transform Player;
    public bool isMove = true;
    public float[] XRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = transform.position.x < Player.position.x ? false : true;
            transform.Translate(transform.position.x < Player.position.x && transform.position.x <= XRange[1] ? Speed * Time.deltaTime : transform.position.x >= XRange[0] ? -Speed * Time.deltaTime : 0, 0, 0);
        }
        if (transform.position.y < -7) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.name == "GroundCheck")
        {
            isMove = false;
            GetComponentInChildren<Animator>().Play("M_Die");
            Destroy(gameObject, 2);
        }
    }
}
