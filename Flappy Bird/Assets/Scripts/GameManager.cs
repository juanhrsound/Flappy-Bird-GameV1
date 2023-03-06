using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    public Slider sliderFire;
    public Text scoreText;
    
    private int score;
    public int fireMax;

    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject credits;

    


    public void Awake()
    {

        Application.targetFrameRate = 60;        
        Pause();


    }
    
    void Play()
    {          

        score = 0;
        scoreText.text = score.ToString();

        sliderFire.value = 0;
        fireMax = 0;
      

        playButton.SetActive(false);
        gameOver.SetActive(false);
        credits.SetActive(false);

        FindObjectOfType<FireBar>().TheFireBar(fireMax);
        FindObjectOfType<Player>().Start();
        //FindObjectOfType<Fire>();

        Time.timeScale = 1f;
        player.enabled = true;        


        Porros[] porros = FindObjectsOfType<Porros>();

        for(int i = 0; i < porros.Length; i++)
        {
            Destroy(porros[i].gameObject);
        }

        FindObjectOfType<Spawner>().hiHat.Play();
        FindObjectOfType<Spawner>().Introoo();


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
        FindObjectOfType<GameOver>().gameOverActivated();


    }   

    
    public void GameOver()
    {

        gameOver.SetActive(true);
        playButton.SetActive(true);
        FindObjectOfType<Spawner>().mainMusic.Stop();
        FindObjectOfType<Spawner>().hiHat.Stop();

        if (FindObjectOfType<AlmostBurned>().audioSource.isPlaying)
        {
            FindObjectOfType<AlmostBurned>().audioSource.Stop();
        }

        Pause();
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

        if(score == 1)
        {
            FindObjectOfType<Spawner>().mainMusic.Play();
            FindObjectOfType<Spawner>().hiHat.Stop();
        }
             
        
    }

    public void IncreaseScoreFire()

    {
        sliderFire.value += 1;        
        fireMax++;
        FindObjectOfType<FireBar>().TheFireBar(fireMax);
            


    }








}
