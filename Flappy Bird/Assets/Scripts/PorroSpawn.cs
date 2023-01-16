using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorroSpawn : MonoBehaviour
{
    private SpriteRenderer ren;



    // Start is called before the first frame update
    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
        StartCoroutine(PorroBlink());
        
    }      
    

    IEnumerator PorroBlink()
    {
        yield return new WaitForSeconds(2f);
        ren.enabled = false;
        yield return new WaitForSeconds(5f);
        ren.enabled = true;

    }





}
