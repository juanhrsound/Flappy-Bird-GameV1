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
    private bool jumped;
    public bool isFua = false;

    public FireBar firebar;
        

    
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        firebar = GetComponent<FireBar>();


    }

    public void Start()
    {
                
        Invoke("BodyTypeKinematic", 0f);
        transform.position = new Vector2(-16, 0);
        Invoke("BodyTypeDynamic", 0.2f);
        anim.SetBool("touchingObstacle", false);


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


        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();

        }       

    }

    public void FUAState(bool value)
    {
        isFua = value;
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


                
   
    }
       
    // luego hacer esto cuando tengamos el sprite de cucho.
    /*
    IEnumerator CuchoShield()
    {
        
        transform.localScale = new Vector2(0.7f, 0.7f);

        yield return new WaitForSeconds(0.5f);

        anim.SetBool("cuchoFua", false);
        transform.localScale = new Vector2(0.6f, 0.6f);        

    }
    */

}
