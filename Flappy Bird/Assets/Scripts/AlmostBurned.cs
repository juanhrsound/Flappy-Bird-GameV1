using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostBurned : MonoBehaviour
{
    public AudioClip[] almostBurned;
    public AudioSource audioSource;
    private int previousSoundIndex = -1;

    public Collider2D coll;
    public bool almostBurned_B;

    

    // Start is called before the first frame update
    void Start()
    {
        almostBurned_B = true;
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (almostBurned_B == true)
        {
            if (collision.gameObject.tag == "almostBurned")
            {
                int soundIndex;
                do
                {
                    soundIndex = Random.Range(0, almostBurned.Length);
                } while (soundIndex == previousSoundIndex);

                audioSource.PlayOneShot(almostBurned[soundIndex]);
                previousSoundIndex = soundIndex;
            }
        }
        

    }



}
