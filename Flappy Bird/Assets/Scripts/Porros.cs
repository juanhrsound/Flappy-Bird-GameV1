using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porros : MonoBehaviour
{
    public float speed = 10f;
    private float leftEdge;



    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }



    }



}
