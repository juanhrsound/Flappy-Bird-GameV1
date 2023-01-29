using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    private Slider slider;
    public PorroElement porroElement;  

    //public bool executed;



    void Start()
    {
        slider = GetComponent<Slider>();


        //executed = false;



    }

    private void Update()
    {
        SliderValue();

    }

    void SliderValue()
    {
        
        if (slider.value == 2)
        {            
            if (Input.GetMouseButtonDown(0))
            {
                //executed = true;
                slider.value = 0;
                porroElement.sprite.enabled = false;
                Debug.Log("hola");
                                
            }

        }
        
    }

}
