using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public GameObject gameObjectEnemy;    
    public Animator anim;
    public Rigidbody2D rb;
    public Player player;
    public bool hasShield;
    public Animator animPlayer;




    private Transform trans;    
    private float impulse = 5f;
    private bool fireBallCollides;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

            




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

        if (fireBallCollides ==  true)
        {
            anim.SetBool("fireBallCollides", true);

        }

        if (fireBallCollides == false)
        {
            anim.SetBool("fireDestroyed", false);
        }

        if (animPlayer.GetBool("cuchoFua") == true)
        {
            trans.position = new Vector2(rb.position.x, trans.position.y);
            anim.SetBool("fireDestroyed", true);
            
        }



        if (animPlayer.GetBool("cuchoFua") == false)
        {
            Debug.Log("SHIELD OFF");
        }
        

    }




    public void Shield(bool value)
    {
        hasShield = value;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && animPlayer.GetBool("cuchoFua") == false)
        {

            FindObjectOfType<GameManager>().DelayGameOver();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            trans.position = new Vector2(rb.position.x + -2f, trans.position.y);

            fireBallCollides = true;
        }
                

    } 


    public void EnemyAppearsNow()
    {
        StartCoroutine(EnemyAppears());
    }


    IEnumerator EnemyAppears()
    {
        
        rb.velocity = new Vector3(-5, 0, 0) * impulse;        
        trans.position = new Vector3(15, Random.Range(-3, 3), 0);       
        yield return null;
    }




}
