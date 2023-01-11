using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;    
    public float jumpForce = 5f;
    private SpriteRenderer spriteR;
    public Sprite[] sprites;
    private int spriteIndex;
    public Rigidbody2D rb;
    
   



    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteR.sprite = sprites[spriteIndex];

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();


        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }


    }


    private void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


    }


}
