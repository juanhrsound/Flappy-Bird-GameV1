using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform trans;
    [SerializeField] public Animator anim;
    [SerializeField] public AudioSource fuaaa;

    public AudioClip Scoring;
    
    


    private bool jumped;

    public bool isFua = false;

    //public FireBar firebar;
    public AudioSource scorePoint;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        //firebar = GetComponent<FireBar>();
        


    }

    public void Start()
    {
                
        Invoke("BodyTypeKinematic", 0f);
        transform.position = new Vector2(-16, 0);
        Invoke("BodyTypeDynamic", 0.2f);
        anim.SetBool("touchingObstacle", false);
        anim.SetBool("cuchoFua", false);
        isFua = false;
        rb.isKinematic = false;



    }

    void BodyTypeKinematic()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
    void BodyTypeDynamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Obstacle" && isFua == true)
        {


        }

        else if (other.gameObject.tag == "Obstacle" && isFua == false)
        {


            FindObjectOfType<GameManager>().DelayGameOver();
            anim.SetBool("touchingObstacle", true);


        }

        else if(other.gameObject.tag == "KillZone")
        {
            FindObjectOfType<GameManager>().DelayGameOver();
            anim.SetBool("touchingObstacle", true);
                      
                        

        }


        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            scorePoint.PlayOneShot(Scoring);

        }

       

    }


    public void FUAState(bool value)
    {
        isFua = value;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            jumped = true;                     


        }
        if (jumped == true && rb.velocity.y < 0)
        {
            jumped = false;
        }
           
   
    }
       
   
}
