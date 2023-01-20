using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabPorros;
    public GameObject prefabEnemy;

    public float spwanRate = 1f;
    public float spawnRateEnemy = 1f;

    public float minHeight = -0.5f;
    public float maxHeight = 0.5f;
    public int numPrefabs = 10;
    public bool enemyIncoming = false;
    

    //public GameObject enemy;
    private Enemy enemyScript;

    private void Awake()
    {

    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && enemyIncoming == false)
        {
            
            spwanRate = 10f;
            CancelInvoke(nameof(SpawnPorros));
            OnEnable();            
            enemyIncoming = true;

            if (enemyIncoming == true)
            {                
                SpawnerActsNow();
            }
        }

       

    }

    private void OnEnable()
    {

        InvokeRepeating(nameof(SpawnPorros), spwanRate, spwanRate);
        
    }

    public void OnEnableEnemy()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnRateEnemy, spawnRateEnemy);
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

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(prefabEnemy, transform.position, Quaternion.identity);
    }



    public void SpawnerActsNow()
    {
        StartCoroutine(SpawnerChanges());
    } 


    IEnumerator SpawnerChanges()
    {        
        yield return new WaitForSeconds(10f);        
        spwanRate = 1f;
        OnEnable();
        enemyIncoming = false;
       

    }


}
