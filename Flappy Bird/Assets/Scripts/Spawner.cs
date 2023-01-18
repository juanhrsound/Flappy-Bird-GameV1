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
    public bool enemyIncoming = false;

    //public GameObject enemy;
    private Enemy enemyScript;

    private void Awake()
    {
        //enemyScript = enemy.GetComponent<Enemy>();
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && enemyIncoming == false)
        {
            
            spwanRate = 2f;
            CancelInvoke(nameof(Spawn));
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

    public void SpawnerActsNow()
    {
        StartCoroutine(SpawnerChanges());
    } 


    IEnumerator SpawnerChanges()
    {        
        yield return new WaitForSeconds(15f);        
        spwanRate = 1f;
        OnEnable();
        enemyIncoming = false;
       

    }


}
