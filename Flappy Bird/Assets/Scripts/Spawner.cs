using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabPorros;
    //public GameObject prefabFire;

    public float spwanRate = 1f;

    public float minHeight = -0.5f;
    public float maxHeight = 0.5f;
    public int numPrefabs = 10;
    

    private void Awake()
    {

    }


    public void Start()
    {
        spwanRate = 1f;
    }

    private void Update()
    {
               

    }

    public void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPorros), spwanRate, spwanRate);
        
    }

    public void ButtonSpawn()
    {
        
        spwanRate = 1f;
        OnEnable();


    }



    public void OnDisable()
    {
        CancelInvoke(nameof(SpawnPorros));
       
    }    


    public void SpawnPorros()
    {
        
        GameObject porros = Instantiate(prefabPorros, transform.position, Quaternion.identity);
        porros.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
              
    }

    public void SpawnerActsNow()
    {
        StartCoroutine(SpawnerChanges());
    } 


    IEnumerator SpawnerChanges()
    {        
        yield return new WaitForSeconds(2f);        
        spwanRate = 1f;
        OnEnable();
       
    } 


    IEnumerator PowerOn()
    {
        
        spwanRate = 0.7f;
        CancelInvoke(nameof(SpawnPorros));
        OnEnable();

        yield return new WaitForSeconds(13f);
        spwanRate = 20f;
        CancelInvoke(nameof(SpawnPorros));
        OnEnable();
        yield return new WaitForSeconds(5f);
       
        spwanRate = 1f;
        CancelInvoke(nameof(SpawnPorros));
        OnEnable();              


    }


    public void PowerOff()
    {
        prefabPorros.SetActive(true);

    }



}
