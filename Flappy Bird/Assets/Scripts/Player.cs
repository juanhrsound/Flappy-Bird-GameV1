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
    private float rotationSpeed = 1f;

    //public GameObject gameObject;
    
    

    private bool jumped;
    private bool blinkObjectActivated = false;
   
    //private bool isVisible = true;
    //private bool isReappearAfterDelayRunning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();
        //gameObject = GetComponent<GameObject>();

    }

    private void Start()
    {
               

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
        if (Input.GetButtonDown("Jump"))
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

        
        

        if (Input.GetMouseButtonDown(0))
        {
            BlinkObjectNow();
        }             


    }       

    private void BlinkObjectNow()
    {
        StartCoroutine(CuchoShield());

    }

    
    

    IEnumerator CuchoShield()
    {

        transform.localScale = new Vector2(2, 2);
        rb.position = new Vector2(-15, 2);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector2(0.6f, 0.6f);
        rb.position = new Vector2(-16, 2);

    }

    

    
     







}
