using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumph = 5;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool isGrounded = false;
    private Animator anim;
    private Vector3 rotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
    }

    void Update()
    {
        //Move
        float richtung = Input.GetAxis("Horizontal");
        if (richtung < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }
        if (richtung > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);

        }

        //Animation
        if (richtung != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tilemap")
        {
            isGrounded = true;
        }
    }
}
