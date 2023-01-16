using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public Vector3 direction;    
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public Transform trans;
    public Animator anim;
    public AudioMixer mix;
    public AudioSource audioSource;
    public AudioSource engineUp;
    public AudioSource engineDown;
    private SpriteRenderer ren;

    private bool jumped;
    //private bool isVisible = true;
    //private bool isReappearAfterDelayRunning = false;






    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        StartCoroutine(BlinkObject());


    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
           
            FindObjectOfType<GameManager>().delayGameOver();
            anim.SetBool("touchingObstacle", true);


        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            
        }


    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            engineUp.Play();
            jumped = true;


        }
        if (jumped == true && rb.velocity.y < 0)
        {
            engineDown.Play();
            jumped = false;
        }        

    }





    IEnumerator BlinkObject()
    {
        yield return new WaitForSeconds(5f + Random.Range(1f, 10f));
        ren.enabled = false;
        yield return new WaitForSeconds(1f);
        ren.enabled = true;
    }

    
     







}
