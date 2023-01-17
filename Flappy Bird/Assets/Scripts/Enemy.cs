using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State {enemyIdle, enemyAttacks }
    private State currentState = State.enemyIdle;
    public GameObject gameObjectEnemy;
    public SpriteRenderer ren;

    public Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Invoke("enemyAppears", 2f);
        }

        if (Input.GetButtonDown(KeyCode.R))
        {
            anim.SetBool("enemyAttacks", true);
        }

    }


    private void enemyAppears()
    {
        ren.enabled = true;
        anim.SetBool("enemyIdle", true);
    }
}
