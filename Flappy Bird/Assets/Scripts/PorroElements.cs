using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorroElements : MonoBehaviour
{

    public SpriteRenderer ren;
    public bool powerSwitch;



    private void Start()
    {


    }

    private void Update()
    {

        TransparentPorro();


    }



    public void PorroState(bool value)
    {
        powerSwitch = value;

    }
   
    public void TransparentPorro()
    {
      
            Renderer renderer = this.GetComponent<Renderer>();
            ren = GetComponent<SpriteRenderer>();
            Material material = renderer.material;
            Color color = material.color;
            color.a = 0.5f;
            material.color = color;



      




    }

















}

