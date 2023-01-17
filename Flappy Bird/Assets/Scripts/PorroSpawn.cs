using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorroSpawn : MonoBehaviour
{
    public GameObject gameObject;


    // Start is called before the first frame update
    private void Awake()
    {
       
    }

    void Start()
    {
        
        
        StartCoroutine(PorroBlink());
        
    }      
    

    IEnumerator PorroBlink()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);

    }





}
