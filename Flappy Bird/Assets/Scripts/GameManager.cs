using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Player player;

    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    
   
    

    private void Awake()
    {        
        Application.targetFrameRate = 60;
        Pause();    


    }

    private void Start()
    {
        Play();
    }



    public void Play()
    {
        
        score = 0;
        scoreText.text = score.ToString();
        


        playButton.SetActive(false);
        gameOver.SetActive(false);
        


        Time.timeScale = 1f;
        player.enabled = true;


        Porros[] porros = FindObjectsOfType<Porros>();

        for(int i = 0; i < porros.Length; i++)
        {
            Destroy(porros[i].gameObject);
        }

        /*
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);

        }*/

    }     



    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        gameOver.SetActive(false);


    }

    

    public void Die()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        gameOver.SetActive(true);

    }

    




    
    public void GameOver()
    {
        
        
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Die();
      

    }


    public void DelayGameOver()
    {
        Invoke("GameOver", 0.5f);
        


    }

    public void IncreaseScore()

    {        
        score++;
        scoreText.text = score.ToString();   
             
        
    }

}
