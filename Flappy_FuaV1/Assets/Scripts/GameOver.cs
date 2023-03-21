using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource gameOverAudioS;
    public AudioClip[] gameOverClip;
    


    public void gameOverActivated()
    {
        gameOverAudioS.PlayOneShot(gameOverClip[Random.Range(0, gameOverClip.Length)]);
        
    }
    

}
