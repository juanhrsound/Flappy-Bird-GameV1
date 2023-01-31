using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    private Slider slider;
    public GameObject porro;
    private bool plonReady;
  


    void Start()
    {
        slider = GetComponent<Slider>();


    }

    private void Update()
    {
        StartCoroutine(SliderValue());
    }

    IEnumerator SliderValue()
    {
        
        if (slider != null && slider.value >= 2)
        {            
            if (Input.GetMouseButtonDown(0))
            {

                slider.value = 0;                
                FindObjectOfType<Player>().FUAState(true);
                FindObjectOfType<Spawner>().StartCoroutine("PowerOn");
                Time.timeScale *= 3;

                yield return new WaitForSeconds(3f);
                yield return new WaitForSeconds(13.55f);

                Time.timeScale = 1;
                FindObjectOfType<Spawner>().PowerOff();
                FindObjectOfType<Player>().FUAState(false);
                



            }

        }
        
        

    }

    

}
