using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public bool isPlayer;
    private Vector3 rotation;
    private Vector3 currentPosition;
    private Animator anim;
    private GameObject player;
    private Transform playerTransform;
    private Player playerScript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = GameObject.Find("Player").transform;
        playerScript = playerTransform.GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isPlayer)
        {
            Debug.Log("NormalEnemy");
        }
        else
        {
            player.SetActive(false);
            playerTransform.position = currentPosition;

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

            if (richtung != 0)
            {
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }
        }

        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }
}
