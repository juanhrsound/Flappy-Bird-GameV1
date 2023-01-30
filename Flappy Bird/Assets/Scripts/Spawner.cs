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
    

    private void Awake()
    {

    }


    private void Start()
    {
        //prefabPorros.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            spwanRate = 10f;
            CancelInvoke(nameof(SpawnPorros));
            OnEnable();            

           
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
       

    }

    



    IEnumerator PowerOn()
    {
        
        spwanRate = 0.3f;
        CancelInvoke(nameof(SpawnPorros));
        OnEnable();
        yield return new WaitForSeconds(8.88f);
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
