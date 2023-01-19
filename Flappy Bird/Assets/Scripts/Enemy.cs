using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float distanceEnemy;
    private float distancePlayer;

    private float distanceThreshold = 3f;
    private Transform trans;    
    private float impulse = 5f;
    private bool fireBallCollides;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();

    }


    private void Start()
    {     

        
    }  



    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {

            InvokeRepeating("EnemyAppearsNow", 0f, 2f);
                       

        }           

        float distanceEnemy = this.transform.position.x;
        float distancePlayer = player.transform.position.x;


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
        if (animPlayer.GetBool("cuchoFua") == true)
        {
            if (Mathf.Abs(distancePlayer - distanceEnemy) < distanceThreshold)
            {
                if (enemyCollides == true)
                {
                    anim.SetBool("fireDestroyed", true);
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                    yield return new WaitForSeconds(0.5f);
                    rb.constraints = RigidbodyConstraints2D.None;
                    ren.enabled = false;
                    yield return new WaitForSeconds(0.5f);                    
                    anim.SetBool("fireDestroyed", false);
                    ren.enabled = true;

                    

                }

            }
            
        } else if (Mathf.Abs(distancePlayer - distanceEnemy) > distanceThreshold)
        
        {
            anim.SetBool("fireDestroyed", false);
           
        }

        

    }

    /*
    public void Shield(bool value)
    {
        hasShield = value;

    }
    */


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
