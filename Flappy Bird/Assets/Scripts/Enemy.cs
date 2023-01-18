using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State {enemyIdle, enemyAttacks }
    private State currentState = State.enemyIdle;
    public GameObject gameObjectEnemy;
    //public SpriteRenderer ren;
    public Animator anim;
    public Rigidbody2D rb;
    //public Spawner enemyHere;


    private Transform trans;       

    private float impulse = 5f;
    private float numberOfFireBalls = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

        
    }
    // Update is called once per frame



    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {

            InvokeRepeating("EnemyAppearsNow", 0f, 2f);

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
