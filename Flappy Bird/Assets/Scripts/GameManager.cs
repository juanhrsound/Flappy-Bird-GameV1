using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;


public class GameManager : MonoBehaviour
{
    public Slider sliderFire;
    public Text scoreText;
    
    private int score;
    public int fireMax;

    public Player player;
    public GameObject playButton;
    public GameObject gameOver;

           
    private void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();

    }

    private void Start()
    {
       Play();       
    }


    void Play()
    {

        score = 0;
        scoreText.text = score.ToString();

        sliderFire.value = 0;

        playButton.SetActive(false);
        gameOver.SetActive(false);

        
        FindObjectOfType<Player>().Start();
        FindObjectOfType<Fire>();

        Time.timeScale = 1f;
        player.enabled = true;        


        Porros[] porros = FindObjectsOfType<Porros>();

        for(int i = 0; i < porros.Length; i++)
        {
            Destroy(porros[i].gameObject);
        }


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
             
        
    }

    public void IncreaseScoreFire()

    {
        sliderFire.value += 1;
        fireMax++;


    }





}
