using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    private Slider slider;
    public GameObject porro;

    public enum States {idle, FUA}
    public States currentState = States.idle;



    void Start()
    {
        porro = GetComponent<GameObject>();
        slider = GetComponent<Slider>();
        currentState = States.idle;


    }

    private void Update()
    {
        
        StartCoroutine(SliderValue());
        
        

    }

    IEnumerator SliderValue()
    {
        
        if (slider.value == 2)
        {            
            if (Input.GetMouseButtonDown(0))
            {
                slider.value = 0;                
               //FindObjectOfType<Parallax>().LerpAnimationSpeed();
                FindObjectOfType<Player>().FUAState(true);
                FindObjectOfType<Spawner>().StartCoroutine("PowerOn");


                Debug.Log("ON");

                yield return new WaitForSeconds(8.88f);
                yield return new WaitForSeconds(5.55f);

                Debug.Log("OFF");

                FindObjectOfType<Spawner>().PowerOff();
                FindObjectOfType<Player>().FUAState(false);

                

            } 

        } 
       
        

    }

    

}
