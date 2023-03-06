using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Player player;
    public GameManager gameManager;
    public Collider2D coll;
    public Animator animPlayer;

    public AudioSource fireSound; 
    
    private SpriteRenderer ren;    
    private Transform trans;    
    private float impulse = 5f;

    public float firePoints;
    public float initialFire = 0f;
    public float minFire = 0f;
    public float maxFire = 8f;


    void Awake()
    {
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

    }
    
    public void Start()
    {
        initialFire = minFire;
        coll.enabled = true;
        Fireeeee();

    }

   public void Fireeeee()
    {
        InvokeRepeating("FireAppearsNow", Random.Range(1, 2), 2f);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            StartCoroutine(AnimationFire());
        }

    }

    IEnumerator AnimationFire()
    {

        coll.enabled = false;
        anim.SetBool("fireDestroyed", true);
        fireSound.Play();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(0.2f);
        ren.enabled = false;       

        yield return new WaitForSeconds(0.01f);
        
        rb.constraints = RigidbodyConstraints2D.None;
        
        FindObjectOfType<GameManager>().IncreaseScoreFire();


    }

    public void FireAppearsNow()
    {
        StartCoroutine(FireAppears());
    }


    IEnumerator FireAppears()
    {
        coll.enabled = true;
        ren.enabled = true;
        anim.SetBool("fireDestroyed", false);
        rb.velocity = new Vector3(-5, 0, 0) * impulse;
        trans.position = new Vector3(15, Random.Range(-3.89f, 8.21f), 0);
        yield return null;
    }


    





}
