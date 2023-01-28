using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabPorros;
    public GameObject prefabFire;

    public float spwanRate = 1f;
    public float spawnRateFire = 1f;

    public float minHeight = -0.5f;
    public float maxHeight = 0.5f;
    public int numPrefabs = 10;
    public bool fireIncoming = false;
    

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && fireIncoming == false)
        {
            
            spwanRate = 10f;
            CancelInvoke(nameof(SpawnPorros));
            OnEnable();            
            fireIncoming = true;

            if (fireIncoming == true)
            {                
                SpawnerActsNow();
            }
        }

       

    }

    private void OnEnable()
    {

        InvokeRepeating(nameof(SpawnPorros), spwanRate, spwanRate);
        
    }

    



    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPorros));
    }    


    void SpawnPorros()
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
        fireIncoming = false;
       

    }


}
