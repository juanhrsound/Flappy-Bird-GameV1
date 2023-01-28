using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = FindObjectOfType<GameManager>().IncreaseScoreFire();


    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
