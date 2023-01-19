using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField] public Vector3 direction;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform trans;
    [SerializeField] public Animator anim;
    [SerializeField] public AudioMixer mix;
    //[SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioSource Fuaaa;
    //[SerializeField] public AudioSource engineDown;

   // private enum State {Cucho, CuchoShield}
   // private State currentState = State.CuchoShield;

    public bool shieldOn;

    //public GameObject gameObject;



    private bool jumped;
   
    //private bool isVisible = true;
    //private bool isReappearAfterDelayRunning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();

    }

    private void Start()
    {
    

    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            FindObjectOfType<GameManager>().DelayGameOver();
            anim.SetBool("touchingObstacle", true);


        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();

        }

        else if (other.gameObject.tag == "Enemy" && shieldOn == false)
        {
            FindObjectOfType<GameManager>().DelayGameOver();
            anim.SetBool("touchingObstacle", true);           

        }



    }   


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            jumped = true;                     


        }
        if (jumped == true && rb.velocity.y < 0)
        {
            jumped = false;
        }
                
        

        if (Input.GetMouseButtonDown(0))
        {
            BlinkObjectNow();
            Fuaaa.Play();
            
        }             


    }       

    private void BlinkObjectNow()
    {
        StartCoroutine(CuchoShield());

    }   
    

    IEnumerator CuchoShield()
    {
        anim.SetBool("cuchoFua", true);
        transform.localScale = new Vector2(2.5f, 2.5f );
        shieldOn = true;
        //GetComponent<Enemy>().Shield(true);
        //Debug.Log("SHIELD ON");


        yield return new WaitForSeconds(0.2f);
        anim.SetBool("cuchoFua", false);
        transform.localScale = new Vector2(0.6f, 0.6f);
        shieldOn = false;
        //GetComponent<Enemy>().Shield(false);
        //Debug.Log("SHIELD OFF");






    }

    

    
     







}
