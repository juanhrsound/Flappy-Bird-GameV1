using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    public GameObject prefabPorros;


    public float spwanRate = 1f;

    public float minHeight = -0.5f;
    public float maxHeight = 0.5f;
    public int numPrefabs = 10;
    public bool powerSwitch;
    public AudioSource mainMusic;
    public AudioSource hiHat;
    public AudioSource introM;
    //public AudioClip fuaState;

    private string dryLevelIntro = "dryLevelIntro";
    public AudioMixer audioMixer;
    public float fadeDuration = 1f;

    private float initialVolume = 1;

    private void Awake()
    {

    }


    public void Start()
    {
        spwanRate = 1f;
        initialVolume = introM.volume;
        initialVolume = introM.volume;
    }

    private void Update()
    {
        Introoo();

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
    

    public void Introoo()
    {
        if (introM.isPlaying)
        {
            introM.volume -= initialVolume * Time.deltaTime / fadeDuration;

            if (introM.volume <= 0f)
            {
                introM.Stop();
            }
        }
    }





    IEnumerator PowerOn()
    {
        
        spwanRate = 0.7f;
        CancelInvoke(nameof(SpawnPorros));
        OnEnable();
        

        yield return new WaitForSeconds(16.55f);
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
