using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 10;
    public float JumpForce = 300;
    public Transform GroundCheck;
    public string WinScene;
    public string DieScene;
    bool isMove = true;
    bool isGround = true;
    float Score = 0;
    public float WinScore = 5;
    GameObject Monster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, 0);
            GetComponentInChildren<Animator>().SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));
            GetComponentInChildren<SpriteRenderer>().flipX = Input.GetAxis("Horizontal") > 0.1f ? false : Input.GetAxis("Horizontal") < -0.1f ? true : GetComponentInChildren<SpriteRenderer>().flipX;
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                GetComponentInChildren<Animator>().SetTrigger("Jump");
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
            }
        }
        isGround = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << 8);
        GetComponentInChildren<Animator>().SetBool("Stand", isGround ? true : false);
        if (transform.position.y < -7) SceneManager.LoadScene(DieScene);
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Candy")
        {
            Score++;
            Destroy(Other.gameObject);
        }
        if (Other.gameObject.name == "Win" && Score >= WinScore)
        {
            isMove = false;
            GetComponentInChildren<Animator>().Play("P_Win");
            Invoke("Win", 2);
        }
        if (Other.gameObject.tag == "Die")
        {
            isMove = false;
            GetComponentInChildren<Animator>().Play("P_Die");
            Invoke("Die", 2);
        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Monster")
        {
            if (Other.gameObject.GetComponent<Monster>().isMove)
            {
                isMove = false;
                GetComponentInChildren<Animator>().Play("P_Die");
                Invoke("Die", 2);
            }
        }
    }

    void Win()
    {
        SceneManager.LoadScene(WinScene);
    }

    void Die()
    {
        SceneManager.LoadScene(DieScene);
    }
}
