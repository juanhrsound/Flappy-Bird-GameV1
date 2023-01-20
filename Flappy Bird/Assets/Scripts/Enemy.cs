using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Player player;
    public Spawner spawner;

    public bool hasShield;
    public Animator animPlayer;
    

    public bool enemyCollides;

    private SpriteRenderer ren;

    private float distanceThresholdX = 3f;
    private float distanceThresholdY = 1f;

    private Transform trans;    
    private float impulse = 5f;

    void Awake()
    {
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();

    }


    public void Start()
    {
        InvokeRepeating("EnemyAppearsNow", Random.Range(1, 10), 2f);

    }  



    void Update()
    {                 
            

        StartCoroutine(DestroyFireBall());
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            enemyCollides = true;
            
        }


    }

    
    IEnumerator DestroyFireBall()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < distanceThresholdX)
        {
            if (Mathf.Abs(player.transform.position.y - transform.position.y) < distanceThresholdY)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    player.anim.SetBool("cuchoHits", true);
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                    yield return new WaitForSeconds(0.2f);
                    rb.constraints = RigidbodyConstraints2D.None;
                    ren.enabled = false;
                    yield return new WaitForSeconds(0.2f);
                    player.anim.SetBool("cuchoHits", false);

                    anim.SetBool("fireDestroyed", false);
                    ren.enabled = true;
                }
                
            }

        }


        else
        
        {
            anim.SetBool("fireDestroyed", false);
           
        }        

    }
   

    public void EnemyAppearsNow()
    {
        StartCoroutine(EnemyAppears());
    }


    IEnumerator EnemyAppears()
    {
        ren.enabled = true;
        rb.velocity = new Vector3(-5, 0, 0) * impulse;        
        trans.position = new Vector3(15, Random.Range(-3, 3), 0);       
        yield return null;
    }

     

}
