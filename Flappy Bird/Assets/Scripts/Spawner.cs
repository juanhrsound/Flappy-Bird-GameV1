using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spwanRate = 1f;
    public float minHeight = -0.5f;
    public float maxHeight = 0.5f;
    public int numPrefabs = 10;    


    private void OnEnable()
    {

        InvokeRepeating(nameof(Spawn), spwanRate, spwanRate);      

    }


    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }



    void Spawn()
    {
        GameObject porros = Instantiate(prefab, transform.position, Quaternion.identity);
        porros.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        

        

    }



}
