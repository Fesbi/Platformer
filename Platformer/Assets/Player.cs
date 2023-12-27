using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody2D rb;
    public float jumph =5;
    private bool isGrounded = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
             isGrounded = false;
        }
        if(richtung != 0)
        {
            anim.SetBool("isRunning",true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
